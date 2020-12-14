using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Models;
using Kvickly_Connect.Pages;

namespace Kvickly_Connect.Interfaces
{
    public interface IItemRepository
    {
        Dictionary<int, Item> GetAllItems();

        void AddItem(Item Item);

        Item GetItem(int id);

        Dictionary<int, Item> FilterItems(string criteria);

        void UpdateItem(Item Item);

        void DeleteItem(Item Item);
    }
}