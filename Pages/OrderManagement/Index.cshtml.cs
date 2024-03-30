using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Data.Repository;
using OnlineShop.Models;

namespace OnlineShop.Pages.OrderManagement
{
    public class IndexModel : PageModel
    {
        private readonly OnlineShop.Data.OnlineShopContext _context;
        public Dictionary<int, Product> Products { get; set; }    

        public IndexModel(OnlineShop.Data.OnlineShopContext context)
        {
            _context = context;
        }

        public IList<Order> Orders { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Products = new Dictionary<int, Product>();
            Orders = await _context.Orders.ToListAsync();
            ProductRepository repo = new ProductRepository();
            foreach (var item in Orders)
            {
                Products.Add(item.OrderId, repo.GetById(item.ProductId));
            }
        }
    }
}
