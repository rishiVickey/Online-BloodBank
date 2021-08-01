using BloodBank.Models.Model.Authentication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.IRepository
{
   public interface IUnitOfWork
    {
         public IDonarRepository donar { get; }

        public IAcceptorRepository Acceptor { get; }

        Task Save();
    }
}
