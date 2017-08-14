namespace Secom.Smp.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Secom.Smp.Data.Models.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;  //Ä¬ÈÏÎª false
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Secom.Smp.Data.Models.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Customers.AddOrUpdate(
  p => p.Name,
  new Customer { Name = "Andrew Peters", Address = "hunan", CreateTime = DateTime.Now },
  new Customer { Name = "Brice Lambson", Address = "guangdong", CreateTime = DateTime.Now },
  new Customer { Name = "Brice Lambson1", Address = "guangdong", CreateTime = DateTime.Now },
  new Customer { Name = "Brice Lambson2", Address = "guangdong", CreateTime = DateTime.Now },
  new Customer { Name = "Brice Lambson3", Address = "guangdong", CreateTime = DateTime.Now },
  new Customer { Name = "Brice Lambson4", Address = "guangdong", CreateTime = DateTime.Now },
  new Customer { Name = "Brice Lambson5", Address = "guangdong", CreateTime = DateTime.Now },
  new Customer { Name = "Brice Lambson6", Address = "guangdong", CreateTime = DateTime.Now },
  new Customer { Name = "Brice Lambson7", Address = "guangdong", CreateTime = DateTime.Now },
  new Customer { Name = "Rowan Miller", Address = "jiangxi", CreateTime = DateTime.Now }
);
        }
    }
}
