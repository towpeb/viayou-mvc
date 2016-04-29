using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaYou.Domain.Repositories
{
    public interface IKeyWordRepository
    {
        KeyWord GetById(int id);
        void Add(KeyWord keyword);
        IQueryable<KeyWord> GetAll();
        void Delete(int id);
    }
}
