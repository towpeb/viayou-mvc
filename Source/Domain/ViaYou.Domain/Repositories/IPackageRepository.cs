using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaYou.Domain.Repositories
{
    public interface IPackageRepository
    {
        Package GetById(int id);
        void Add(Package package);
        IQueryable<Package> GetAll();
        void Delete(int id);
    }
}
