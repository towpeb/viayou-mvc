using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Data.Properties;
using ViaYou.Domain;

namespace ViaYou.Data.Migrations.Seeds
{
    public class CitySeed : BaseSeed
    {
        public static bool CanExecute(ViaYouDataContext context)
        {
            return context.Countries.Any() && !context.Cities.Any();
        }

        public static void Seed(ViaYouDataContext context)
        {
            if(!CanExecute(context))
                return;
            foreach (var line in ParseCsv(Resources.city))
            {
                var cityCode = line[0];
                var cityName = line[1];
                var countryCode = line[2];
                var country = context.Countries.First(c => c.Code == countryCode);
                context.Cities.Add(new City(cityName, cityCode, country));
            }
        }
    }
}
