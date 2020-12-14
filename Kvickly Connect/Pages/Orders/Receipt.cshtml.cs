using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Repositories;
using Kvickly_Connect.Services;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Models;

namespace Kvickly_Connect.Pages.Orders
{
    public class ReceiptModel : PageModel
    {
        public ShoppingCartService cart;
        private ICustomerRepository crepository;
        private IOrderRepository orepository;
        private JsonOrderRepository orderRepo;
        [BindProperty]
        public Order Order { get; set; }

        public Item Item { get; set; }

        public Dictionary<int, Item> list;
        public Customer Customer { get; set; }

        public ReceiptModel(ShoppingCartService cartService, JsonOrderRepository repository, ICustomerRepository crepo, IOrderRepository orepo)
        {
            cart = cartService;
            orderRepo = repository;
            crepository = crepo;
            orepository = orepo;
        }

        public IActionResult OnGet(int cu, int oId)
        {
            Order = orepository.GetOrder(oId);
            Customer = crepository.GetCustomer(cu);
            list = Order.Items;

            //Hopefully works?
            orepository.setOrderHidden(Order.OrderID);
            
            return Page();
        }
    }
}
