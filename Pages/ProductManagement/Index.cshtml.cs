using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Domain.Entities;
using Data.Repository;

namespace OnlineShop.Pages.ProductManagement
{
    public class IndexModel : PageModel
    {
        private readonly OnlineShopContext _context;

        public IndexModel(OnlineShopContext context)
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
