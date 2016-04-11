using ViaYou.Domain.Enums;
using ViaYou.Domain.Travels;

namespace ViaYou.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
        }
    }
}
