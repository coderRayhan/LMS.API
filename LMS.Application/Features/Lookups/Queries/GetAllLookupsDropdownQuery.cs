using AutoMapper;
using LMS.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Lookups.Queries
{
    public record GetAllLookupsDropdownQuery : IRequest<List<LookupDropdownResponse>> { }
    public record GetAllLookupsDropdownQueryHandler(ILookupRepository _repository, IMapper _mapper) : IRequestHandler<GetAllLookupsDropdownQuery, List<LookupDropdownResponse>>
    {
        public async Task<List<LookupDropdownResponse>> Handle(GetAllLookupsDropdownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _repository.GetAllAsync();
                var mappedList = _mapper.Map<List<LookupDropdownResponse>>(list);
                return mappedList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
