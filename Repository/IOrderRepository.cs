using uMarket.Models;

namespace uMarket.Repository
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
