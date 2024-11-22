using LabsLibrary;
using Microsoft.AspNetCore.Mvc;

public class Lab1Controller : Controller
{
    private readonly Lab1 _lab1;

    public Lab1Controller()
    {
        _lab1 = new Lab1();
    }

    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Run(string input)
    {
        var result = _lab1.Run(input); // Викликаємо метод Run з LabsLibrary
        ViewData["Result"] = result;
        return View("Index");
    }
}
