using Conexia.SR.Application.Interfaces;
using Conexia.SR.Application.ViewModels.PersonalNotes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Conexia.SR.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalNotesController : ControllerBase
    {
        private readonly IPersonalNoteAppService _noteService;
        public PersonalNotesController(IPersonalNoteAppService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("teste")]
        public IActionResult Teste() => Ok("Sucesso");

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var notes = await _noteService.GetNotesByUser(GetUserId());
            return Ok(notes);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetNote(Guid id)
        {
            var note = await _noteService.GetNoteById(id);
            return Ok(note);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonalNote(PersonalNoteViewModel noteViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            noteViewModel.UserId = GetUserId();
            var result = await _noteService.CreateNote(noteViewModel);
            if (result)
            {
                return Ok(noteViewModel);
            }

            return BadRequest("It wasn't possible to create the note");
        }

        private Guid GetUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Guid.Parse(userId);
        }
    }
}
