using Microsoft.AspNet.Identity.EntityFramework;
using ShoppinSite.Database.Entity.ApplicationUser;
using ShoppinSite.Database.Entity.Bannner;
using ShoppinSite.Database.Entity.Item;
using ShoppinSite.Database.Entity.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Database.Entity;

namespace ShoppinSite.Database
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = 200;
        }
        public DbSet<Product> Product { get; set; }
        //public DbSet<Group> Group { get; set; }
        //public DbSet<Role> Role { get; set; }
        public DbSet<RoleDetail> RoleDetail { get; set; }
        //public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Banner> Banner{ get; set; }
        public DbSet<ErrorLogger> ErrorLogger { get; set; }
    }
}
