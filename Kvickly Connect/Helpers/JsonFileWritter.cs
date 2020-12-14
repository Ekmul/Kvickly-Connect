
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Models;
using Newtonsoft.Json;

namespace Kvickly_Connect.Helpers
{
    public static class JsonFileWritter
    {
        public static void WriteItemToJson(Dictionary<int, Item> ItemList, string JsonFileName)
        {
            string output = JsonConvert.SerializeObject(ItemList, Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }

        public static void WriteCustomerToJson(Dictionary<int, Customer> List1, string JsonFileName)
        {
            string output = JsonConvert.SerializeObject(List1, Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }

        public static void WriteOrderToJson(Dictionary<int, Order> Dict, string JsonFileName)
        {
            string output = JsonConvert.SerializeObject(Dict, Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
    }
}
