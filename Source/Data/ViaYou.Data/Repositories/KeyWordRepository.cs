using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
    public class KeyWordRepository : BaseRepository, IKeyWordRepository
    {
        public void Add(KeyWord keyword)
        {
            Context.KeyWords.Add(keyword);
        }

        public void Delete(int id)
        {
            var container = new KeyWord() { Id = id };
            Context.KeyWords.Attach(container);
            Context.KeyWords.Remove(container);
        }

        public IQueryable<KeyWord> GetAll()
        {
            return Context.KeyWords;
        }

        public KeyWord GetById(int id)
        {
            return Context.KeyWords.FirstOrDefault();
        }
    }
}
