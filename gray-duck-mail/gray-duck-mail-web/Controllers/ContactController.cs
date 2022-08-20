using GrayDuckMail.Common;
using GrayDuckMail.Common.Database;
using GrayDuckMail.Web.Models;
using GrayDuckMail.Web.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Linq;

namespace GrayDuckMail.Web.Controllers
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
        [Route("Contact/{pageNumber?}")]
        [InternalAccessOnly]
        public IActionResult Index(int pageNumber = 1)
        {
            var contacts = this.SqliteDatabase.Contacts.Include(contact => contact.ContactSubscriptions);

            var model = new ContactsModel()
            {
                Contacts = contacts.Page(pageNumber, this.PageSize),
                PageNumber = pageNumber,
                TotalPages = contacts.PageCount(this.PageSize),
                Theme = this.Theme
            };

            return View("Index", model);
        }

        /// <summary> Gets the new contact creation form request. </summary>
        /// <remarks> Fulfills the <c>/Contact/New</c> request. </remarks>
        /// <returns> A response to return to the caller. </returns>
        [Route("Contact/New")]
        [InternalAccessOnly]
        public IActionResult New()
        {
            return View("Edit", new EditContactModel() { Theme = this.Theme });
        }

        /// <summary> Gets the edit contact form request. </summary>
        /// <remarks> Fulfills the <c>/Contact/Edit</c> request. </remarks>
        /// <param name="contactID"> Identifier for the contact. </param>
        /// <returns> A response to return to the caller. </returns>
        [Route("Contact/Edit/{contactID}")]
        [InternalAccessOnly]
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
                Contact = contact,
                Theme = this.Theme
            };

            return View("Edit", model);
        }

        /// <summary> Processes the contact editing form submission. </summary>
        /// <remarks> Fulfills the <c>/Contact/Edit</c> post request. </remarks>
        /// <param name="formInput"> The form input. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpPost]
        [Route("Contact/Edit")]
        [InternalAccessOnly]
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
            contact.Activated = formInput.IsChecked(f => f.Activated);

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary> Gets the contact removal form request. </summary>
        /// <remarks> Fulfills the <c>/Contact/Remove</c> request. </remarks>
        /// <param name="contactID"> Identifier for the contact. </param>
        /// <returns> A response to return to the caller. </returns>
        [Route("Contact/Remove/{contactID}")]
        [InternalAccessOnly]
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
                Contact = contact,
                Theme = this.Theme
            };

            return View("Remove", model);
        }

        /// <summary> Processes the contact removal request. </summary>
        /// <remarks> Fulfills the <c>/Contact/ConfirmRemove</c> request. </remarks>
        /// <param name="contactID"> Identifier for the contact. </param>
        /// <returns> A response to return to the caller. </returns>
        [Route("Contact/ConfirmRemove/{contactID}")]
        [InternalAccessOnly]
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
        [Route("Contact/Create")]
        [InternalAccessOnly]
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
                Activated = formInput.IsChecked(f => f.Activated)
            };

            this.SqliteDatabase.Contacts.Add(contact);

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Searches for the <see cref="Contact">contacts</see> with a matching <see cref="Contact.Name">
        /// name</see> or <see cref="Contact.Email">email address</see>.
        /// </summary>
        /// <remarks> Fulfills the <c>/Contact/Search</c> post request. </remarks>
        /// <param name="searchTerm"> The search term. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpPost]
        [Route("Contact/Search")]
        [InternalAccessOnly]
        public IActionResult Search(string searchTerm)
        {
            return Search(searchTerm, 1);
        }

        /// <summary>
        /// Searches for the <see cref="Contact">contacts</see> with a matching <see cref="Contact.Name">
        /// name</see> or <see cref="Contact.Email">email address</see>.
        /// </summary>
        /// <remarks> Fulfills the <c>/Contact/Search</c> request. </remarks>
        /// <param name="searchTerm"> The search term. </param>
        /// <param name="pageNumber"> (Optional) The page number. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpGet]
        [Route("Contact/Search/{searchTerm}/{pageNumber?}")]
        [InternalAccessOnly]
        public IActionResult Search(string searchTerm, int pageNumber = 1)
        {
            if (searchCache.SearchTerm != searchTerm)
            {
                var contacts = Enumerable.Empty<SearchResult<Contact>>();

                if (this.UseFuzzySearch)
                {
                    logger.Info("Performing fuzzy search: {0}", searchTerm);

                    contacts = this.SqliteDatabase.Contacts
                        .Include(contact => contact.ContactSubscriptions)
                        .FuzzySearch(searchTerm, contact => contact.Name, contact => contact.Email)
                        .OrderByDescending(searchResult => searchResult.Score);
                }
                else
                {
                    contacts = this.SqliteDatabase.Contacts.Include(contact => contact.ContactSubscriptions)
                        .Search(contact => contact.Name, searchTerm)
                        .Search(contact => contact.Email, searchTerm)
                        .Select(contact => new SearchResult<Contact>(contact, 0))
                        .OrderByDescending(searchResult => searchResult.Score)
                        .AsEnumerable();
                }

                searchCache = new SearchCache<Contact>(searchTerm, contacts.Where(contact => contact.Score >= DockerEnvironmentVariables.MinimumSearchScore));
            }

            var model = new ContactSearchModel()
            {
                PageNumber = pageNumber,
                TotalPages = searchCache.Cache.PageCount(this.PageSize),
                IsFuzzySearch = this.UseFuzzySearch,
                Contacts = new SearchCache<Contact>(searchTerm, searchCache.Cache.Page(pageNumber, this.PageSize)),
                Theme = this.Theme
            };

            return View("Search", model);
        }

        #endregion
    }
}
