using Kvickly_Connect.Models;
using Kvickly_Connect.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kvickly_Connect.Services
{
    public class ShoppingCartService
    {
        Dictionary<int, Item> _cartItems;

        public ShoppingCartService()
        {
            _cartItems = new Dictionary<int, Item>();
        }

        public void Add(Item Item)
        {
            if (!_cartItems.ContainsKey(Item.ItemID)) 
            {
                _cartItems.Add(Item.ItemID, Item);
            }
        }

        public Dictionary<int, Item> GetOrderedItems()
        {
            return _cartItems;
        }

        public void RemoveItem(int id)
        {
            foreach (var Item in _cartItems)
            {
                if (Item.Value.ItemID == id)
                {
                    _cartItems.Remove(Item.Value.ItemID);
                    break;
                }
            }
        }
        public void RemoveAllItems()
        {
            _cartItems.Clear();
        }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0.00M;

            foreach (var v in _cartItems)
            {
                totalPrice = totalPrice + (decimal)v.Value.Price;
            }
            return totalPrice;
        }
    }
}
