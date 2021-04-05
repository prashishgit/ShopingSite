using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopingSite.Web.Models.ViewModel
{
    public class JsonResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public string FilePath { get; set; }
    }
}