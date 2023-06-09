using AutoMapper;
using LMS.Application.Features.LookupDetails.Commands;
using LMS.Application.Features.LookupDetails.Queries;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Mappings
{
    public class LookupDetailProfile : Profile
    {
        public LookupDetailProfile()
        {
            CreateMap<LookupDetail, CreateLookupDetailsCommand>().ReverseMap();
            CreateMap<LookupDetail, GetLookupDetailResponse>().ReverseMap();
        }
    }
}
