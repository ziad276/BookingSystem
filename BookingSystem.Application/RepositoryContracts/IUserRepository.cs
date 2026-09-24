
using BookingSystem.Core.Entities;

namespace BookingSystem.Application.Repository
{
    public interface IUserRepository
    {
        Task<bool> AddUserAccountAsync(User user);
        Task<bool> GetUserByEmailAsync(string email);

    }
}
