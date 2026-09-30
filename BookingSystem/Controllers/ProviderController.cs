using BookingSystem.Application.ServiceContracts;
using BookingSystem.Core.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingSystem.UI.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProviderService _providerService;

        public ProviderController(
            UserManager<ApplicationUser> userManager,
            IProviderService providerService)
        {
            _userManager = userManager;
            _providerService = providerService;
        }
        [HttpPost]
        public async Task<IActionResult> BecomeProvider()
        {

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var providerCreated = await _providerService.BecomeProviderAsync(userId); // returns bool
            if (!providerCreated)
            {
                ModelState.AddModelError("", "Could not become a provider");
                return RedirectToAction("Index", "Home");
            }


            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            if (!await _userManager.IsInRoleAsync(user, "Provider"))
            {
                var result = await _userManager.AddToRoleAsync(user, "Provider");
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Could not become a provider");
                    return RedirectToAction("Index", "Home");

                }
            }




            return RedirectToAction("Index", "Home");
        }
    }
}
