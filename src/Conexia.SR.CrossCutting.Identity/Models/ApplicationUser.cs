using Microsoft.AspNetCore.Identity;
using System;

namespace Conexia.SR.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Hometown { get; set; }
    }
}
