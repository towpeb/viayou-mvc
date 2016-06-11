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
    public class CountrySeed : BaseSeed
    {
        public static bool CanExecute(ViaYouDataContext context)
        {
            return !context.Countries.Any();
        }

        public static void Seed(ViaYouDataContext context)
        {
            if(!CanExecute(context))
                return;

            foreach (var line in ParseCsv(Resources.country))
            {
                var countryCode = line[0];
                var countryName = line[1];
                context.Countries.Add(new Country(countryName, countryCode));
            }
        }
    }
}
