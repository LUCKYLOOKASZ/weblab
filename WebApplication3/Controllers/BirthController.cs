using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Form()
    {
        return View();
    }
    
}