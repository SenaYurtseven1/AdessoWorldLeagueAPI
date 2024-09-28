using AdessoWorldLeagueAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.DataAccess.Repositories
{
    public abstract class BaseRepository<T> : IRepositorycs<T> where T : class
    {
        protected List<T> _entites;

        public BaseRepository()
        {
            _entites = new List<T>();
        }

        public async Task AddAsync(T entity)
        {
            await Task.Run(() => _entites.Add(entity));
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                await Task.Run(() => _entites.Remove(entity));
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(_entites);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.FromResult(_entites.FirstOrDefault(entity =>
            (int)entity.GetType().GetProperty("Id").GetValue(entity) == id));
        }

        public async Task UpdateAsync(T entity)
        {
            var existingValue = await GetByIdAsync((int)entity.GetType().GetProperty("Id").GetValue(entity));
            if (existingValue != null)
            {
                var index = _entites.IndexOf(existingValue);
                _entites[index] = entity;
            }
        }
    }
}
