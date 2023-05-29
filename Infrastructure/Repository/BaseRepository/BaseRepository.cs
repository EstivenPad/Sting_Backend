using Infrastructure.Data.Context;
using Infrastructure.Interfaces.BaseRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DatabaseContext _context;
        
        public BaseRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                var isSaved = _context.SaveChanges() > 0;

                if (!isSaved)
                    throw new Exception("Entity couldn't be saved");

                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id) ?? throw new Exception("There isn't an entity with this id number");

                _context.Set<T>().Remove(entity);

                var isDeleted = _context.SaveChanges() > 0;

                if (!isDeleted)
                    throw new Exception("Entity couldn't be deleted");

                return isDeleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                var result = await _context.Set<T>().FindAsync(id) ?? throw new Exception("There is not entity with this id number");

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> Update(T entity, int id)
        {
            try
            {
                var oldEntity = await _context.Set<T>().FindAsync(id) ?? throw new Exception("Entity couldn't be found");
                
                _context.ChangeTracker.Clear();
                _context.Set<T>().Update(entity);

                var isSaved = _context.SaveChanges() > 0;

                if (!isSaved)
                    throw new Exception("Employee couldn't be updated");

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
