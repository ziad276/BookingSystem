using BookingSystem.Core.Enums;

namespace BookingSystem.Core.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public Status Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; } 
    }
}
