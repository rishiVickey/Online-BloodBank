using BloodBank.DataAccess.specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.IRepository
{
  public  interface IRepository<T> where T:class
    {
        Task<IReadOnlyList<T>> GetAll();

        Task<T> GetByIdAsync(int id);

        T GetById(int id);

        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task AddEntity(T entity);

        void Delete(int id);

        void DeleteEntity(T entity);


        
    }
}
