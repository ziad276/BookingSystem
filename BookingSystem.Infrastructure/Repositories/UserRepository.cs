using BookingSystem.Application.Repository;
using BookingSystem.Core.Entities;
using BookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUserAccountAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user != null;
        }
    }
}
