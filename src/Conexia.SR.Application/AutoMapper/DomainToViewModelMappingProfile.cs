using AutoMapper;
using Conexia.SR.Application.ViewModels.PersonalNotes;
using Conexia.SR.Domain.PersonalNoteRoot;
namespace Conexia.SR.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PersonalNote, PersonalNoteViewModel>();
        }
    }
}
