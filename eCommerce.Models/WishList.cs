using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Models.Catalog;

namespace ECommerce.Models
{
    public class WishList
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product  Product { get; set; }




    }
}
