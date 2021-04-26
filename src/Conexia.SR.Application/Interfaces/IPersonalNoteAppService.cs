using Conexia.SR.Application.ViewModels.PersonalNotes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conexia.SR.Application.Interfaces
{
    public interface IPersonalNoteAppService : IDisposable
    {
        Task<IEnumerable<PersonalNoteViewModel>> GetNotesByUser(Guid userId);
        Task<PersonalNoteViewModel> GetNoteById(Guid id);
        Task<bool> CreateNote(PersonalNoteViewModel note);
    }
}
