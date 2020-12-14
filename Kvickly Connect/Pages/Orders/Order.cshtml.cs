using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Models;
using Kvickly_Connect.Repositories;
using Kvickly_Connect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Interfaces;

namespace Kvickly_Connect
{
    public class OrderModel : PageModel
    {
        private JsonOrderRepository repo;
        private ICustomerRepository crepo;
        private ShoppingCartService cart;
        [BindProperty(SupportsGet = true)]
        public int SpecificCustomerId { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public Order Order { get; set; }

        public OrderModel(JsonOrderRepository repository, ShoppingCartService cartService, ICustomerRepository crepository) 
        {
            repo = repository;
            cart = cartService;
            crepo = crepository;
        }

        public IActionResult OnGet() 
        {
            return Page();
        }

        public IActionResult OnPost(int SpecificCustomerId) 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Customer = crepo.GetCustomer(SpecificCustomerId);
            Order order = new Order();
            order.customer = Customer;
            order.Items = cart.GetOrderedItems();
            order.dateTime = DateTime.Now;
            repo.AddOrder(order);
            return RedirectToPage("/Orders/Checkout", Customer);
        }
    }
}