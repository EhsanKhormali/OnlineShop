using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineShopContext _context = new OnlineShopContext();
        public void Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
