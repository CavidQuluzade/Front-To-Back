using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.DataBase;
using PurpleBuzz.Models.Contact;

namespace PurpleBuzz.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public ContactController(AppDBContext context)
        {
            _appDBContext = context;
        }
        public IActionResult Index()
        {
            var Contacts = _appDBContext.Contacts.ToList();
            var contactList = new List<ContactVM>();
            foreach (var contact in Contacts)
            {
                var contactVM = new ContactVM
                {
                    Name = contact.Name,
                    ContactType = contact.ContactType,
                    IconSrc = contact.IconSrc,
                    PhoneNumber = contact.PhoneNumber
                };
                contactList.Add(contactVM);
            }
            var model = new ContactIndexVM
            {
                Contacts = contactList
            };
            return View(model);
        }
    }
}
