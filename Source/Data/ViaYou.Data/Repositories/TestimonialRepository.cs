using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
    public class TestimonialRepository : BaseRepository, ITestimonialRepository
    {
        public void Add(Testimonial testimonial)
        {
            Context.Testimonials.Add(testimonial);
        }

        public void Delete(int id)
        {
            var container = new Testimonial() { Id = id };
            Context.Testimonials.Attach(container);
            Context.Testimonials.Remove(container);
        }

        public IQueryable<Testimonial> GetAll()
        {
            return Context.Testimonials;
        }

        public Testimonial GetById(int id)
        {
            return Context.Testimonials.FirstOrDefault();
        }
    }
}
