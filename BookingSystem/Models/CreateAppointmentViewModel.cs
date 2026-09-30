using System.ComponentModel.DataAnnotations;

namespace BookingSystem.UI.Models
{
    public class CreateAppointmentViewModel
    {
        [Required(ErrorMessage = "Start time is required.")]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
    }
}
