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
    public class DeleteModel : PageModel
    {
        private readonly OnlineShop.Data.OnlineShopContext _context;

        public DeleteModel(OnlineShop.Data.OnlineShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Company Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FirstOrDefaultAsync(m => m.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }
            else
            {
                Company = company;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                Company = company;
                _context.Companies.Remove(Company);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
