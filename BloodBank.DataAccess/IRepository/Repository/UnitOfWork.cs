using BloodBank.DataAccess.Data;
using BloodBank.Models.Model.Authentication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BloodBank.DataAccess.IRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            donar = new DonarRepository(_db);
            Acceptor = new AcceptorRepository(_db);
            
        }

        public IDonarRepository donar { get; private set; }

        public IAcceptorRepository Acceptor { get; private set; }

        

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
