using BookingSystem.Application.Repository;
using BookingSystem.Application.ServiceContracts;
using BookingSystem.Core.Entities;

namespace BookingSystem.Application.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)

        => _providerRepository = providerRepository;


        public async Task<List<Provider>> BrowseProvidersAsync()
        {
            return await _providerRepository.GetProviderListAsync();
        }

        public async Task<bool> CreateProviderAccountAsync(int userId)
        {
            var existingProvider = await _providerRepository.GetProviderByUserIdAsync(userId);

            if (existingProvider != null)
            {
                throw new InvalidOperationException("Provider account already exists for this user.");
            }



            return await _providerRepository.AddProviderAccountAsync(new Provider { UserId = userId });

        }
    }
}
