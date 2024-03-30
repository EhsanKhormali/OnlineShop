using OnlineShop.Models;

namespace OnlineShop.Data.Repository
{
    public interface IOrderRepository
    {
        IList<Order> GetAll();
        Order GetById(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}
