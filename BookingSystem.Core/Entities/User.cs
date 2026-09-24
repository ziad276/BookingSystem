using BookingSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingSystem.Core.Entities
{
    // The Aggregate Root
    public class User
    {
        public int Id { get; set; }
        public Role Role { get; set; } = Role.Client;
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
