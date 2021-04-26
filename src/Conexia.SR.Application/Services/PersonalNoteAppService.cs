using AutoMapper;
using Conexia.SR.Application.Interfaces;
using Conexia.SR.Application.ViewModels.PersonalNotes;
using Conexia.SR.Domain.PersonalNoteRoot;
using Conexia.SR.Domain.PersonalNoteRoot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conexia.SR.Application.Services
{
    public class PersonalNoteAppService : IPersonalNoteAppService
    {
        private readonly IPersonalNoteRepository _personalNoteRepository;
        private readonly IMapper _mapper;

        public PersonalNoteAppService(IPersonalNoteRepository personalNoteRepository, IMapper mapper)
        {
            _personalNoteRepository = personalNoteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonalNoteViewModel>> GetNotesByUser(Guid userId)
        {
            var notes = _mapper.Map<IEnumerable<PersonalNoteViewModel>>(await _personalNoteRepository.GetNotesByUser(userId));
            foreach (var note in notes)
            {
                note.Title = DecodeData(note.Title);
                note.Body = DecodeData(note.Body);
            }

            return notes;
        }

        public async Task<PersonalNoteViewModel> GetNoteById(Guid id)
        {
            var note = _mapper.Map<PersonalNoteViewModel>(await _personalNoteRepository.GetById(id));
            note.Title = DecodeData(note.Title);
            note.Body = DecodeData(note.Body);

            return note;
        }

        public async Task<bool> CreateNote(PersonalNoteViewModel noteViewModel)
        {
            var note = _mapper.Map<PersonalNote>(noteViewModel);

            note.ChangeTitle(EncodeData(noteViewModel.Title));
            note.ChangeBody(EncodeData(noteViewModel.Body));

            _personalNoteRepository.Create(note);

            return await _personalNoteRepository.UnitOfWork.Commit();
        }

        private string EncodeData(string text)
        {
            var bytes = Encoding.ASCII.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }

        private string DecodeData(string encryptedText)
        {
            var bytes = Convert.FromBase64String(encryptedText);
            return Encoding.ASCII.GetString(bytes);
        }

        public void Dispose()
        {
            _personalNoteRepository?.Dispose();
        }
    }
}
