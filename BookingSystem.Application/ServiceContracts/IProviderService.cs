using BookingSystem.Core.Entities;


namespace BookingSystem.Application.ServiceContracts
{
    public interface IProviderService
    {
        Task<Provider> CreateProviderAccountAsync(int userId);
        Task<List<Provider>> BrowseProvidersAsync();
    }
}
