using ViaYou.Domain.Enums;
using ViaYou.Domain.Travels;

namespace ViaYou.Data.Migrations
{
    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Domain;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ViaYouDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ViaYou.Data.ViaYouDataContext";
        }

        protected override void Seed(ViaYouDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Containers.AddOrUpdate(
              p => p.Name,
              new Container { Name = "Basic", Measure = Measure.cm},
              new Container { Name = "Medium", Measure = Measure.dm },
              new Container { Name = "Large", Measure = Measure.m }
            );
            //
            //context.Travels.AddOrUpdate(new Travel
            //{
            //    Date = DateTime.Today,
            //    Grade = 4.5m,
            //    Customer = new Domain.Users.ApplicationUser { FirstName = "Gareth", UserName = "G.B",LastName="Bale",MiddleName="11" },
            //    Traveler = new Domain.Users.ApplicationUser { FirstName = "Luca", UserName = "L.M",LastName="Modric",MiddleName="19" },
            //    CityOrigin = new Domain.City { Name = "La Havana", Code = "10400", Country = new Domain.Country { Name = "Cuba" } },
            //    CityDestination = new Domain.City { Name = "Madrid", Code = "1000", Country = new Domain.Country { Name = "Cuba" } },
            //    Packages = new List<Package>(),

            //});
            context.Countries.AddOrUpdate(
                new Country
                {
                    Name = "Cuba",
                    Code = "10400",
                    Cities = new List<City>(),
                });
            context.Countries.AddOrUpdate(new Country { Name = "España", Code = "10000", Cities = new List<City>() });
            base.Seed(context);

            context.Cities.AddOrUpdate(new City { Name = "La Havana", Code = "10400" });
        }
    }
}
