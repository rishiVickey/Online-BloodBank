using BloodBank.DataAccess.Data;
using BloodBank.DataAccess.specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.IRepository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        //method with eager loading;;
        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        //single entity with eager loading;;
        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

      
        public async Task AddEntity(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        }

        public  void Delete(int id)
        {
           var objFromDb = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(objFromDb);
        }

        public  void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }


        //specification applying method;;
        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.getquery(_context.Set<T>(), spec);
        }

        //synchronus method for geting entity with id
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
