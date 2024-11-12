using WebApplication3.Models;
using WebApplication3.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspLab5.Controllers
{
    public class ContactController : Controller
    {
        private  readonly IContactServices _contactService;

        public ContactController(IContactServices contactService)
        {
            _contactService = contactService;
        }

        // GET: ContactController
        public ActionResult Index()
        {
            return View(_contactService.GetAll());
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View(_contactService.GetById(id));
        }

        // GET: ContactController/Create
        public ActionResult Add()
        {
            ContactModel model = new ContactModel();
            model.Organizations = _contactService.getOrganizations().Select(e => new SelectListItem()
            {
                Text = e.Name,
                Value = e.Id.ToString()
            }).ToList();
            
            return View(model);
        }

        // POST: ContactController/Create
        [HttpPost]
        public ActionResult Add(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _contactService.Add(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: ContactController/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_contactService.GetById(id));
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        public ActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _contactService.Update(model);
            return RedirectToAction(nameof(System.Index));
        }
        
        public ActionResult Delete(int id, ContactModel model)
        {
            _contactService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}