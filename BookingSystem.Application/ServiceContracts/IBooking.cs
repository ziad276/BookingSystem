using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Application.ServiceContracts
{
    public interface IBooking
    {
        Task<bool> BookingAppointmentAsync(int appointmentId, int userId);
    }
}
