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
    public class User : BaseEntity
    {
        public User()
        {
            CreatedDate = DateTime.Now;
        }
        public static object Identity { get; internal set; }
        [Display(Name = "First Name")]
        [StringLength(35)]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [StringLength(35)]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(35)]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        [StringLength(35)]
        public string FullName { get; set; }
        [Column(TypeName ="VARCHAR")]
        [StringLength(10)]
        public string TitleOfCourtesy { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        public string District { get; set; }
        public string VDCMunicipalaity { get; set; }
        [StringLength(35)]
        [Display(Name ="Address")]
        public string LocalAddress { get; set; }
        [StringLength(35)]
        [Display(Name = "Telephone No")]
        public string TelephoneNo { get; set; }
    }
}
