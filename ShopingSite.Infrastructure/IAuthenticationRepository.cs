using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web;

namespace ShopingSite.Infrastructure
{
    public class AuthenticationRepository : IAuthenticationRepository
    {

        public Guid GetUserId()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            if (userId != null)
                return Guid.Parse(userId);
            else return Guid.Empty;
        }
    }

    public interface IAuthenticationRepository
    {
        Guid GetUserId();
    }
}
