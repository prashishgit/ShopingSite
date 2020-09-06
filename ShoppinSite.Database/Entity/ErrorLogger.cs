using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using TMS.Helper;

namespace TMS.Database.Entity
{
    [Table("ErrorLoggers", Schema = "Base")]
    public class ErrorLogger
    {
        public ErrorLogger()
        {
            CreatedDate = DateTime.Now;
            //CreatedNepaliDate = Calender.EnglishToNepali(DateTime.Now).ToString();
        }
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string ControllerName { get; set; }
        [StringLength(2000)]
        public string ExceptionMessage { get; set; }
        [StringLength(4000)]
        public string ExceptionStackTrace { get; set; }
        public DateTime LogTime { get; set; }
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string CreatedNepaliDate { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string NepaliLogTime { get; set; }
    }
}
