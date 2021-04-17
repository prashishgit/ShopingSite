using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Entity.Item
{
    [Table("Category", Schema = "Item")]
    public class Category : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
