using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entities;
using Data.Repository;
using Data.Context;
using Microsoft.EntityFrameworkCore;


namespace OnlineShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly OnlineShopContext _context;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _context=new OnlineShopContext();
        }
        public IList<Product> Product { get; set; } = default!;
        public Dictionary<int, Company> Company { get; set; } = new Dictionary<int, Company>();
        public void OnGet()
        {
            Product = _context.Products.ToList();
            CompanyRepository repo = new CompanyRepository();
            foreach (var item in Product)
            {
                Company.Add(item.CompanyId, repo.GetById(item.CompanyId));
            }
        }

    }
}
