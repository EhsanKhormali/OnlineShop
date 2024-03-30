using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Pages.CompanyManagment
{
    public class IndexModel : PageModel
    {
        private readonly OnlineShop.Data.OnlineShopContext _context;

        public IndexModel(OnlineShop.Data.OnlineShopContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Company = await _context.Companies.ToListAsync();
        }
    }
}
