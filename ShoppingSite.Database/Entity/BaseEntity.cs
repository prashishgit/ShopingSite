using ShoppingSite.Database.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingSite.Database.Entity
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
        [Key]
        public Guid Id { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
