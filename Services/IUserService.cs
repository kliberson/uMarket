using uMarket.Models;
using uMarket.Repository;
using uMarket.ViewModels;

namespace uMarket.Services
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();
        Task<User?> GetUserByIdAsync(int userId);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task SaveChangesAsync();
        //filtrowanie
        IQueryable<User> FilterUsers(string searchQuery);
        //paginacja
        PaginatedList<UserViewModel> GetPaginatedUsers(string searchQuery, int page, int pageSize);
        
    }
}
