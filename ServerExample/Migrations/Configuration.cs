using ServerExample.Dal;
using System;
using System.Data.Entity.Migrations;

namespace ServerExample.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("System.Data.SQLite.EF6", new System.Data.SQLite.EF6.Migrations.SQLiteMigrationSqlGenerator());
        }

        protected override void Seed(DatabaseContext context)
        {
            var now = DateTime.UtcNow;
            DbSetMigrationsExtensions.AddOrUpdate(context.Contracts, new[] {
                new Contract() { ContractId = 1, CreationDate = now.AddDays(-14), UpdateDate = now.AddDays(-7) },
                new Contract() { ContractId = 2, CreationDate = now.AddDays(-90), UpdateDate = now.AddDays(-61) }});
        }
    }
}
