using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Models;
using Kvickly_Connect.Repositories;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Pages;

namespace Kvickly_Connect.Pages.Customers
{
    public class DeleteCustomerModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }
        private ICustomerRepository catalog;

        public DeleteCustomerModel(ICustomerRepository repository)
        {
            catalog = repository;
        }

        public IActionResult OnGet(int id)
        {
            Customer = catalog.GetCustomer(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            catalog.DeleteCustomer(Customer);
            return RedirectToPage("/Customers/AllCustomers");
        }
    }
}

