using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingSite.Database.Entity.Product
{
    [Table("Item", Schema = "Product")]
    public class Item:BaseEntity
    {
        [Required()]
        [StringLength(50)]
        public string Name { get; set; }
        [Required()]
        public decimal Price { get; set; }
        public string Description{ get; set; }
    }
}
