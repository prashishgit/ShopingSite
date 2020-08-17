using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Entity.ApplicationUser
{
    [Table("RoleDetails", Schema = "User")]
    public class RoleDetail : BaseEntity
    {
        public string MenuName { get; set; }
        public bool CanView { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanRecommend { get; set; }
        public bool CanCheck { get; set; }
        public bool CanApprove { get; set; }
        public bool CanDownload { get; set; }
        public bool CanReject { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
