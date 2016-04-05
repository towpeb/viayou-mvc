using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaYou.Domain.Repositories
{
    interface IHTMLContentRepository
    {
        HTMLContents GetById(int id);
        void Add(HTMLContents testimonial);
        IQueryable<HTMLContents> GetAll();
    }
}
