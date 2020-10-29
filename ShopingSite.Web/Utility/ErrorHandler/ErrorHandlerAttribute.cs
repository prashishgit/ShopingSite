using ShopingSite.Infrastructure;
using ShopingSite.Repository;
using System;
using System.Web.Mvc;
using TMS.Database.Entity;

namespace ShopingSite.Web.Utility.ErrorHandler
{
    public class ErrorHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                var authenticationHelper = DependencyResolverExtensions.GetService<IAuthenticationRepository>(DependencyResolver.Current);

                ErrorLogger logger = new ErrorLogger()
                {
                    Id = Guid.NewGuid(),
                    ExceptionMessage = filterContext.Exception.Message,
                    ExceptionStackTrace = filterContext.Exception.StackTrace,
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    LogTime = DateTime.Now,
                    //NepaliLogTime = Calendar.EnglishToNepali(DateTime.Now).ToString(),
                    UserId = authenticationHelper.GetUserId()
                };

                var exceptionRepository = DependencyResolverExtensions.GetService<IErrorLoggerRepository>(DependencyResolver.Current);
                var unitOfWork = DependencyResolverExtensions.GetService<IUnitOfWork>(DependencyResolver.Current);
                exceptionRepository.Add(logger);
                unitOfWork.Commit();

                filterContext.ExceptionHandled = true;


                if (logger.ControllerName == "Account")
                {
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "/Views/Shared/Error.cshtml" //"/Views/Shared/PartialError.cshtml"
                    };
                }
                else
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new ViewResult
                        {
                            ViewName = "/Views/Shared/Error.cshtml" //"/Views/Shared/PartialError.cshtml"
                        };
                    }
                    else
                    {
                        filterContext.Result = new ViewResult
                        {
                            ViewName = "/Views/Shared/Error.cshtml"
                        };
                    }
                }
            }
        }
    }
}