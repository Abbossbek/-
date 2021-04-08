
using System;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ПомощникПовара.Model;

namespace ПомощникПовара.DBContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("ChefHelperDB") 
        {
            Database.SetInitializer<DataBaseContext>(new CreateDatabaseIfNotExists<DataBaseContext>());
             Configuration.AutoDetectChangesEnabled = true;
        }
        public DbSet<Atribut> Atributs { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<AtributValuePair> AtributValuePairs { get; set; }

    }
}
