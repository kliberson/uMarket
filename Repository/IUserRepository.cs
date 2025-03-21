using uMarket.Models;

namespace uMarket.Repository
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User?> GetByIdAsync(int EmployeeID);
        Task InsertAsync(User employee);
        Task UpdateAsync(User employee);
        Task DeleteAsync(int employeeId);
        Task SaveAsync();
    }
}