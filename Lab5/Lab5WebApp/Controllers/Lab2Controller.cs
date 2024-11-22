using LabsLibrary;
using Microsoft.AspNetCore.Mvc;

public class Lab2Controller : Controller
{
    private readonly Lab2 _lab2;

    public Lab2Controller()
    {
        _lab2 = new Lab2();
    }

    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Run(string input)
    {
        var result = _lab2.Run(input); // Викликаємо метод Run з LabsLibrary
        ViewData["Result"] = result;
        return View("Index");
    }
}
