using System;
using System.ComponentModel.DataAnnotations;

namespace Conexia.SR.Application.ViewModels.PersonalNotes
{
    public class PersonalNoteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "The field {0} must have between {2} e {1} characters")]
        public string Body { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
