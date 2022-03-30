using EasyMailDiscussion.Common.Database;
using EasyMailDiscussion.Web.Models;
using EasyMailDiscussion.Web.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Linq;

namespace EasyMailDiscussion.Web.Controllers
{
    /// <summary> Handles web requests for <see cref="Contact"/> manipulation operations. </summary>
    public class ContactController : BaseController
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary> Constructor. </summary>
        /// <param name="lifetime"> The application lifetime interface. </param>
        public ContactController(IHostApplicationLifetime lifetime)
            : base(lifetime)
        {
            //
        }

        #endregion

        #region Methods

        /// <summary> Gets the index or default request. </summary>
        /// <remarks> Fulfills the <c>/Contact</c> request. </remarks>
        /// <returns> A response to return to the caller. </returns>
        [Route("Contact")]
        public IActionResult Index()
        {
            var model = new ContactsModel()
            {
                Contacts = this.SqliteDatabase.Contacts.Include(contact => contact.ContactSubscriptions).ToArray()
            };

            return View("Index", model);
        }

        /// <summary> Gets the new contact creation form request. </summary>
        /// <remarks> Fulfills the <c>/Contact/New</c> request. </remarks>
        /// <returns> A response to return to the caller. </returns>
        [Route("Contact/New")]
        public IActionResult New()
        {
            return View("Edit", new EditContactModel());
        }

        /// <summary> Gets the edit contact form request. </summary>
        /// <remarks> Fulfills the <c>/Contact/Edit</c> request. </remarks>
        /// <param name="contactID"> Identifier for the contact. </param>
        /// <returns> A response to return to the caller. </returns>
        [Route("Contact/Edit/{contactID}")]
        public IActionResult Edit(int contactID)
        {
            var contact = this.SqliteDatabase.Contacts.Where(contact => contact.ID == contactID).FirstOrDefault();

            if (contact == null)
            {
                logger.Error("Could not find contact with ID = {0}", contactID);
                return View("Error");
            }

            var model = new EditContactModel()
            {
                Contact = contact
            };

            return View("Edit", model);
        }

        /// <summary> Processes the contact editing form submission. </summary>
        /// <remarks> Fulfills the <c>/Contact/Edit</c> post request. </remarks>
        /// <param name="formInput"> The form input. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpPost]
        public IActionResult Edit(ContactForm formInput)
        {
            if (formInput == null)
            {
                logger.Error("Form input was malformed or missing for /Contact/Edit");
                return View("Error");
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

        /// <summary> Gets the contact removal form request. </summary>
        /// <remarks> Fulfills the <c>/Contact/Remove</c> request. </remarks>
        /// <param name="contactID"> Identifier for the contact. </param>
        /// <returns> A response to return to the caller. </returns>
        [Route("Contact/Remove/{contactID}")]
        public IActionResult Remove(int contactID)
        {
            var contact = this.SqliteDatabase.Contacts.Where(list => list.ID == contactID).SingleOrDefault();

            if (contact == null)
            {
                logger.Error("Could not find contact with ID = {0}", contactID);
                return View("Error");
            }

            var model = new RemoveContactModel()
            {
                Contact = contact
            };

            return View("Remove", model);
        }

        /// <summary> Processes the contact removal request. </summary>
        /// <remarks> Fulfills the <c>/Contact/ConfirmRemove</c> request. </remarks>
        /// <param name="contactID"> Identifier for the contact. </param>
        /// <returns> A response to return to the caller. </returns>
        [Route("Contact/ConfirmRemove/{contactID}")]
        public IActionResult ConfirmRemove(int contactID)
        {
            var contact = this.SqliteDatabase.Contacts.Where(contact => contact.ID == contactID).SingleOrDefault();

            if (contact == null)
            {
                logger.Error("Could not find contact with ID = {0}", contactID);
                return View("Error");
            }

            this.SqliteDatabase.Contacts.Remove(contact);

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary> Processes the contact creation form submission. </summary>
        /// <remarks> Fulfills the <c>/Contact/Create</c> post request. </remarks>
        /// <param name="formInput"> The form input. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpPost]
        public IActionResult Create(ContactForm formInput)
        {
            if (formInput == null)
            {
                logger.Error("Form input was malformed or missing for /Contact/Create");
                return View("Error");
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
