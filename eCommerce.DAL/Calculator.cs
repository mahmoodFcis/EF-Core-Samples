using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.DAL
{
    public class Calculator
    {
        public int Add(int x, int y)
        {
            if (x == 0 || y == 0)
                return -1;
            return x + y;
        }


       
    }
}
