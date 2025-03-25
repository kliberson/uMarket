using uMarket.Models;

namespace uMarket.Repository
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
