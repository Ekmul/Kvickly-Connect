using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Repositories;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Pages;
using Kvickly_Connect.Models;

namespace Kvickly_Connect.Pages.Items
{
    public class AllItemsModel : PageModel
    {
        private IItemRepository catalog;

        public AllItemsModel(IItemRepository repository)
        {
            catalog = repository;
        }

        public Dictionary<int, Item> Items { get; private set; }
        [BindProperty]
        public Item Item { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IActionResult OnGet()
        {
            Items = catalog.GetAllItems();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Items = catalog.FilterItems(FilterCriteria);
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                catalog.AddItem(Item);
                Items = catalog.GetAllItems();
            }
            return Page();
        }
    }
}
