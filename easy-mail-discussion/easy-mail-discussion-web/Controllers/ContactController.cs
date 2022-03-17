using EasyMailDiscussion.Common.Database;
using EasyMailDiscussion.Web.Models;
using EasyMailDiscussion.Web.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Linq;

namespace EasyMailDiscussion.Web.Controllers
{
    public class ContactController : BaseController
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        public IActionResult Index()
        {
            var model = new ContactsModel()
            {
                Contacts = this.SqliteDatabase.Contacts.Include(contact => contact.ContactSubscriptions).ToArray()
            };

            return View(model);
        }

        public IActionResult New()
        {
            return View("Edit");
        }

        public IActionResult Edit(int id)
        {
            var contact = this.SqliteDatabase.Contacts.Where(contact => contact.ID == id).FirstOrDefault();

            if (contact == null)
            {
                logger.Error("Could not find contact with ID = {0}", id);
                return View("Error");
            }

            var model = new EditContactModel()
            {
                Contact = contact
            };

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(ContactForm formInput)
        {
            if (formInput == null)
            {
                logger.Error("Form input was malformed or missing for /Contact/Edit");
                return View("Error");
            }

            if (!formInput.ID.HasValue)
            {
                logger.Error("Attempting to edit a contact which does not exist.");
                return View("Error");
                //This is wrong, and we will not assume that the user was trying to create a new contact.
            }

            var contact = this.SqliteDatabase.Contacts.Where(contact => contact.ID == formInput.ID).FirstOrDefault();

            if (contact == null)
            {
                logger.Error("Could not find an existing contact with ID {0} to edit.", formInput.ID);
                return View("Error");
            }

            contact.Name = formInput.Name;
            contact.Email = formInput.Email;
            contact.Activated = formInput.ActivatedChecked;

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var contact = this.SqliteDatabase.Contacts.Where(list => list.ID == id).FirstOrDefault();

            if (contact == null)
            {
                logger.Error("Could not find contact with ID = {0}", id);
                return View("Error");
            }

            var model = new EditContactModel()
            {
                Contact = contact
            };

            return View("Remove", model);
        }

        [HttpPost]
        public IActionResult Create(ContactForm formInput)
        {
            if (formInput == null)
            {
                logger.Error("Form input was malformed or missing for /Contact/Create");
                return View("Error");
            }

            if (formInput.ID.HasValue)
            {
                logger.Error("Attempting to create a contact with an existing ID.");
                //This is wrong, but not a breaking data structure. We can safely ignore the ID.
            }

            var contact = new Contact()
            {
                Name = formInput.Name,
                Email = formInput.Email,
                Activated = formInput.ActivatedChecked
            };

            this.SqliteDatabase.Contacts.Add(contact);

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
