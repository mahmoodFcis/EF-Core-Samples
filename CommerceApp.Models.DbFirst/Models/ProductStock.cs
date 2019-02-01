using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommerceApp.Models.DbFirst.Models
{
    public class ProductStock
    {
       
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products Product { get; set; }
       
        public int StockId { get; set; }
        [ForeignKey("StockId")]
        public Stock Stock { get; set; }
        public int Quantity { get; set; }

    }
}
