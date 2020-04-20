using ShoppingSite.Database.Entity.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace ShoppingSite.Database
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = 200;
        }
        public DbSet<Item> Item { get; set; }
    }
    
}
