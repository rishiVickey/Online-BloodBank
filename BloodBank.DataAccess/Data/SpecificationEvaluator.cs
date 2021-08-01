using BloodBank.DataAccess.specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.Data
{
  public  class SpecificationEvaluator<T> where T:class
    {
        public static IQueryable<T> getquery(IQueryable<T> inputquery,ISpecification<T> spec)
        {
            var query = inputquery;

            if(spec.Criteria!= null)
            {
                query = query.Where(spec.Criteria);
            }
            if(spec.orderBy != null)
            {
                query = query.OrderBy(spec.orderBy);
            }
            if(spec.orederByDescending != null)
            {
                query = query.OrderByDescending(spec.orederByDescending);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
