using BookingSystem.Application.ServiceContracts;
using BookingSystem.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingSystem.UI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IProviderService _providerService;
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IProviderService providerService, IAppointmentService appointmentService)
        {
            _providerService = providerService;
            _appointmentService = appointmentService;
        }

        [Authorize(Roles = "Provider")]
        [HttpGet]
        public IActionResult CreateAppointmentAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentViewModel createAppointmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createAppointmentVM);
            }
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized();

            var provider = await _providerService.GetProviderByUserIdAsync(userId);

            if (provider == null)
                return Unauthorized();

            await _appointmentService.CreateAppointmentAsync(
                provider.Id,
                createAppointmentVM.StartTime,
                createAppointmentVM.EndTime
            );

            return RedirectToAction("CreateAppointmentAsync", "Appointment");
        }
    }
}
