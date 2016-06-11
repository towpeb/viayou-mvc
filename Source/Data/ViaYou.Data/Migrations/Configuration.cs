using System.Data.SqlClient;
using System.Diagnostics;
using ViaYou.Data.Migrations.Seeds;
using ViaYou.Data.Properties;
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
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ViaYou.Data.ViaYouDataContext";
        }

        protected override void Seed(ViaYouDataContext context)
        {
            CountrySeed.Seed(context);
            context.SaveChanges();

            CitySeed.Seed(context);
            context.SaveChanges();
            context.Users.AddOrUpdate(new Domain.Users.ApplicationUser
            {
                FirstName = "Wilber",
                LastName = "Ulloa",
                Email = "wuj120398gmail.com",
                UserName = "Wlloa",
                EmailConfirmed = true
            });

            context.Users.AddOrUpdate(new Domain.Users.ApplicationUser
            {
                FirstName = "Yassiel",
                LastName = "Oliva",
                Email = "yoliva@gmail.com",
                UserName = "Batman"
            });
            context.Users.AddOrUpdate(new Domain.Users.ApplicationUser
            {
                FirstName = "Roly",
                LastName = "Cruz",
                Email = "judi@gmail.com",
                UserName = "Judi"
            });

            base.Seed(context);
        }
    }
}
