using Data.Repository;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace OnlineShop.Pages.OrderManagement
{
    public class ErrorModel : PageModel
    {
        public Company? company;
        public void OnGet()
        {
            int CompanyId = int.Parse(Request.Query["CompanyId"]);
            company =new CompanyRepository().GetById(CompanyId);
        }
    }
}
