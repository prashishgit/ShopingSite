using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Entity.Bannner
{
    [Table("Banners", Schema = "Main")]
    public class Banner
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Photo { get; set; }
        public string Title { get; set; }
        public string ProductName { get; set; }
    }
}
