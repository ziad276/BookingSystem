using BookingSystem.Application.ServiceContracts;
using BookingSystem.Core.Enums;
using BookingSystem.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int providerId)
        {
            var availableSlots = await _appointmentService.BrowseAvailableSlotsAsync(providerId);

            return View(availableSlots);
        }


        [Authorize(Roles = "Provider")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Provider")]
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

            return RedirectToAction("MySlots");
        }

        [Authorize(Roles = "Provider")]
        public async Task<IActionResult> MySlots()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var provider = await _providerService.GetProviderByUserIdAsync(userId);

            var OwnSlots = await _appointmentService.BrowseOwnAppointmentsAsync(provider.Id);
            return View(OwnSlots);
        }

        [HttpPost]
        public async Task<IActionResult> Book(int appointmentId, int providerId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var result = await _appointmentService.BookingAppointmentAsync(appointmentId, userId);

            if (result == BookingResult.Success)
            {
                TempData["Success"] = "Appointment booked successfully!";
            }
            else if (result == BookingResult.Booked)
            {
                TempData["Error"] = "Sorry, this slot has already been booked.";
            }
            else
            {
                TempData["Error"] = "Unable to book this appointment.";
            }

            return RedirectToAction("Index", new { providerId = providerId });


        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Unbook(int appointmentId, int providerId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var result = await _appointmentService.UnbookingAppointmentAsync(appointmentId, userId);

            if (result == BookingResult.Success)
            {
                TempData["Success"] = "Appointment cancelled successfully!";
            }
            else if (result == BookingResult.NotFound)
            {
                TempData["Error"] = "Appointment not found.";
            }
            else if (result == BookingResult.Unauthorized)
            {
                TempData["Error"] = "You are not authorized to cancel this appointment.";
            }
            else
            {
                TempData["Error"] = "Unable to cancel this appointment.";
            }
            return RedirectToAction("MySlots");

        }

    }
}
