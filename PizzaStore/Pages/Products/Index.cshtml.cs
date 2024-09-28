using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Models;

namespace PizzaStore.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly PizzaStore.Data.PizzaContext _context;

        public IndexModel(PizzaStore.Data.PizzaContext context)
        {
            _context = context;
        }
        public IList<Models.Products> Products { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }
    }
}
