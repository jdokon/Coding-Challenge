using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.BusinessLogic;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactsService _contactsService;

        public ContactsController(ContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactsService.SaveContact(contact);
                return RedirectToAction("Confirmation");
            }
            return View(contact);
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        [HttpGet("get-contacts")]
        public IActionResult GetContacts(string lastName, bool? ascending)
        {
            var contacts = _contactsService.GetContacts(lastName, ascending);
            return Ok(contacts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
