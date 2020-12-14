using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Models;

namespace Kvickly_Connect.Pages.AdminControl
{
    public class StatisticsModel : PageModel
    {
        private IOrderRepository orepos;
        public StatisticsModel(IOrderRepository orepository) 
        {
            orepos = orepository;
        }
        public void OnGet()
        {
            
        }
        public int howManyHide() 
        {
            return orepos.OrdersHidden();
        }
        public int howManyShow()
        {
            return orepos.OrdersShown();
        }

        public int ZipCodeCount(string zip) 
        {
            return orepos.ZipCodeCount(zip);
        }

    }
}
