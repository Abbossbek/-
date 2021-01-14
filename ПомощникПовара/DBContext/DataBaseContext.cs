using _1CMurabbiy.Model.Documents;
//using _1CMurabbiy.View.DocumentViews;
using _1CMurabbiy.Model.SpecialDbModel;
using Spravochniki;
using System;
using System.Data.Entity;
using System.Linq;
using _1CMurabbiy.Model.Tablitsi;
using _1CMurabbiy.Model.PlaniVidovRascheta;
using _1CMurabbiy.Model.PlanSchetov;
using _1CMurabbiy.Model.Spravochniki;
using System.ComponentModel.DataAnnotations;
using ПомощникПовара.Model;

namespace _1CMurabbiy.DBContext
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
