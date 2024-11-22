using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lab5WebApp.Models;


namespace Lab5WebApp.Controllers
{
    [Authorize] // Доступ тільки для авторизованих користувачів
    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var profileData = new ProfileViewModel
            {
                Username = User.FindFirst("name")?.Value ?? "Unknown",
                FullName = User.FindFirst("full_name")?.Value ?? "Unknown",
                Email = User.FindFirst("email")?.Value ?? "Unknown",
                Phone = User.FindFirst("phone_number")?.Value ?? "Unknown"
            };

            return View(profileData);
        }
    }
}
