using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Models;
using Kvickly_Connect.Interfaces;

namespace Kvickly_Connect.Pages.Login
{
    public class AllCustomersModel : PageModel
    {
        private ICustomerRepository catalog;

        public AllCustomersModel(ICustomerRepository repository)
        {
            catalog = repository;
        }

        public Dictionary<int, Customer> Customers { get; private set; }
        [BindProperty]
        public Customer Customer { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IActionResult OnGet()
        {
            Customers = catalog.GetAllCustomers();
            if(!string.IsNullOrEmpty(FilterCriteria))
            {
                Customers = catalog.FilterCustomers(FilterCriteria);
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                catalog.AddCustomer(Customer);
                Customers = catalog.GetAllCustomers();
            }
            return Page();
        }
    }
}
