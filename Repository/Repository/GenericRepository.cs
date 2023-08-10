using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using SampleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StudendDbcontext context;

        public GenericRepository(StudendDbcontext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsynch(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public Task<TResult> AddAsynch<Tsource, TResult>(Tsource tsource)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public Task<List<TResult>> GetAllAsync<TResult>()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(int? id)
        {
            var result = await context.Set<T>().FindAsync(id);
            if(result == null)
            {
                throw new DirectoryNotFoundException();
            }
            return result;
        }

        public Task<TResult> GetAsync<TResult>(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int? id, T entity)
        {
            var result = await context.Set<T>().FindAsync(id);
            if (result == null)
            {
                throw new DirectoryNotFoundException();
            }

            if (entity != null)
            {
                context.Entry(result).CurrentValues.SetValues(entity);
                context.Entry(result).State = EntityState.Modified;
            }

            await context.SaveChangesAsync();
        }


    }
}

