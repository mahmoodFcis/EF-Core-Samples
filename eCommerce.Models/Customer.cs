﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Customer
    {
        public int Id { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        
        public string Phone { get; set; }

        public string Address { get; set; }

        public bool Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Image { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string UserName { get; set; }


    }
}
