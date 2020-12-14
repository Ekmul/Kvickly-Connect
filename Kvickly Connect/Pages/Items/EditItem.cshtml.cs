using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Models;
using Kvickly_Connect.Pages;

namespace Kvickly_Connect.Pages.Items
{
    public class EditItemModel : PageModel
    {
        [BindProperty]
        public Item Item { get; set; }

        private IItemRepository catalog;

        public EditItemModel(IItemRepository repository)
        {
            catalog = repository;
        }
        public void OnGet(int id)
        {
            Item = catalog.GetItem(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.UpdateItem(Item);
            return RedirectToPage("AllItems");
        }
    }
}
