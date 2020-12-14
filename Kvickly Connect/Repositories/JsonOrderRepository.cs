
using Kvickly_Connect.Models;
using Kvickly_Connect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Helpers;

namespace Kvickly_Connect.Repositories
{
    public class JsonOrderRepository : IOrderRepository
    {
        string JsonFileName = @"C:\Users\Emil Glæsner\Downloads\Kvickly Connect\Kvickly Connect\Kvickly Connect\Data\jsonOrder.json";

        public Dictionary<int, Order> GetAllOrders()
        {
            return JsonFileReader.ReadOrderJson(JsonFileName);
        }

        public void AddOrder(Order anOrder)
        {
            Dictionary<int, Order> Orders = GetAllOrders();
            Orders.Add(anOrder.OrderID, anOrder);
            JsonFileWritter.WriteOrderToJson(Orders, JsonFileName);
        }

        public Order GetOrder(int id)
        {
            Dictionary<int, Order> orders = GetAllOrders();
            Order foundOrder = orders[id];
            return foundOrder;
        }

        public void UpdateOrder(Order anOrder)
        {
            // not implemented yet
        }

        public void DeleteOrder(Order order)
        {
            Dictionary<int, Order> Orders = GetAllOrders();
            foreach (var o in Orders.Values)
            {
                if (o.OrderID == order.OrderID)
                {
                    Orders.Remove(o.OrderID);
                }
            }
            JsonFileWritter.WriteOrderToJson(Orders, JsonFileName);
        }

        public Dictionary<int, Order> FilterOrders(string criteria)
        {
            Dictionary<int, Order> orders = GetAllOrders();
            Dictionary<int, Order> myOrders = new Dictionary<int, Order>();
            if (criteria != null)
            {
                foreach (var p in orders.Values)
                {
                    if (p.customer.ZipCode.Contains(criteria))
                    {
                        myOrders.Add(p.OrderID, p);
                    }
                }
            }
            return myOrders;
        }
        public void setOrderHidden(int orderID) 
        {
            Dictionary<int, Order> Orders = GetAllOrders();
            foreach (Order order in Orders.Values) 
            {
                if (order.OrderID == orderID) 
                {
                    order.OrderHidden = true;
                }
            }
            JsonFileWritter.WriteOrderToJson(Orders, JsonFileName);
        }
        public int OrdersHidden() 
        {
            Dictionary<int, Order> Orders = GetAllOrders();
            int HideNumber = 0;
            foreach (var AnOrder in Orders.Values)
            {
                if (AnOrder.OrderHidden)
                {
                    HideNumber++;
                }
            }
            return HideNumber;
        }
        public int OrdersShown()
        {
            Dictionary<int, Order> Orders = GetAllOrders();
            int ShowNumber = 0;
            foreach (var AnOrder in Orders.Values)
            {
                if (!AnOrder.OrderHidden)
                {
                    ShowNumber++;
                }
            }
            return ShowNumber;
        }

        public int ZipCodeCount(string zip)
        {
            Dictionary<int, Order> Orders = GetAllOrders();
            int zipNumbers = 0;
            foreach(var zipCode in Orders)
            {
                if  (zipCode.Value.customer.ZipCode == zip)
                {
                    zipNumbers++;
                }
            }
            return zipNumbers;
        }
    }
}
