using ShopingSite.Web.Areas.Item.Model;
using ShopingSite.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CategoryViewModel categoryViewModel)
        {
            var response = new JsonResponse { Success = true };
            if (ModelState.IsValid)
            {

            }
            return Json(response);
            
        }
    }
}