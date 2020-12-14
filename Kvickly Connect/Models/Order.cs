using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Repositories;

namespace Kvickly_Connect.Models
{
    public class Order
    {
        public int OrderID;
        public Dictionary<int, Item> Items;
        private static Random rnd = new Random();

        public DateTime dateTime { get; set; }
        public Customer customer { get; set; }
        public bool OrderHidden { get; set; }

        public Order() 
        {
            OrderHidden = false;
            OrderID = rnd.Next(1, 999999);
        }

        public double TotalPrice()
        {
            double price = 0;

            foreach (var item in Items)
            {
                
                price += item.Value.Price;
            }

            return price;
        }
    }
}
