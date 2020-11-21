using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Entity.ApplicationUser
{
    [Table("Users", Schema = "User")]
    public class User : IdentityUser<Guid, UserLogins, UserRoles, UserClaim>, IUser<Guid>
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
    }
}
