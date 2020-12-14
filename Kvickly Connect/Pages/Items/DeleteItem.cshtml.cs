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
    public class DeleteItemModel : PageModel
    {
        [BindProperty]
        public Item Item { get; set; }
        private IItemRepository catalog;
        public DeleteItemModel(IItemRepository repository)
        {
            catalog = repository;
        }

        public IActionResult OnGet(int id)
        {
            Item = catalog.GetItem(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            catalog.DeleteItem(Item);
            return RedirectToPage("AdminItems");
        }
    }
}
