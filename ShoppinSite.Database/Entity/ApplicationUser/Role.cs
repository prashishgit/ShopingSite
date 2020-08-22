using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Entity.ApplicationUser
{
    [Table("Roles", Schema = "User")]
    public class Role 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public int Order { get; set; }
    }
}
