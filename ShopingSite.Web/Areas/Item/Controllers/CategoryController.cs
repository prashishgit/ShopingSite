using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingSite.Web.Areas.Item.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Item/Category
        public ActionResult Index()
        {
            return View();
        }
    }
}