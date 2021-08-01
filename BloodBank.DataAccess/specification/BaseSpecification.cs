using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T,bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T,object>>>();

        public Expression<Func<T, object>> orderBy { get; private set; }

        public Expression<Func<T, object>> orederByDescending { get; private set; }

        protected void AddInclude(Expression<Func<T,object>> includeQuery)
        {
            Includes.Add(includeQuery);
        }

        protected void OrderBy(Expression<Func<T,object>> orderByExpression)
        {
            orderBy = orderByExpression;
        }

        protected void OrderByDesc(Expression<Func<T,object>> orderByDescExpression)
        {
            orederByDescending = orderByDescExpression;
        }
    }
}
