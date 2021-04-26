using ShoppinSite.Database.Entity.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Entity.Product
{
    [Table("Products", Schema = "Item")]
    public class Product:BaseEntity
    {
        public Guid CategoryId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
