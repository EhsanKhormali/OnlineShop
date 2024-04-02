using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Data.Context;
using Domain.Entities;
using Data.Repository;
using Azure.Core;

namespace OnlineShop.Pages.OrderManagement
{
    public class CreateModel : PageModel
    {
        private readonly OnlineShopContext _context;
        public Product Product { get; set; }
        public Company Company { get; set; }
        public int _id = 0;

        public CreateModel(OnlineShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                _id = (int)id;
                Product = new ProductRepository().GetById(_id);
                Company = new CompanyRepository().GetById(Product.CompanyId);
            }

            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _id=  int.Parse(Request.Form["sth"]);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Product product=new ProductRepository().GetById(_id);
            Company company=new CompanyRepository().GetById(product.CompanyId);
            Order.OrderDate = DateTime.Now;
            Order.ProductId=_id;
            if (DateTime.Now.TimeOfDay-company.OperationStartTime.Value.TimeOfDay>= TimeSpan.Zero && DateTime.Now.TimeOfDay - company.OperationEndTime.Value.TimeOfDay <= TimeSpan.Zero)
            {
                _context.Orders.Add(Order);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            else
            {
                return RedirectToRoute("Error", new { company.CompanyId });
            }
            
        }
    }
}
