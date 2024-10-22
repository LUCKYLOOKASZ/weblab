using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

public class ContactController : Controller
{

    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ContactModel()
            {
                Id = 1,
                FirstName = "Krzysztof",
                LastName = "Ryszard",
                Email = "krzys@gmail.com",
                PhoneNumber = "222 333 444",
                BirthDate = new DateOnly(2003,10,10)
            }
        },
        {
            2,
            new ContactModel()
            {
                Id = 2,
                FirstName = "Michal",
                LastName = "Mati",
                Email = "matmich@gmail.com",
                PhoneNumber = "333 333 444",
                BirthDate = new DateOnly(2003,11,10)
            }
        }
        ,
        {
            3,
            new ContactModel()
            {
                Id = 3,
                FirstName = "Domi",
                LastName = "Korba",
                Email = "domkor@gmail.com",
                PhoneNumber = "444 333 444",
                BirthDate = new DateOnly(2003,4,15)
            }
        }
    };

    private static int currentId = 3;
    // Lista kontaktów. przycisk dodawania kontaktu
    public IActionResult Index()
    {
        return View(_contacts);
    }
    
    
    //formularz dodawania kontaktów
    public IActionResult Add()
    {
        return View();
    }

    //odbieranie danych z formularza walidacja i dodawanie do kolekcji
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            //wyświetlanie ponowne formularza z błędami
            return View(model);
        }

        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
        //dodanie modelu do kolekcji
        return View("index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts); 
    }
}