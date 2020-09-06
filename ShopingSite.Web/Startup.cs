using Microsoft.Owin;
using Owin;
using Hangfire;
using System;


[assembly: OwinStartupAttribute(typeof(ShopingSite.Web.Startup))]
namespace ShopingSite.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
    // Use connection string name defined in `web.config` or `app.config`
    .UseSqlServerStorage("DefaultConnection");

            // BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget!"));
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring jobs!"), Cron.Minutely);

        }
    }
}
