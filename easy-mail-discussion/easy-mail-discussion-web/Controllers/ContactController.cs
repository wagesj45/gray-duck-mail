using EasyMailDiscussion.Common;
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

        /// <summary> The search cache used for <see cref="Contact">contacts</see>. </summary>
        private static SearchCache<Contact> searchCache = new SearchCache<Contact>();

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

        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            return Search(searchTerm, 1);
        }

        /// <summary>
        /// (An Action that handles HTTP GET requests) searches for the first match.
        /// </summary>
        /// <param name="searchTerm"> The search term. </param>
        /// <param name="pageNumber"> The page number. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpGet]
        [Route("Contact/Search/{searchTerm}/{pageNumber}")]
        public IActionResult Search(string searchTerm, int pageNumber = 1)
        {
            var contacts = this.SqliteDatabase.Contacts.Include(contact => contact.ContactSubscriptions)
                .Search(contact => contact.Name, searchTerm)
                .Search(contact => contact.Email, searchTerm)
                .Select(contact => new SearchResult<Contact>(contact, 0))
                .Page(pageNumber, DockerEnvironmentVariables.PageSize)
                .AsEnumerable();

            var model = new ContactSearchModel()
            {
                PageNumber = pageNumber,
                TotalPages = contacts.PageCount(DockerEnvironmentVariables.PageSize),
                IsFuzzySearch = false,
                Contacts = new SearchCache<Contact>(searchTerm, contacts.Page(pageNumber, DockerEnvironmentVariables.PageSize))
            };

            return View("Search", model);
        }

        [Route("Contact/FuzzySearch/{searchTerm}/{pageNumber?}")]
        public IActionResult FuzzySearch(string searchTerm, int pageNumber = 1)
        {
            if (searchCache.SearchTerm != searchTerm)
            {
                logger.Debug("Loading search cache with term '{0}'.", searchTerm);

                var contacts = this.SqliteDatabase.Contacts
                    .Include(contact => contact.ContactSubscriptions)
                    .FuzzySearch(searchTerm, contact => contact.Name, contact => contact.Email);

                logger.Debug("Caching search result.");
                searchCache = new SearchCache<Contact>(searchTerm, contacts.ToArray());
            }

            var model = new ContactSearchModel()
            {
                PageNumber = pageNumber,
                TotalPages = searchCache.Cache.PageCount(DockerEnvironmentVariables.PageSize),
                IsFuzzySearch = true,
                Contacts = new SearchCache<Contact>(searchTerm, searchCache.Cache.Page(pageNumber, DockerEnvironmentVariables.PageSize))
            };

            return View("Search", model);
        }

        #endregion
    }
}
