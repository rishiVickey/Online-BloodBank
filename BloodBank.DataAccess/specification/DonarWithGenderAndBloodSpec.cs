using BloodBank.Models.Model;

namespace BloodBank.DataAccess.specification
{
    public class DonarWithGenderAndBloodSpec : BaseSpecification<BloodDonar>
    {
        public DonarWithGenderAndBloodSpec(string sort)
        {
            AddInclude(x => x.BloodType);
            AddInclude(x => x.Gender);
            OrderBy(x => x.Name);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "ageAsc":
                        OrderBy(x => x.Age);
                        break;
                    case "ageDesc":
                        OrderByDesc(x => x.Age);
                        break;
                    default:
                        OrderBy(x => x.Name);
                        break;
                }
            }
        }

        public DonarWithGenderAndBloodSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.BloodType);
            AddInclude(x => x.Gender);
        }
    }
}
