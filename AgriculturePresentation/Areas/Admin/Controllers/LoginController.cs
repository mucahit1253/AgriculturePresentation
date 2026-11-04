using AgriculturePresentation.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    loginViewModel.UserName, loginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }

                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
            }

            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult SigUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SigUp(RegisterViewModel registerViewModel)
        {


            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
           
            if (registerViewModel.Password != registerViewModel.PasswordConfirm)
            {
                ModelState.AddModelError("", "Şifreler eşleşmiyor.");
                return View(registerViewModel);
            }
            IdentityUser identityUser = new IdentityUser()
            {
                Id = "1",
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Mail,

            };

            var result = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }


            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }


            return View(registerViewModel);
        }
    }
}
