using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Models;

namespace Kvickly_Connect.Pages.Customers
{
    public class EditCustomerModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }
        private ICustomerRepository catalog;

        public EditCustomerModel(ICustomerRepository repository)
        {
            catalog = repository;
        }
        public void OnGet(int id)
        {
            Customer = catalog.GetCustomer(id);
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            catalog.EditCustomer(Customer);
            return RedirectToPage("AllCustomers");
        }
    }
}
