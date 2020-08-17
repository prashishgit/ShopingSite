using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Entity.ApplicationUser
{
    [Table("UserGroups", Schema = "User")]
    public class UserGroup : BaseEntity
    {
        public Guid GroupId { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
    }
}
