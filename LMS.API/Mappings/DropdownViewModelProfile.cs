using AutoMapper;
using LMS.API.Models;
using LMS.Application.Features.Lookups.Queries;

namespace LMS.API.Mappings
{
    public class DropdownViewModelProfile : Profile
    {
        public DropdownViewModelProfile()
        {
            CreateMap<DropdownViewModel, LookupDropdownResponse>().ReverseMap();
        }
    }
}
