using BookingSystem.Core.Entities;
using BookingSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Application.Repository
{
    public interface IAppointmentRepository
    {
        Task<bool> AddAppointmentAsync(Appointment appointment);
        Task<Appointment> GetAppointmentByIdAsync(int appointmentId);
        Task<List<Appointment>> GetAppointmentsByProviderAsync(int providerId, Status? status = null);
        Task<bool> UpdateAppointmentAsync(Appointment appointment);

    }
}
