using uMarket.Data;
using uMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace uMarket.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MarketContext _context;

        public UserRepository(MarketContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users; 
        }

        public async Task<User?> GetByIdAsync(int UserID)
        {
            var employee = await _context.Users
               .FirstOrDefaultAsync(m => m.UserId == UserID);
            return employee;
        }

        public async Task InsertAsync(User employee)
        {
            await _context.Users.AddAsync(employee);
        }

        public async Task UpdateAsync(User employee)
        {
            _context.Users.Update(employee);
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employee = await _context.Users.FindAsync(employeeId);
            if (employee != null)
            {
                _context.Users.Remove(employee);
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
