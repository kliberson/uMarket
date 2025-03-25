using uMarket.Data;
using uMarket.Models;

namespace uMarket.Repository
{
    public class ListingRepository : IListingRepository
    {
        private readonly MarketContext _context;

        public ListingRepository(MarketContext context)
        {
            _context = context;
        }

        public IQueryable<Listing> GetAll()
        {
            return _context.Listings;
        }

        public async Task<Listing> GetByIdAsync(int id)
        {
            return await _context.Listings.FindAsync(id);
        }

        public async Task AddAsync(Listing listing)
        {
            await _context.Listings.AddAsync(listing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Listing listing)
        {
            _context.Listings.Update(listing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var listing = await GetByIdAsync(id);
            if (listing != null)
            {
                _context.Listings.Remove(listing);
                await _context.SaveChangesAsync();
            }
        }
    }

}
