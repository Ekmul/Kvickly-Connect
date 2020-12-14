using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Repositories;

namespace Kvickly_Connect.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int CustomerId { get; set; }


        private static Random rnd = new Random();


        public Customer()
        {
            CustomerId = rnd.Next(1, 999999);
        }
    }
}
