using BookingSystem.Core.Entities;


namespace BookingSystem.Application.ServiceContracts
{
    public interface IProviderService
    {
        Task<bool> CreateProviderAccountAsync(string userId);
        Task<List<Provider>> BrowseProvidersAsync();
    }
}
