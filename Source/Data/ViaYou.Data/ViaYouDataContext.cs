using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using ViaYou.Domain.Users;
using System.Data.Entity;
using ViaYou.Domain.Travels;
using ViaYou.Domain;

namespace ViaYou.Data
{
    public class ViaYouDataContext : IdentityDbContext<ApplicationUser>
    {
        public ViaYouDataContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ViaYouDataContext Create()
        {
            return new ViaYouDataContext();
        }

        public DbSet<Travel> Travels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Advice> Advices { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Container> Containers { get; set; }

        public System.Data.Entity.DbSet<ViaYou.Domain.City> Cities { get; set; }

        public DbSet<ViaYou.Domain.Country> Countries{ get; set; }

        public System.Data.Entity.DbSet<ViaYou.Domain.Users.ApplicationUser> ApplicationUsers { get; set; }
    }
}
