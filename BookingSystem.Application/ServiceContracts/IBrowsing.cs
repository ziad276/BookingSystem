using BookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Application.ServiceContracts
{
    public interface IBrowsing
    {
        Task<List<Provider>> BrowseProvidersAsync();
        Task<List<Appointment>> BrowseAvailableSlotsAsync(int providerId); // This will be filtered by status = Available
        Task<List<Appointment>> BrowseOwnAppointmentsAsync(int providerId); 
    }
}
