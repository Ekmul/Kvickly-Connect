using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Kvickly_Connect.Models;
using Kvickly_Connect.Pages;
using Kvickly_Connect.Repositories;
using Kvickly_Connect.Interfaces;

namespace Kvickly_Connect.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        

        public Admin Admin { get; set; }
        

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            
        }

        public Dictionary<int, Order> orders { get; private set; }

        public void OnGet()
        {
        }
    }
}
