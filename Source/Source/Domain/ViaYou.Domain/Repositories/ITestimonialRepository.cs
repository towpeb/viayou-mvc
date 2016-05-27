using System.Linq;

namespace ViaYou.Domain.Repositories
{
    public interface ITestimonialRepository
    {
        Testimonial GetById(int id);
        void Add(Testimonial testimonial);
        IQueryable<Testimonial> GetAll();
    }
}
