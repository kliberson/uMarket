using uMarket.Models;
using uMarket.Repository;
using uMarket.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IQueryable<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task AddUserAsync(User user)
    {
        await _userRepository.InsertAsync(user);
        await _userRepository.SaveAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveAsync();
    }

    public async Task DeleteUserAsync(int userId)
    {
        await _userRepository.DeleteAsync(userId);
        await _userRepository.SaveAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _userRepository.SaveAsync();
    }

    public IQueryable<User> FilterUsers(string searchQuery)
    {
        var users = _userRepository.GetAll();

        if (!string.IsNullOrEmpty(searchQuery))
        {
            users = users.Where(u => u.Username.Contains(searchQuery) ||
                                      u.Email.Contains(searchQuery) ||
                                      u.PhoneNumber.Contains(searchQuery) ||
                                      u.Address.Contains(searchQuery));
        }

        return users;
    }


    public PaginatedList<User> GetPaginatedUsers(string searchQuery, int page = 1, int pageSize = 10)
    {
        var usersQuery = FilterUsers(searchQuery);

        var users = usersQuery
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var model = new PaginatedList<User>
        {
            Items = users,
            TotalCount = usersQuery.Count(),  
            PageNumber = page,
            PageSize = pageSize
        };

        return model;
    }
}
