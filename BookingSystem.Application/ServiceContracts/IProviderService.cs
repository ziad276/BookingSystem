using BookingSystem.Core.Entities;


namespace BookingSystem.Application.ServiceContracts
{
    public interface IProviderService
    {
        Task<bool> BecomeProviderAsync(string userId);
        Task<List<Provider>> BrowseProvidersAsync();
        Task<Provider> GetProviderByUserIdAsync(string userId);


    }
}
