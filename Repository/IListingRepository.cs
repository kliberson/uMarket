using uMarket.Models;

namespace uMarket.Repository
{
    public interface IListingRepository
    {
        IQueryable<Listing> GetAll();
        Task<Listing> GetByIdAsync(int id);
        Task AddAsync(Listing listing);
        Task UpdateAsync(Listing listing);
        Task DeleteAsync(int id);
    }
}
