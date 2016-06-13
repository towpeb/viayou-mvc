using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
    public class HTMLContentRepository : BaseRepository, IHTMLContentRepository
    {
        public void Add(HTMLContent content)
        {
            Context.HTMLContent.Add(content);
        }

        public void Delete(int id)
        {
            var container = new HTMLContent() { Id = id };
            Context.HTMLContent.Attach(container);
            Context.HTMLContent.Remove(container);
        }

        public IQueryable<HTMLContent> GetAll()
        {
            return Context.HTMLContent;

        }

        public HTMLContent GetById(int id)
        {
            return Context.HTMLContent.FirstOrDefault();
        }
    }
}
