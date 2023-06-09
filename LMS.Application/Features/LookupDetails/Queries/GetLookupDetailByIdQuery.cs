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
    public record GetLookupDetailByIdQuery(int Id) : IRequest<GetLookupDetailResponse>;
    public record GetLookupDetailByIdQueryHandler(ILookupDetailsRepository _repository, IMapper _mapper) : IRequestHandler<GetLookupDetailByIdQuery, GetLookupDetailResponse>
    {
        public async Task<GetLookupDetailResponse> Handle(GetLookupDetailByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);
                var mappedEntity = _mapper.Map<GetLookupDetailResponse>(entity);
                return mappedEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
