using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaYou.Domain.Repositories
{
    interface IHTMLContentRepository
    {
        HTMLContent GetById(int id);
        void Add(HTMLContent testimonial);
        IQueryable<HTMLContent> GetAll();
    }
}
