using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Repository;
using BookingSystem.Application.ServiceContracts;
using BookingSystem.Core.Entities;
using BookingSystem.Core.Enums;
using System.Net;


namespace BookingSystem.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<BookingResult> BookingAppointmentAsync(int appointmentId, int userId)
        {
            //Check if the appointment exists
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(appointmentId);

            if (appointment == null)
            {
                return BookingResult.NotFound;
            }
            else if (appointment.Status == Status.Confirmed)
            {
                return BookingResult.Booked;
            }

            else if (appointment.Status == Status.Available)
            {
                appointment.UserId = userId;
                appointment.Status = Status.Confirmed;

                await _appointmentRepository.UpdateAppointmentAsync(appointment);
            }
            return BookingResult.Success;

        }

        public async Task<List<Appointment>> BrowseAvailableSlotsAsync(int providerId)
        {
            return await _appointmentRepository.GetAppointmentsByProviderAsync(providerId, Status.Available);
        }

        public async Task<List<Appointment>> BrowseOwnAppointmentsAsync(int providerId)
        {
            return await _appointmentRepository.GetAppointmentsByProviderAsync(providerId);
        }

        public async Task CreateAppointmentAsync(int providerId, DateTime startTime, DateTime endTime)
        {
            await _appointmentRepository.AddAppointmentAsync(new Appointment
            {
                ProviderId = providerId,
                StartTime = startTime,
                EndTime = endTime,
                Status = Status.Available
            });

        }

        public async Task<BookingResult> UnbookingAppointmentAsync(int appointmentId, int userId)
        {
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(appointmentId);

            if (appointment == null)
            {
                return BookingResult.NotFound;
            }

            if (appointment.UserId != userId)
            {
                return BookingResult.Unauthorized;
            }

            appointment.UserId = null;
            appointment.Status = Status.Available;
            await _appointmentRepository.UpdateAppointmentAsync(appointment);
            return BookingResult.Success;
        }
    }
}
