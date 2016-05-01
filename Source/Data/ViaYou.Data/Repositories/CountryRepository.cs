using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
   public class CountryRepository : BaseRepository,ICountryRepository
    {
        public void Add(Country country)
        {
            Context.Countries.Add(country);
        }

        public IQueryable<Country> GetAll()
        {
            return Context.Countries;
        }

       public void Delete(int id)
       {
           var country = new Country() {Id = id};
           Context.Countries.Attach(country);
           Context.Countries.Remove(country);
       }

       public Country GetById(int id)
        {
            return Context.Countries
                            .Where(c=>c.Id == id)
                            .Include(x=>x.Cities)
                            .FirstOrDefault();
        }
    }
}
