using BookingSystem.Application.Repository;
using BookingSystem.Core.Entities;
using BookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _context;

        public ProviderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProviderAccountAsync(Provider provider)
        {
            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Provider> GetProviderByUserIdAsync(string userId)
        {
            var provider = await _context.Providers.FirstOrDefaultAsync(p => p.UserId == userId);
            return provider ;
        }

        public async Task<List<Provider>> GetProviderListAsync()
        {
            return await _context.Providers.ToListAsync();
        }
    }
}
