using Domain.Entities;

namespace Data.Repository
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
