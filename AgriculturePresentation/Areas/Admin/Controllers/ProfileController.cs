using AgriculturePresentation.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Mail = values.Email;
            userEditViewModel.Phone = values.PhoneNumber;
         

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (values == null)
            {
                return NotFound();
            }

            if (userEditViewModel.Password != userEditViewModel.ConfirmPassword)
            {
                ModelState.AddModelError("", "Şifreler eşleşmiyor.");
                return View(userEditViewModel);
            }

            values.Email = userEditViewModel.Mail;
            values.PhoneNumber = userEditViewModel.Phone;

            if (!string.IsNullOrWhiteSpace(userEditViewModel.Password))
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userEditViewModel.Password);
            }

            var result = await _userManager.UpdateAsync(values);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login", new { area = "Admin" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(userEditViewModel);
        }
    }
}
