using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

public class CalculatorController : Controller
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
    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    
    
    
}