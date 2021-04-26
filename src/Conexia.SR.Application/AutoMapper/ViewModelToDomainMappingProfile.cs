using AutoMapper;
using Conexia.SR.Application.ViewModels.PersonalNotes;
using Conexia.SR.Domain.PersonalNoteRoot;

namespace Conexia.SR.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonalNoteViewModel, PersonalNote>().ConstructUsing(p =>
                new PersonalNote(p.Title, p.Body, p.CreatedAt, p.UserId));
        }
    }
}
