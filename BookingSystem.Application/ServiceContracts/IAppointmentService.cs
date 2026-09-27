using BookingSystem.Core.Entities;
using BookingSystem.Core.Enums;



namespace BookingSystem.Application.ServiceContracts
{
    public interface IAppointmentService
    {
        Task<bool> CreateAppointmentAsync(int providerId, DateTime startTime, DateTime endTime);
        Task<List<Appointment>> BrowseAvailableSlotsAsync(int providerId);
        Task<List<Appointment>> BrowseOwnAppointmentsAsync(int providerId);
        Task<BookingResult> BookingAppointmentAsync(int appointmentId, string userId);
        Task<BookingResult> UnbookingAppointmentAsync(int appointmentId, string userId);
    }
}
