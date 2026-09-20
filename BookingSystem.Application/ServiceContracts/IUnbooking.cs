using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Application.ServiceContracts
{
    public interface IUnbooking
    {
        Task<bool> UnbookingAppointmentAsync(int appointmentId, int userId);
    }
}
