using Microsoft.AspNetCore.Mvc;
using Lab5WebApp.Models;

namespace Lab5WebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Логіка збереження користувача
                TempData["Success"] = "User registered successfully!";
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Приклад перевірки логіну/пароля
                if (model.Username == "test" && model.Password == "Test@123")
                {
                    TempData["Success"] = "You have logged in successfully!";
                    return Redirect(returnUrl ?? "/Profile"); // Замість "Account/Profile" просто "Profile"
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

    }
}
