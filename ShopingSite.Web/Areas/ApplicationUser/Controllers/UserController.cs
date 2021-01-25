using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopingSite.Web.Areas.ApplicationUser.Controllers
{
    public class UserController : Controller
    {
        // GET: ApplicationUser/User
        public async Task<ActionResult> Index()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> AdminIndex()
        {
            return View();
        }
        public async Task<ActionResult> Create()
        {
            return View();
        }
    }
}