using AutoMapper;
using uMarket.Models;
using uMarket.Profiles;
using uMarket.Repository;
using uMarket.Services;
using uMarket.ViewModels;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
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


    public PaginatedList<UserViewModel> GetPaginatedUsers(string searchQuery, int page = 1, int pageSize = 10)
    {
        var usersQuery = FilterUsers(searchQuery);

        var totalCount = usersQuery.Count();
        var users = usersQuery
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var viewModelList = _mapper.Map<List<UserViewModel>>(users).ToList();

        return new PaginatedList<UserViewModel>(viewModelList, totalCount, page, pageSize);
    }
}
