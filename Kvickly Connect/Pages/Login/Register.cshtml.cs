using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Models;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Repositories;

namespace Kvickly_Connect.Pages.Login
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }

        private ICustomerRepository customs;

        public RegisterModel(JsonCustomerRepository repository)
        {
            customs = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            customs.AddCustomer(Customer);
            return RedirectToPage("/Index");
        }
    }
}
