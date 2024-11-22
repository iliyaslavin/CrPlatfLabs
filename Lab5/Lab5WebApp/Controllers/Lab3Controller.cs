using LabsLibrary;
using Microsoft.AspNetCore.Mvc;

public class Lab3Controller : Controller
{
    private readonly Lab3 _lab3;

    public Lab3Controller()
    {
        _lab3 = new Lab3();
    }

    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Run(string input)
    {
        var result = _lab3.Run(input); // Викликаємо метод Run з LabsLibrary
        ViewData["Result"] = result;
        return View("Index");
    }
}
