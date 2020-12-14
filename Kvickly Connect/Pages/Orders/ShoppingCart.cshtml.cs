using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Models;
using Kvickly_Connect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Repositories;

namespace Kvickly_Connect.Pages.Orders
{
    public class ShoppingCartModel : PageModel
    {
        public ShoppingCartService CartService { get; }
        
        public Dictionary<int, Item> OrderedItems { get; set; }

        private IItemRepository repo;

        public Item Item { get; set; }

        public ShoppingCartModel(IItemRepository repository, ShoppingCartService cart)
        {
            repo = repository;
            CartService = cart;
            OrderedItems = new Dictionary<int, Item>();
        }

        public IActionResult OnGet(int id)
        {
            if (id != 0) 
            {
                Item item = repo.GetItem(id);
                CartService.Add(item);

                OrderedItems = CartService.GetOrderedItems();
            }
            return Page();
        }


        public IActionResult OnPostDelete(int id)
        {
            CartService.RemoveItem(id);
            OrderedItems = CartService.GetOrderedItems();
            return Page();
        }
    }
}
