using BookingSystem.Application.Repository;
using BookingSystem.Core.Entities;
using BookingSystem.Core.Enums;
using BookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int appointmentId)
        {
            return await _context.Appointments.FirstOrDefaultAsync(u => u.Id == appointmentId);
        }

        public async Task<List<Appointment>> GetAppointmentsByProviderAsync(int providerId, Status? status = null)
        {
            var query = _context.Appointments.Where(a => a.ProviderId == providerId);

            if (status.HasValue)
            {
                query = query.Where(a => a.Status == status.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
