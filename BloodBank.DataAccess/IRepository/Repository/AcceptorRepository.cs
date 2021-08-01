using BloodBank.DataAccess.Data;
using BloodBank.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.IRepository.Repository
{
    public class AcceptorRepository : Repository<BloodAcceptor>, IAcceptorRepository
    {
        private readonly ApplicationDbContext _context;

        public AcceptorRepository(ApplicationDbContext context) : base(context)
        {
           _context = context;
        }

        public void Update(BloodAcceptor entity)
        {
            var obj = _context.BloodAcceptors.SingleOrDefault(x => x.Id == entity.Id);
            if(obj != null)
            {
                _context.BloodAcceptors.Update(entity);
            }
            
        }
    }
}
