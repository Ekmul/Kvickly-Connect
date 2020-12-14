using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Models;

namespace Kvickly_Connect.Interfaces
{
    public interface IOrderRepository
    {
        Dictionary<int, Order> GetAllOrders();

        Dictionary<int, Order> FilterOrders(string criteria);

        public void AddOrder(Order anOrder);
        public Order GetOrder(int id);

        void DeleteOrder(Order id);
        public void setOrderHidden(int orderID);
        public int OrdersHidden();
        public int OrdersShown();
        public int ZipCodeCount(string zip);
    }
}
