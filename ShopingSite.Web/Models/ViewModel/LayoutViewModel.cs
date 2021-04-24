using ShopingSite.Web.Areas.Item.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopingSite.Web.Models.ViewModel
{
    public class LayoutViewModel
    {
        public LayoutViewModel() 
        {
            this.CategoryListVM = new List<CategoryViewModel>();
        }
        public List<CategoryViewModel> CategoryListVM { get; set; }
    }
    
}