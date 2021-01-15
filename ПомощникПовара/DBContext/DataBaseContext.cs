
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
        public DbSet<Product> Products { get; set; }
        public DbSet<Extra> Extras { get; set; }

    }
}
