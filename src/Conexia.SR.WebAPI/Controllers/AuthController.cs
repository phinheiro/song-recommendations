﻿using Conexia.SR.CrossCutting.Identity.Models;
using Conexia.SR.CrossCutting.Identity.ViewModels;
using Conexia.SR.WebAPI.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Conexia.SR.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtAppSettings _jwtSettings;
        public AuthController(SignInManager<ApplicationUser> signInManager, 
                                UserManager<ApplicationUser> userManager,
                                IOptions<JwtAppSettings> jwtSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = new ApplicationUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true,
                Name = registerUser.Name,
                Hometown = registerUser.Hometown
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok(await GenerateJWT(user.Email));
            }

            return BadRequest(result.Errors.SelectMany(e => e.Description));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(new { token = await GenerateJWT(loginUser.Email) });
            }

            if (result.IsLockedOut)
            {
                return BadRequest("User temporarily blocked due to invalid attempts");
            }

            return BadRequest("User or password incorrect");
        }

        private async Task<string> GenerateJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var claims = await _userManager.GetClaimsAsync(user);
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.ValidAt,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }

        private static long ToUnixEpochDate(DateTime date) =>
            (int)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}