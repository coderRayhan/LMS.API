using LMS.Application.Interfaces.Repositories;
using LMS.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private ILookupRepository _lookupRepository;
        private IUnitOfWork _unitOfWork;
        public LookupController(ILookupRepository repository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _lookupRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> Get(int page = 1, int pageSize = 10)
        {
            if(page != 0 && pageSize != 0)
            {
                var list = await _lookupRepository.GetPagedRangeAsync(page, pageSize);
                return Ok(list);
            }
            else
            {
                return Ok(await _lookupRepository.GetAllAsync());
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _lookupRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Lookup lookup, CancellationToken cancellationToken)
        {
            try
            {
                await _lookupRepository.AddAsync(lookup);
                await _unitOfWork.Commit(cancellationToken);
                return Created("/api/lookup/GetById/" + lookup.Id, lookup);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(int id, Lookup lookup, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _lookupRepository.GetByIdAsync(id);
                if(entity == null)
                {
                    return NotFound(String.Format("Id {0} not found", id));
                }
                entity.Code = lookup.Code;
                entity.Name = lookup.Name;
                entity.NameBN = lookup.NameBN;
                entity.Status = lookup.Status;
                entity.ParentId = lookup.ParentId;
                entity.LastModified = lookup.LastModified;
                entity.LastModifiedBy = lookup.LastModifiedBy;
                await _lookupRepository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _lookupRepository.GetByIdAsync(id);
                if(entity == null)
                {
                    return NotFound(String.Format("Id {0} not found", id));
                }
                await _lookupRepository.DeleteAsync(entity);
                var affectedRow = await _unitOfWork.Commit(cancellationToken);
                return Ok($"{affectedRow} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
