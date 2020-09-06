using ShopingSite.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Database.Entity;

namespace ShopingSite.Repository
{
    public class ErrorLoggerRepository : RepositoryBase<ErrorLogger>, IErrorLoggerRepository
    {
        public ErrorLoggerRepository(IDatabaseFactory dataBaseFactory) :
            base(dataBaseFactory)
        {

        }
    }

    public interface IErrorLoggerRepository : IRepository<ErrorLogger>
    {


    }
}
