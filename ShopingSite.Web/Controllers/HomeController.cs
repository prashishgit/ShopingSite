using ShopingSite.Web.Areas.Item.Model;

using ShopingSite.Web.Models.ViewModel;
using ShoppinSite.Database;
using ShoppinSite.Database.Entity.Item;
using ShoppinSite.Database.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingSite.Web.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            LayoutViewModel layoutViewModel = new LayoutViewModel();
            List<Category> category = _db.Category.Where(p => p.RecordStatus == RecordStatus.Active).ToList();
            List<CategoryViewModel> categoryViewModelList = new List<CategoryViewModel>();
            foreach (var item in category)
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel();
                categoryViewModel.Id = item.Id;
                categoryViewModel.Name = item.Name;
                categoryViewModelList.Add(categoryViewModel);
            }
            layoutViewModel.CategoryListVM.AddRange(categoryViewModelList);
            return View(layoutViewModel);
        }
        public ActionResult AdminIndex()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}