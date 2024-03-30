using OnlineShop.Data;
using OnlineShop.Models;
using System.Data;

namespace OnlineShop.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopContext _context = new OnlineShopContext();

        public ProductRepository()
        {
        }

        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            if (_context.Products != null)
            {
                return _context.Products.ToList();
            }
            return new List<Product>();

        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
