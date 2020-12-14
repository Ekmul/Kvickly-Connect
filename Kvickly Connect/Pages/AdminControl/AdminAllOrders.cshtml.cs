using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Models;
using Kvickly_Connect.Repositories;
using Kvickly_Connect.Services;
using Kvickly_Connect.Interfaces;
namespace Kvickly_Connect.Pages.AdminControl
{
    public class AdminAllOrdersModel : PageModel
    {
        private IOrderRepository catalog;
        public Dictionary<int, Customer> Customers;

        public AdminAllOrdersModel(IOrderRepository repository)
        {
            catalog = repository;
        }

        public Dictionary<int, Order> Orders { get; private set; }
        [BindProperty]
        public Order Order { get; set; }

        public IActionResult OnGet()
        {
            Orders = catalog.GetAllOrders();
            return Page();
        }
    }
}

