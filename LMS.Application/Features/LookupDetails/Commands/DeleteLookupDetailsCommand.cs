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
    public record DeleteLookupDetailsCommand(int Id) : IRequest<string>;
    public record DeleteLookupDetailsCommandHandler(ILookupDetailsRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteLookupDetailsCommand, string>
    {
        public async Task<string> Handle(DeleteLookupDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity == null)
                    return "Data not found";
                await _repository.DeleteAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
