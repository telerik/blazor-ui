using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BlazorInRazorPages.Models;

namespace BlazorInRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Customer> BlazorGridData { get; set; }

        public void OnGet()
        {
            BlazorGridData = Enumerable.Range(1, 200).Select(x => new Customer { Id = x, Name = "Name " + x });
        }
    }
}
