using BookingSystem.Core.Enums;
using BookingSystem.Core.IdentityEntities;

namespace BookingSystem.Core.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Status Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
