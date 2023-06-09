using LMS.Application.Interfaces.Repositories;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repositories
{
    public class LookupDetailsRepository : ILookupDetailsRepository
    {
        private readonly IGenericRepositoryAsync<LookupDetail> _repository;

        public LookupDetailsRepository(IGenericRepositoryAsync<LookupDetail> repository)
        {
            _repository = repository;
        }
        public async Task<LookupDetail> AddAsync(LookupDetail entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<LookupDetail> AddOrUpdateAsync(LookupDetail entity)
        {
            return await _repository.AddOrUpdateAsync(entity);
        }

        public Task AddOrUpdateRangeAsync(List<LookupDetail> entities)
        {
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(List<LookupDetail> entities)
        {
            await _repository.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(LookupDetail entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<LookupDetail>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<LookupDetail> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<LookupDetail>> GetPagedRangeAsync(int page, int pageSize)
        {
            return await _repository.GetPagedRangeAsync(page, pageSize);
        }

        public async Task UpdateAsync(LookupDetail entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
