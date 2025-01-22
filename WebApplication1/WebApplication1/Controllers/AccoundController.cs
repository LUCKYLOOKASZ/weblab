using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class AccountController : Controller {
    
    [HttpGet]
    public IActionResult Login() {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (username == "admin" && password == "admin") //na sztywno na potrzeby zadania
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true 
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid username or password";
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(); // Wylogowuje użytkownika
        return RedirectToAction("Index", "Home"); // Przekierowuje na stronę główną

        // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        // return RedirectToAction("Login", "Account");
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // [HttpPost]
    // public async Task<IActionResult> Register(RegisterViewModel model)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         var user = new IdentityUser { UserName = model.Username, Email = model.Email };
    //         var result = await _userManager.CreateAsync(user, model.Password);
    //
    //         if (result.Succeeded)
    //         {
    //             // Automatyczne logowanie po rejestracji
    //             await _signInManager.SignInAsync(user, isPersistent: false);
    //             return RedirectToAction("Index", "Home");
    //         }
    //
    //         // Obsługa błędów rejestracji
    //         foreach (var error in result.Errors)
    //         {
    //             ModelState.AddModelError(string.Empty, error.Description);
    //         }
    //     }
    //
    //     return View(model); // Powrót do widoku rejestracji w razie błędów
    // }
}