using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
    public class PackageRepository : BaseRepository, IPackageRepository
    {
        public void Add(Package package)
        {
            Context.Package.Add(package);
        }

        public void Delete(int id)
        {
            var container = new Package() { Id = id };
            Context.Package.Attach(container);
            Context.Package.Remove(container);
        }

        public IQueryable<Package> GetAll()
        {
            return Context.Package;
        }

        public Package GetById(int id)
        {
            return Context.Package
               .Where(c => c.Id == id)
               .FirstOrDefault();
        }
    }
}
