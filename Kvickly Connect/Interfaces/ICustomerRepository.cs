
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Models;
using Kvickly_Connect.Pages;

namespace Kvickly_Connect.Interfaces
{
    public interface ICustomerRepository
    {
        Dictionary<int, Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        Customer GetCustomer(int customerId);
        void EditCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Dictionary<int, Customer> FilterCustomers(string criteria);
    }
}
