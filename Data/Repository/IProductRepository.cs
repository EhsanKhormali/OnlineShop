using OnlineShop.Models;

namespace OnlineShop.Data.Repository
{
    public interface IProductRepository
    {
        IList<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
