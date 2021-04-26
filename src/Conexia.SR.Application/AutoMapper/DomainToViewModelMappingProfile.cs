using AutoMapper;
using Conexia.SR.Application.ViewModels.PersonalNotes;
using Conexia.SR.Domain.PersonalNoteRoot;
using System;
using System.Collections.Generic;
using System.Text;

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
