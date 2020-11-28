using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Entity.ApplicationUser
{
    [Table("Users", Schema = "User")]
    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>, IUser<Guid>
    {
        public User()
        {
            CreatedDate = DateTime.Now;
        }
        public static object Identity { get; internal set; }
        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]{2,15}$",
            ErrorMessage = "First Name,Please enter valid name")]
        [Required()]
        [StringLength(35)]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [StringLength(35)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]{2,15}$",
            ErrorMessage = "Last Name,Please enter valid name")]
        [StringLength(35)]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        [StringLength(105)]
        public string FullName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string TitleOfCourtesy { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(35)]
        public string State { get; set; }
        [StringLength(35)]
        public string District { get; set; }
        [StringLength(35)]
        [RegularExpression(@"^[A-Za-z1-9'][A-Za-z0-9' ,_-]{3,30}$", ErrorMessage = "Please enter Last Name between 3 to 30 characters.")]
        [Display(Name = "VDC/Municipality")]
        public string VDCMunicipality { get; set; }
        [StringLength(35)]
        [RegularExpression(@"^[A-Za-z1-9'][A-Za-z0-9' /,_-]{3,30}$", ErrorMessage = "Please enter Local Address between 3 to 30 characters.")]
        [Display(Name = "Address")]
        public string LocalAddress { get; set; }

        public DateTime CreatedDate { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, Guid> manager)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            //userIdentity.AddClaim(new Claim(ClaimTypes.Sid, this.PersonId.ToString()));
            //userIdentity.AddClaim(new Claim(ClaimTypes.GroupSid, this.TenantId.ToString()));
            //userIdentity.AddClaim(new Claim("Tenant", this.TenantId.ToString()));
            //userIdentity.AddClaim(new Claim("OfficeId", this.OfficeId.ToString()));
            //userIdentity.AddClaim(new Claim("IsMasterUser", this.IsMasterUser.ToString()));
            //userIdentity.AddClaim(new Claim("IsAdminUser", this.IsAdminUser.ToString()));
            foreach (var item in this.Claims)
            {
                userIdentity.AddClaim(new Claim(item.ClaimType, item.ClaimValue));
            }
            return userIdentity;
        }
    }
}
