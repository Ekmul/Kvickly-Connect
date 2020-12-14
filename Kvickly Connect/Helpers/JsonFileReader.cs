using Kvickly_Connect.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kvickly_Connect.Helpers
{
    public class JsonFileReader
    {
        public static Dictionary<int, Customer> ReadCustomerJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonConvert.DeserializeObject<Dictionary<int, Customer>>(jsonString);
        }

        public static Dictionary<int, Item> ReadItemJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonConvert.DeserializeObject<Dictionary<int, Item>>(jsonString);
        }

        public static Dictionary<int, Order> ReadOrderJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonConvert.DeserializeObject<Dictionary<int, Order>>(jsonString);
        }
    }
}
