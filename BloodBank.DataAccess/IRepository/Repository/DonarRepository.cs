using BloodBank.DataAccess.Data;
using BloodBank.Models.Model;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.IRepository.Repository
{
    public class DonarRepository : Repository<BloodDonar>, IDonarRepository
    {
        private readonly ApplicationDbContext _context;

        public DonarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(BloodDonar entity)
        {
            var objFromDb =await _context.BloodDonars.FindAsync(entity.Id);

            if(objFromDb != null)
            {
                objFromDb.Name = entity.Name;
                objFromDb.Email = entity.Email;
                objFromDb.PhoneNumber = entity.PhoneNumber;
                objFromDb.Age = entity.Age;
                objFromDb.GenderId = entity.GenderId;
                objFromDb.City = entity.City;
                objFromDb.State = entity.State;
                objFromDb.PinCode = entity.PinCode;
                objFromDb.BloodTypeId = entity.BloodTypeId;
                objFromDb.LastDonated = entity.LastDonated;
            }
        }
    }
}
