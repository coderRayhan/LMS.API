using AutoMapper;
using LMS.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.LookupDetails.Queries
{
    public record GetAllLookupDetailsQuery : IRequest<List<GetLookupDetailResponse>>;
    public record GetAllLookupDetailsQueryHandler(ILookupDetailsRepository _repository, IMapper _mapper) : IRequestHandler<GetAllLookupDetailsQuery, List<GetLookupDetailResponse>>
    {
        public async Task<List<GetLookupDetailResponse>> Handle(GetAllLookupDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _repository.GetAllAsync();
                var mappedList = _mapper.Map<List<GetLookupDetailResponse>>(list);
                return mappedList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
