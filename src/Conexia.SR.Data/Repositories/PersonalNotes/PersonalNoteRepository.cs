using Conexia.SR.Data.Repositories.Base;
using Conexia.SR.Domain.PersonalNoteRoot;
using Conexia.SR.Domain.PersonalNoteRoot.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conexia.SR.Data.Repositories.PersonalNotes
{
    public class PersonalNoteRepository : Repository<PersonalNote>, IPersonalNoteRepository
    {
        public PersonalNoteRepository(SRContext context) : base(context)
        {

        }

        public async Task<IEnumerable<PersonalNote>> GetNotesByUser(Guid userId)
        {
            return await DbSet.AsNoTracking().Where(e => e.UserId == userId).ToListAsync();
        }
    }
}
