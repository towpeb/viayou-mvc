using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ViaYou.Domain;
using ViaYou.Domain.Travels;
using ViaYou.Domain.Users;

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
        public DbSet<Testimonial> Testimonials { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries{ get; set; }
    }
}
