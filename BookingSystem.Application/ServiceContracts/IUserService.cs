using BookingSystem.Core.Entities;
namespace BookingSystem.Application.ServiceContracts
{
    public interface IUserService
    {
        Task<bool> CreateUserAccountAsync(string name, string email, string password);
    }
}
