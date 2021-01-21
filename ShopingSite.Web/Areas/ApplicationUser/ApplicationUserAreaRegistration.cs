using System.Web.Mvc;

namespace ShopingSite.Web.Areas.ApplicationUser
{
    public class ApplicationUserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ApplicationUser";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ApplicationUser_default",
                "ApplicationUser/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}