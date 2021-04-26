using Conexia.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conexia.SR.Domain.PersonalNoteRoot.Interfaces
{
    public interface IPersonalNoteRepository : IRepository<PersonalNote>
    {
        Task<IEnumerable<PersonalNote>> GetNotesByUser(Guid userId);
    }
}
