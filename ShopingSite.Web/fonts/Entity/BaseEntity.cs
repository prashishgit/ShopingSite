using ShoppinSite.Database.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Entity
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime CreatedDate{ get; set; }
        public bool? IsDeleted { get; set; }

    }
}
