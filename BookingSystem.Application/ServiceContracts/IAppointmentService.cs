using BookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Application.ServiceContracts
{
    public interface IAppointmentService
    {
        Task<bool> CreateAppointmentAsync(int providerId, DateTime startTime, DateTime endTime);
        Task<List<Appointment>> BrowseAvailableSlotsAsync(int providerId);
        Task<List<Appointment>> BrowseOwnAppointmentsAsync(int providerId);
        Task<bool> BookingAppointmentAsync(int appointmentId, int userId);
        Task<bool> UnbookingAppointmentAsync(int appointmentId, int userId);
    }
}
