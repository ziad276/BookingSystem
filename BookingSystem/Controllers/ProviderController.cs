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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IProviderService _providerService;

        public ProviderController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IProviderService providerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _providerService = providerService;
        }
        public async Task<IActionResult> BecomeProvider()
        {

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _providerService.BecomeProviderAsync(userId);
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.AddToRoleAsync(user, "Provider");

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Could not become a provider");
                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("Index", "Home");
        }
    }
}
