using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kvickly_Connect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Repositories;


namespace Kvickly_Connect
{
    public class CreateItemModel : PageModel
        {
        private IItemRepository Repository;

        public CreateItemModel(IItemRepository repo)
        {
            Repository = repo;
        }

        [BindProperty]
        public Item Item { get; set; }
        public Dictionary<int, Item> Items { get; set; }

        public void OnGet()
        {
            Items = Repository.GetAllItems();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Repository.AddItem(Item);
            Items = Repository.GetAllItems();
            return RedirectToPage("CreateItem");
        }
    }     
}
