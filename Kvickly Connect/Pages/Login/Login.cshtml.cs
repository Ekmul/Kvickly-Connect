using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Helpers;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Pages;
using Kvickly_Connect.Models;
using Kvickly_Connect.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Kvickly_Connect.Services;

namespace Kvickly_Connect.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public Customer Customer { get; set; }
        public JsonCustomerRepository customs;
        public LoginModel(JsonCustomerRepository repo)
        {
            customs = repo;
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
            ViewData["Confirmation"] = "Confirmed";
            return RedirectToPage("/Index");
        }
    }
}
