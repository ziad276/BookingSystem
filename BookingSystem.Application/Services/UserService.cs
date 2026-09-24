using BookingSystem.Application.Repository;
using BookingSystem.Application.ServiceContracts;
using BookingSystem.Core.Entities;

namespace BookingSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        => _userRepository = userRepository;


        public async Task<bool> CreateUserAccountAsync(string name, string email, string password)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(email);

            if(existingUser != null)
            {
                throw new InvalidOperationException("User account already exists with this email.");
            }

            var user = new User
            {
                Name = name,
                Email = email,
                Password = password
            };
            return await _userRepository.AddUserAccountAsync(user);
        }
    }
}
