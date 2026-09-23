using BookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Application.Repository
{
    public interface IProviderRepository
    {
        Task<bool> AddProviderAccountAsync(Provider provider);
        Task<List<Provider>> GetProviderListAsync();
    }
}
