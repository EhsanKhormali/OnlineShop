using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data;
using Data.Repository;
using Data.Context;
using Domain.Entities;

namespace OnlineShop.Pages.ProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly OnlineShopContext _context;
        public List<Company> CompanyList;
        ProductRepository ProductRepository;
        public SelectList SelectList { get; set; }
        [BindProperty]
        public int selectedReport { get; set; }

        public CreateModel(OnlineShopContext context)
        {
            _context = context;
            CompanyList=new CompanyRepository().GetAll().ToList();
            ProductRepository=new ProductRepository();
            SelectList = new SelectList(CompanyList, "CompanyId", "Name");
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            Product.CompanyId = int.Parse(Request.Form["company_select"]);
            ModelState.ClearValidationState("Product.Company");
            if (!TryValidateModel(CompanyList[0], "Product.Company"))
            {
                return Page();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ProductRepository.Add(Product);

            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
