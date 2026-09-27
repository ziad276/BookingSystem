using BookingSystem.Core.Entities;
using BookingSystem.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace BookingSystem.Core.IdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public Provider Provider { get; set; }
        public List<Appointment> Appointments { get; set; }
        public Role Role { get; set; } = Role.Client;

        public DateTime CreatedDate { get; set; }
    }
}
