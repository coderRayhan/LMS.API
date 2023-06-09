using AutoMapper;
using LMS.Application.Interfaces.Repositories;
using LMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.LookupDetails.Commands
{
    public record CreateLookupDetailsCommand(int Id, int LookupId, string Code, string Name, string NameBN, string Description, int ParentId, string Status = "Active") : IRequest<int>;
    public record CreateLookupDetailsCommandHandler(ILookupDetailsRepository _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateLookupDetailsCommand, int>
    {
        public async Task<int> Handle(CreateLookupDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedEntity = _mapper.Map<LookupDetail>(request);
                await _repository.AddAsync(mappedEntity);
                await _unitOfWork.Commit(cancellationToken);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
