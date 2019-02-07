using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Models
{
    public class Countries
    {
        public List<string> GetCountries()
        {
            return new List<string>() { "Egypt", "USA" };
        }
    }
}
