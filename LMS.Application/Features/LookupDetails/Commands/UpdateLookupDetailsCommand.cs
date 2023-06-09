using AutoMapper;
using LMS.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.LookupDetails.Commands
{
    public record UpdateLookupDetailsCommand(int Id, int LookupId, string Code, string Name, string NameBN, string Description, int ParentId) : IRequest<string>;
    public record UpdateLookupDetailsCommandHandler(ILookupDetailsRepository _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdateLookupDetailsCommand, string>
    {
        public async Task<string> Handle(UpdateLookupDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity is null)
                    return "Data not found";
                entity.LookupId = request.LookupId == 0 ? entity.LookupId : request.LookupId;
                entity.Code = request.Code ?? entity.Code;
                entity.Name = request.Name ?? entity.Name;
                entity.NameBN = request.NameBN ?? entity.NameBN;
                entity.Description = request.Description ?? entity.Description;
                entity.ParentId = request.ParentId == 0 ? entity.ParentId : request.ParentId;
                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
