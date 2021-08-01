using BloodBank.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.IRepository
{
   public interface IDonarRepository:IRepository<BloodDonar>
    {
        Task Update(BloodDonar entity);
    }
}
