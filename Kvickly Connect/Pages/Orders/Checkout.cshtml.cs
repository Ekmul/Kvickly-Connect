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

namespace Kvickly_Connect.Pages.Orders
{
    public class CheckoutModel : PageModel
    {
        public ShoppingCartService cart;
        private IItemRepository repository;
        private ICustomerRepository crepository;

        public Dictionary<int, Item> list;
        public Customer Customer { get; set; }

        public CheckoutModel(ShoppingCartService cartService, IItemRepository repo, ICustomerRepository crepo)
        {
            cart = cartService;
            repository = repo;
            crepository = crepo;
        }

        public IActionResult OnGet(Customer cu)
        {
            Customer = cu;
            list = cart.GetOrderedItems();
            if (list?.Count() <= 0)
            {
                return Redirect("ShoppingCart");
            }
            return Page();
        }
    }
}
