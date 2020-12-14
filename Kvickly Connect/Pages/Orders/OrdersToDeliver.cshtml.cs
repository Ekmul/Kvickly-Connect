using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Models;
using Kvickly_Connect.Repositories;

namespace Kvickly_Connect.Pages.Orders
{
    public class OrdersToDeliverModel : PageModel
    {
        public Dictionary<int, Order> OrderList {  get; set; }

        private JsonOrderRepository customs;

        public Customer Customer { get;  set; }

        public Item Item { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public OrdersToDeliverModel(JsonOrderRepository repo)
        {
            customs = repo;
            OrderList = new Dictionary<int, Order>();
        }

        public IActionResult OnGet()
        {
            OrderList = customs.GetAllOrders();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                OrderList = customs.FilterOrders(FilterCriteria);
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
