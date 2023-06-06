using AutoMapper;
using LMS.Application.Features.Lookups.Queries;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Mappings
{
    public class LookupProfile : Profile
    {
        public LookupProfile()
        {
            CreateMap<Lookup, LookupDropdownResponse>().ReverseMap();
        }
    }
}
