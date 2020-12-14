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
        private static int internalCounters = 0;
        private static bool firstRun = true;
        private static JsonOrderRepository repo = new JsonOrderRepository();


        public DateTime dateTime { get; set; }
        public Customer customer { get; set; }
        public bool OrderHidden { get; set; }


        public Order() 
        {
            OrderHidden = false;
            if (firstRun)
            {
                firstRun = false;
                Dictionary<int, Order> allOrders = repo.GetAllOrders();
                if (allOrders.Count != 0)
                {
                    internalCounters = allOrders.Max(c => c.Key);
                }
            }
            if (OrderID == 0) 
            {
                OrderID = ++internalCounters;
            }
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
