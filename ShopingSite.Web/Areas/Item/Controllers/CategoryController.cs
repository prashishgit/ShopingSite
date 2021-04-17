using ShopingSite.Web.Areas.Item.Model;
using ShopingSite.Web.Models.ViewModel;
using ShopingSite.Web.Utility;
using ShoppinSite.Database;
using ShoppinSite.Database.Entity.Item;
using ShoppinSite.Database.Enum;
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
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Item/Category
        public ActionResult Index()
        {
            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
            var categorList = _db.Category.Where(p => p.RecordStatus == RecordStatus.Active).ToList();
            var count = 0;
            foreach (var item in categorList)
            {
                categoryViewModels.Add(new CategoryViewModel()
                {
                    Id = item.Id,
                    SN = ++count,
                    Name = item.Name,
                    Description = item.Description

                });
            }
            return View(categoryViewModels);
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
                try
                {
                    Category category = new Category();
                    category.Id = Guid.NewGuid();
                    category.Name = categoryViewModel.Name;
                    category.Description = categoryViewModel.Description;
                    category.RecordStatus = RecordStatus.Active;
                    _db.Category.Add(category);
                    _db.SaveChangesAsync();
                    response.Success = true;
                    response.Message = MessageHandler.GetMessage(MessageStatus.Create, "Category", category.Name);
                }
                catch (Exception ex)
                {

                    response.Success = false;
                    response.Message = MessageHandler.GetMessage(MessageStatus.Error);
                }
            }
            else
            {
                response.Success = false;
                response.Message = string.Join(" </br> ", ModelState.Values
         .SelectMany(v => v.Errors)
         .Select(e => e.ErrorMessage));
            }
            return Json(response);
            
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id) 
        {
            var response = new JsonResponse { Success = true };
            try
            {
                var category = _db.Category.Where(p => p.Id == id).FirstOrDefault();
                category.RecordStatus = RecordStatus.Inactive;
                _db.SaveChanges();
                response.Success = true;
                response.Message = MessageHandler.GetMessage(MessageStatus.Delete, "Category", category.Name);
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = MessageHandler.GetMessage(MessageStatus.Error);
            }
            
            return Json(response);
        }
    }
}