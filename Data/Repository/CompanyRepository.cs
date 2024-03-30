using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineShop.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private OnlineShopContext _context;

        public CompanyRepository()
        {
        }

        public void Add(Company company)
        {
            _context = new OnlineShopContext();
            _context.Add(company);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context = new OnlineShopContext();
            _context.Companies.Where(c => c.CompanyId == id).ExecuteDelete();
        }

        public IList<Company> GetAll()
        {
            _context = new OnlineShopContext();
            if (_context.Companies != null)
            {
                return _context.Companies.ToList();
            }
            return new List<Company>();
        }

        public Company? GetById(int id)
        {
            _context = new OnlineShopContext();
            Company company = _context.Companies.FirstOrDefault(c => c.CompanyId == id);
            return company;
        }

        public void Update(Company company)
        {
            _context = new OnlineShopContext();
            _context.Update(company);
            _context.SaveChanges();
        }
    }
}
