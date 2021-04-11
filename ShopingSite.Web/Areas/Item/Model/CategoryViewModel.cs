using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopingSite.Web.Areas.Item.Model
{
    public class CategoryViewModel
    {
        public int SN { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}