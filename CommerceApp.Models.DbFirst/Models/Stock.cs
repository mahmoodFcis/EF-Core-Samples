using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models.DbFirst.Models
{
    public class Stock
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }
        public List<ProductStock> Products { get; set; }
    }
}
