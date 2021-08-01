using BloodBank.Models.Model;
using BloodBank.Models.Model.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<BloodType> BloodTypes { get; set; }

        public DbSet<BloodAcceptor> BloodAcceptors { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<BloodDonar> BloodDonars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
