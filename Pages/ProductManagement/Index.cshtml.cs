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

namespace OnlineShop.Pages.ProductManagement
{
    public class IndexModel : PageModel
    {
        private readonly OnlineShop.Data.OnlineShopContext _context;

        public IndexModel(OnlineShop.Data.OnlineShopContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        public Dictionary<int,Company> Company { get;set; }=new Dictionary<int,Company>();

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
            CompanyRepository repo = new CompanyRepository();
            foreach (var item in Product)
            {
                Company.Add(item.CompanyId, repo.GetById(item.CompanyId)); 
            }
        }
    }
}
