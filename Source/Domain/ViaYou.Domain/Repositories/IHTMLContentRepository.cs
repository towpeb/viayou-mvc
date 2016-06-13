using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaYou.Domain.Repositories
{
    public interface IHTMLContentRepository
    {
        HTMLContent GetById(int id);
        void Add(HTMLContent content);
        IQueryable<HTMLContent> GetAll();
        void Delete(int id);
    }
}
