using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab5WebApp.Models;

namespace Lab5WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult About()
    {
        ViewData["Message"] = "��� ���-���������� �������� ��������� ��� ���������� ������ ����� ���-���������.";
        return View();
    }

    public IActionResult Labs()
    {
        return View();
    }


}
