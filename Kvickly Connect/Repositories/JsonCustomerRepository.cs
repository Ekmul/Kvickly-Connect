using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Models;
using Kvickly_Connect.Helpers;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Pages;
using Newtonsoft.Json;


namespace Kvickly_Connect.Repositories
{
    public class JsonCustomerRepository : ICustomerRepository
    {
        string JsonFileName = @"C:\Users\Emil Glæsner\Downloads\Kvickly Connect\Kvickly Connect\Kvickly Connect\Data\jsonUsers.json";

        public Dictionary<int, Customer> GetAllCustomers()
        {
            return JsonFileReader.ReadCustomerJson(JsonFileName);
        }
        public void AddCustomer(Customer customer)
        {
            Dictionary<int, Customer> customers = GetAllCustomers();
            customers.Add(customer.CustomerId, customer);
            JsonFileWritter.WriteCustomerToJson(customers, JsonFileName);
        }

        public Customer GetCustomer(int customerId)
        {
            Dictionary<int, Customer> customers = GetAllCustomers();
            Customer foundCostumer = customers[customerId];
            return foundCostumer;
        }

        public void EditCustomer(Customer customer)
        {
            Dictionary<int, Customer> customers = GetAllCustomers();
            Customer foundCustomer = customers[customer.CustomerId];
            foundCustomer.CustomerId = customer.CustomerId;
            foundCustomer.FirstName = customer.FirstName;
            foundCustomer.LastName = customer.LastName;
            foundCustomer.Email = customer.Email;
            foundCustomer.ZipCode = customer.ZipCode;
            foundCustomer.Address = customer.Address;
            JsonFileWritter.WriteCustomerToJson(customers, JsonFileName);
        }

        public void DeleteCustomer(Customer customer)
        {
            Dictionary<int, Customer> Customers = GetAllCustomers();
            foreach (var c in Customers.Values)
            {
                if (c.CustomerId == customer.CustomerId)
                {
                    Customers.Remove(c.CustomerId);
                }
            }
            JsonFileWritter.WriteCustomerToJson(Customers, JsonFileName);
        }

        public Dictionary<int, Customer> FilterCustomers(string criteria)
        {
            Dictionary<int, Customer> customers = GetAllCustomers();
            Dictionary<int, Customer> myCustomers = new Dictionary<int, Customer>();
            if(criteria != null)
            {
                foreach (var c in customers.Values)
                {
                    if(c.FirstName.StartsWith(criteria))
                    {
                        myCustomers.Add(c.CustomerId, c);
                    }
                }
            }
            return myCustomers;
        }
    }
}
