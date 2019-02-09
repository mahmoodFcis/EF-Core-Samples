using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Models
{
    public class CountriesServices
    {
        public List<string> GetAll()
        {
            return new List<string>() { "Egypt", "USA", "KSA" };
        }
    }
}
