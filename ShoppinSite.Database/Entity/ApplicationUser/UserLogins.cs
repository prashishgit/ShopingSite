using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Entity.ApplicationUser
{
    [Table("Group", Schema = "User")]
    public class UserLogins : BaseEntity
    {
        public string Name { get; set; }
        public int? Order { get; set; }
    }
}
