using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Models;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Repositories;
namespace Kvickly_Connect.Pages.Orders
{
    public class DeleteOrderModel : PageModel
    {
        [BindProperty]
        public Order Order { get; set; }
        private IOrderRepository catalog;
         
        public DeleteOrderModel(IOrderRepository repository)
        {
            catalog = repository;
        }
        public IActionResult OnGet(int id)
        {
            Order = catalog.GetOrder(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            catalog.DeleteOrder(Order);
            return RedirectToPage("/AdminControl/AdminAllOrders");
        }
    }
}
