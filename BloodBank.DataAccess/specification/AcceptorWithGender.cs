using BloodBank.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.specification
{
    public class AcceptorWithGender : BaseSpecification<BloodAcceptor>
    {
        public AcceptorWithGender()
        {
            AddInclude(x => x.Gender);
            OrderBy(x => x.Name);
            OrderBy(x => x.Age);
        }

        public AcceptorWithGender(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Gender);
        }
    }
}
