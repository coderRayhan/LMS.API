using LMS.Application.Interfaces.Repositories;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        IGenericRepositoryAsync<Lookup> _repository;
        public LookupRepository(IGenericRepositoryAsync<Lookup> repository)
        {
            _repository = repository;
        }
        public async Task<Lookup> AddAsync(Lookup entity)
        {
            return await _repository.AddAsync(entity);
        }

        public Task<Lookup> AddOrUpdateAsync(Lookup entity)
        {
            throw new NotImplementedException();
        }

        public Task AddOrUpdateRangeAsync(List<Lookup> entities)
        {
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(List<Lookup> entities)
        {
            await _repository.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(Lookup entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Lookup>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Lookup> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Lookup>> GetPagedRangeAsync(int page, int pageSize)
        {
            return await _repository.GetPagedRangeAsync(page, pageSize);
        }

        public async Task UpdateAsync(Lookup entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
