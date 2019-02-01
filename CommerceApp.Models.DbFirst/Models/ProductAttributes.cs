using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommerceApp.Models.DbFirst.Models
{
    public class ProductAttributes
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ISOCode { get; set; }
        
        
        public Products Product { get; set; }
    }
}
