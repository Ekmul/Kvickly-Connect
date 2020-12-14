using Kvickly_Connect.Models;
using Kvickly_Connect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Helpers;

namespace Kvickly_Connect.Repositories
{
    public class JsonItemRepository : IItemRepository
    {
        string JsonFileName = @"C:\Users\Emil Glæsner\Downloads\Kvickly Connect\Kvickly Connect\Kvickly Connect\Data\jsonItems.json";

        public Dictionary<int, Item> GetAllItems()
        {
            return JsonFileReader.ReadItemJson(JsonFileName);
        }

        public void AddItem(Item Item)
        {
            Dictionary<int, Item> Items = GetAllItems();
            if (!Items.ContainsKey(Item.ItemID)) {
                Items.Add(Item.ItemID, Item);
            }
            JsonFileWritter.WriteItemToJson(Items, JsonFileName);
        }

        public Item GetItem(int id)
        {
            foreach (var p in GetAllItems())
            {
                if (p.Key == id)
                    return p.Value;
            }
            return new Item();
        }

        public void UpdateItem(Item Item)
        {
            Dictionary<int, Item> Items = GetAllItems();

            foreach (var p in Items.Values)
            {
                if (p.ItemID == Item.ItemID)
                {
                    p.Name = Item.Name;
                    p.ImagePath = Item.ImagePath;
                    p.Price = Item.Price;
                    p.Description = Item.Description;
                }
            }
            JsonFileWritter.WriteItemToJson(Items, JsonFileName);
        }

        public void DeleteItem(Item Item)
        {
            Dictionary<int, Item> Items = GetAllItems();

            foreach (var p in Items.Values)
            {
                if (p.ItemID == Item.ItemID)
                {
                    Items.Remove(p.ItemID);
                }
            }
            JsonFileWritter.WriteItemToJson(Items, JsonFileName);
        }

        public Dictionary<int, Item> FilterItems(string criteria)
        {
            Dictionary<int, Item> items = GetAllItems();
            Dictionary<int, Item> myItems = new Dictionary<int, Item>();
            if (criteria != null)
            {
                foreach (var p in items.Values)
                {
                    if (p.Name.ToLower().StartsWith(criteria.ToLower()))
                    {
                        myItems.Add(p.ItemID, p);
                    }
                }
            }
            return myItems;
        }
    }
}
