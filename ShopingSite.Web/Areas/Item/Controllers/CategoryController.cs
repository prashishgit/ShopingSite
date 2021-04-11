﻿using ShopingSite.Web.Areas.Item.Model;
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
                try
                {
                    Category category = new Category();
                    category.Id = Guid.NewGuid();
                    category.Name = categoryViewModel.Name;
                    category.Description = categoryViewModel.Description;
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
    }
}