using BloodBank.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.IRepository
{
   public interface IAcceptorRepository:IRepository<BloodAcceptor>
    {
        void Update(BloodAcceptor entity);
    }
}
