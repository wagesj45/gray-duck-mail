using GrayDuckMail.Common;
using GrayDuckMail.Common.Database;
using GrayDuckMail.Common.Localization;
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
    /// <summary>
    /// Handles web requests for <see cref="DiscussionList"/> manipulation operations.
    /// </summary>
    public class ListController : BaseController
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary> The search cache used for <see cref="Message">messages</see>. </summary>
        private static SearchCache<Message> searchCache = new SearchCache<Message>();

        #endregion

        #region Constructors

        /// <summary> Constructor. </summary>
        /// <param name="lifetime"> The application lifetime interface. </param>
        public ListController(IHostApplicationLifetime lifetime)
            : base(lifetime)
        {
            //
        }

        #endregion

        #region Methods

        /// <summary> Gets the index or default request. </summary>
        /// <remarks> Fulfills the <c>/List</c> request. </remarks>
        /// <returns> A response to return to the caller. </returns>
        [Route("List/{pageNumber?}")]
        public IActionResult Index(int pageNumber = 1)
        {
            var discussionLists = this.SqliteDatabase.DiscussionLists;

            var model = new DiscussionListsModel()
            {
                DiscussionLists = discussionLists.Page(pageNumber, this.PageSize),
                PageNumber = pageNumber,
                TotalPages = discussionLists.PageCount(this.PageSize),
                Theme = this.Theme
            };

            return View(model);
        }

        /// <summary> Gets the new discussion list creation form request. </summary>
        /// <returns> A response to return to the caller. </returns>
        /// <remarks> Fulfills the <c>/List/New</c> request. </remarks>
        [Route("List/New")]
        public IActionResult New()
        {
            return View("Edit", new EditDiscussionListModel() { Theme = this.Theme });
        }

        /// <summary> Gets the edit list form request. </summary>
        /// <remarks> Fulfills the <c>/List/Edit</c> request. </remarks>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <returns> A response to return to the caller. </returns>
        [Route("List/Edit/{discussionListID}")]
        public IActionResult Edit(int discussionListID)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists.Where(list => list.ID == discussionListID).FirstOrDefault();

            if (discussionList == null)
            {
                logger.Error(LanguageHelper.FormatValue(ResourceName.Logger_Format_CouldNotFindDiscussionList, discussionListID));
                return View("Error");
            }

            var model = new EditDiscussionListModel()
            {
                DiscussionList = discussionList,
                Theme = this.Theme
            };

            return View("Edit", model);
        }

        /// <summary> Processes the discussion list editing form submission. </summary>
        /// <remarks> Fulfills the <c>/List/Edit</c> post request. </remarks>
        /// <param name="formInput"> The form input. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpPost]
        [Route("List/Edit")]
        public IActionResult Edit(DiscussionListForm formInput)
        {
            if (formInput == null)
            {
                logger.Error(LanguageHelper.FormatValue(ResourceName.Logger_Format_FormInputMalformed, "/List/Edit"));
                return View("Error");
            }

            var discussionList = this.SqliteDatabase.DiscussionLists.Where(list => list.ID == formInput.ID).FirstOrDefault();

            if (discussionList == null)
            {
                logger.Error(LanguageHelper.FormatValue(ResourceName.Logger_Format_CouldNotFindDiscussionList, formInput.ID));
                return View("Error");
            }

            discussionList.Name = formInput.Name;
            discussionList.Description = formInput.Description;
            discussionList.BaseEmailAddress = formInput.BaseEmailAddress;
            discussionList.UserName = formInput.UserName;
            discussionList.Password = formInput.Password;
            discussionList.IncomingMailServer = formInput.IncomingMailServer;
            discussionList.IncomingMailPort = formInput.IncomingMailPort;
            discussionList.OutgoingMailServer = formInput.OutgoingMailServer;
            discussionList.OutgoingMailPort = formInput.OutgoingMailPort;
            discussionList.UseSSL = formInput.IsChecked(f => f.UseSSL);

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary> Processes the discussion list removal form request. </summary>
        /// <remarks> Fulfills the <c>/List/Remove</c> request. </remarks>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <returns> A response to return to the caller. </returns>
        [Route("List/Remove/{discussionListID}")]
        public IActionResult Remove(int discussionListID)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists.Where(list => list.ID == discussionListID).SingleOrDefault();

            if (discussionList == null)
            {
                logger.Error(LanguageHelper.FormatValue(ResourceName.Logger_Format_CouldNotFindDiscussionList, discussionListID));
                return View("Error");
            }

            var model = new RemoveDiscussionListModel()
            {
                DiscussionList = discussionList,
                Theme = this.Theme
            };

            return View("Remove", model);
        }

        /// <summary> Processes the discussion list removal request. </summary>
        /// <remarks> Fulfills the <c>/List/ConfirmRemove</c> request. </remarks>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <returns> A response to return to the caller. </returns>
        [Route("List/ConfirmRemove/{discussionListID}")]
        public IActionResult ConfirmRemove(int discussionListID)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists.Where(list => list.ID == discussionListID).SingleOrDefault();

            if (discussionList == null)
            {
                logger.Error(LanguageHelper.FormatValue(ResourceName.Logger_Format_CouldNotFindDiscussionList, discussionListID));
                return View("Error");
            }

            this.SqliteDatabase.DiscussionLists.Remove(discussionList);

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary> Processes the discussion list creation form submission. </summary>
        /// <remarks> Fulfills the <c>/List/Create</c> post request. </remarks>
        /// <param name="formInput"> The form input. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpPost]
        [Route("List/Create")]
        public IActionResult Create(DiscussionListForm formInput)
        {
            if (formInput == null)
            {
                logger.Error(LanguageHelper.FormatValue(ResourceName.Logger_Format_FormInputMalformed, "/List/Create"));
                return View("Error");
            }

            var discussionList = new DiscussionList()
            {
                Name = formInput.Name,
                Description = formInput.Description,
                BaseEmailAddress = formInput.BaseEmailAddress,
                UserName = formInput.UserName,
                Password = formInput.Password,
                IncomingMailServer = formInput.IncomingMailServer,
                IncomingMailPort = formInput.IncomingMailPort,
                OutgoingMailServer = formInput.OutgoingMailServer,
                OutgoingMailPort = formInput.OutgoingMailPort,
                UseSSL = formInput.IsChecked(f => f.UseSSL)
            };

            this.SqliteDatabase.DiscussionLists.Add(discussionList);

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary> Gets the discussion list contact assignment form request. </summary>
        /// <remarks> Fulfills the <c>/List/Assign</c> request. </remarks>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <returns> A response to return to the caller. </returns>
        [Route("List/Assign/{discussionListID}")]
        public IActionResult Assign(int discussionListID)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists.Where(list => list.ID == discussionListID).FirstOrDefault();
            var contacts = this.SqliteDatabase.Contacts.ToArray();
            var subscriptions = this.SqliteDatabase.ContactSubscriptions.Where(subscription => subscription.DiscussionListID == discussionListID)
                .Include(subscription => subscription.Contact)
                .Include(subscription => subscription.DiscussionList)
                .ToArray();

            if (discussionList == null)
            {
                logger.Error(LanguageHelper.FormatValue(ResourceName.Logger_Format_CouldNotFindDiscussionList, discussionListID));
                return View("Error");
            }

            var model = new DiscussionListAssignModel()
            {
                DiscussionList = discussionList,
                Contacts = contacts,
                Subscriptions = subscriptions,
                Theme = this.Theme
            };

            return View("Assign", model);
        }

        /// <summary> Processes the discussion list contact assignment form submission. </summary>
        /// <remarks> Fulfills the <c>/List/Assign</c> post request. </remarks>
        /// <param name="formInput"> The form input. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpPost]
        [Route("List/Assign")]
        public IActionResult Assign(DiscussionListAssignForm formInput)
        {
            foreach (var assignment in formInput.Assignments)
            {
                var subscription = this.SqliteDatabase.ContactSubscriptions
                    .Where(subscription => subscription.DiscussionListID == formInput.DiscussionListID && subscription.ContactID == assignment.ContactID)
                    .Include(subscription => subscription.Contact)
                    .FirstOrDefault();

                if (assignment.IsAssigned)
                {
                    if (subscription == null)
                    {
                        logger.Debug(LanguageHelper.FormatValue(ResourceName.Logger_Format_AssigningContact, assignment.ContactID, formInput.DiscussionListID));
                        subscription = new ContactSubscription()
                        {
                            ContactID = assignment.ContactID,
                            DiscussionListID = formInput.DiscussionListID,
                            Status = SubscriptionStatus.Created
                        };
                        this.SqliteDatabase.ContactSubscriptions.Add(subscription);
                    }
                    if (subscription.Status == SubscriptionStatus.Requested)
                    {
                        logger.Debug(LanguageHelper.FormatValue(ResourceName.Logger_Format_AssigningContact, assignment.ContactID, formInput.DiscussionListID));
                        subscription.Status = SubscriptionStatus.Subscribed;
                    }
                    else if (subscription.Status == SubscriptionStatus.Denied)
                    {
                        logger.Debug(LanguageHelper.FormatValue(ResourceName.Logger_Format_AssigningContact, assignment.ContactID, formInput.DiscussionListID));
                        subscription.Status = SubscriptionStatus.Subscribed;
                    }
                }
                else
                {
                    if (subscription != null && EmailHelper.ContactAssociatedStatuses.Contains(subscription.Status) && subscription.Contact.Activated)
                    {
                        logger.Debug(LanguageHelper.FormatValue(ResourceName.Logger_Format_UnassigningContact, assignment.ContactID, formInput.DiscussionListID));

                        subscription.Status = SubscriptionStatus.Denied;
                    }
                }
            }

            logger.Info(LanguageHelper.GetValue(ResourceName.Logger_SavingAssignments));
            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary> Queues a test message in the form of an Owner Requst notification. </summary>
        /// <remarks> Fulfills the <c>/List/Test</c> request. </remarks>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <returns> A response to return to the caller. </returns>
        /// <seealso cref="EmailDefinitionType.RequestOwnerNotification"/>
        /// <seealso cref="EmailHelper.SendRequestOwnerNotificationEmail(DiscussionList, Contact, MailKit.Net.Smtp.SmtpClient, System.Threading.CancellationToken)"/>
        [Route("List/Test/{discussionListID}")]
        public IActionResult Test(int discussionListID)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists
                .Where(discussionList => discussionList.ID == discussionListID)
                .SingleOrDefault();
            var ownerContact = new Contact() { Name = "Server Test", Email = EmailAliasHelper.GetOwnerAlias(discussionList), Activated = true };

            if(discussionList != null)
            {
                logger.Info(LanguageHelper.FormatValue(ResourceName.Logger_Format_SendingTest, discussionList.Name));

                SharedMemory.AddEmail(EmailDefinition.CreateOwnerNotification(discussionList, ownerContact));
                
                if(DockerEnvironmentVariables.WebOnly)
                {
                    // If the email sending services are not running, send the email here
                    // instead to make sure it is sent.
                    var emailDefinition = SharedMemory.PopEmail();

                    using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
                    {
                        EmailHelper.SendRequestOwnerNotificationEmail(emailDefinition.DiscussionList, emailDefinition.Contact, smtpClient);
                        smtpClient.Disconnect(true);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        /// <summary> Gets the message archive request. </summary>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <param name="pageNumber">       (Optional) The page number. </param>
        /// <returns> A response to return to the caller. </returns>
        /// <remarks> Fulfills the <c>/List/Archive</c> request. </remarks>
        [Route("List/Archive/{discussionListID}/{pageNumber?}")]
        public IActionResult Archive(int discussionListID, int pageNumber = 1)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists
                .Where(discussionList => discussionList.ID == discussionListID)
                .SingleOrDefault();
            var messages = this.SqliteDatabase.Messages
                .Where(message => message.DiscussionListID == discussionListID)
                .Where(message => message.ParentID == null)
                .Include(message => message.OriginatorContact)
                .Include(message => message.Children)
                .Page(pageNumber, this.PageSize)
                .ToArray();
            var pageCount = this.SqliteDatabase.Messages
                .Where(message => message.DiscussionListID == discussionListID)
                .Where(message => message.ParentID == null)
                .PageCount(this.PageSize);

            var messageTree = messages.Select(message => new Tree<Message>(message,
                (branch) => this.SqliteDatabase.Messages
                .Include(child => child.OriginatorContact)
                .Where(child => child.ParentID == branch.ID)));

            var model = new ArchiveModel()
            {
                DiscussionList = discussionList,
                PageNumber = pageNumber,
                TotalPages = pageCount,
                Messages = messageTree,
                Theme = this.Theme
            };

            return View("Archive", model);
        }

        /// <summary>
        /// Searches for the <see cref="Message">messages</see> with a matching <see cref="Message.Subject">
        /// subject</see>, <see cref="Message.BodyText">body text</see>, <see cref="Message.BodyHTML">body HTML</see>, or
        /// <see cref="Message.OriginatorContact">contact</see>.
        /// </summary>
        /// <remarks> Fulfills the <c>/List/Search</c> post request. </remarks>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <param name="searchTerm">       The search term. </param>
        /// <returns> A response to return to the caller. </returns>
        /// <seealso cref="ContactController.Search(string)"/>
        [HttpPost]
        [Route("List/Search")]
        public IActionResult Search(string searchTerm, int discussionListID)
        {
            return Search(discussionListID, searchTerm, 1);
        }

        /// <summary>
        /// Searches for the <see cref="Message">messages</see> with a matching <see cref="Message.Subject">
        /// subject</see>, <see cref="Message.BodyText">body text</see>, <see cref="Message.BodyHTML">
        /// body HTML</see>, or
        /// <see cref="Message.OriginatorContact">contact</see>.
        /// </summary>
        /// <remarks> Fulfills the <c>/List/Search</c> post request. </remarks>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <param name="searchTerm">       The search term. </param>
        /// <param name="pageNumber">       (Optional) The page number. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpGet]
        [Route("List/Search/{discussionListID}/{searchTerm}/{pageNumber?}")]
        public IActionResult Search(int discussionListID, string searchTerm, int pageNumber = 1)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists
                .Where(discussionList => discussionList.ID == discussionListID)
                .SingleOrDefault();

            if (searchCache.SearchTerm != searchTerm)
            {
                var messages = Enumerable.Empty<SearchResult<Message>>();

                if (this.UseFuzzySearch)
                {
                    logger.Info(LanguageHelper.FormatValue(ResourceName.Logger_Format_PerformingFuzzySearch, searchTerm));

                    messages = this.SqliteDatabase.Messages
                    .Where(message => message.DiscussionListID == discussionListID)
                    .Include(message => message.OriginatorContact)
                    .FuzzySearch(searchTerm,
                    message => message.Subject,
                    message => message.BodyText,
                    message => message.BodyHTML,
                    message => message.OriginatorContact.Name,
                    message => message.OriginatorContact.Email)
                        .OrderByDescending(searchResult => searchResult.Score);
                }
                else
                {
                    messages = this.SqliteDatabase.Messages
                        .Where(message => message.DiscussionListID == discussionListID)
                        .Include(message => message.OriginatorContact)
                        .Search(message => message.Subject, searchTerm)
                        .Search(message => message.BodyText, searchTerm)
                        .Search(message => message.BodyHTML, searchTerm)
                        .Search(message => message.OriginatorContact.Name, searchTerm)
                        .Search(message => message.OriginatorContact.Email, searchTerm)
                        .Select(message => new SearchResult<Message>(message, 0))
                        .OrderByDescending(searchResult => searchResult.Score)
                        .AsEnumerable();
                }

                searchCache = new SearchCache<Message>(searchTerm, messages.Where(message => message.Score >= DockerEnvironmentVariables.MinimumSearchScore));
            }

            var model = new ArchiveSearchModel()
            {
                PageNumber = pageNumber,
                TotalPages = searchCache.Cache.PageCount(this.PageSize),
                IsFuzzySearch = this.UseFuzzySearch,
                DiscussionList = discussionList,
                Messages = new SearchCache<Message>(searchTerm, searchCache.Cache.Page(pageNumber, this.PageSize)),
                Theme = this.Theme
            };

            return View("ArchiveSearch", model);
        }

        /// <summary> Gets the message request. </summary>
        /// <param name="messageID">  Identifier for the message. </param>
        /// <param name="pageNumber"> (Optional) The page number. </param>
        /// <returns> A response to return to the caller. </returns>
        /// <remarks> Fulfills the <c>/List/Message</c> request. </remarks>
        [Route("List/Message/{messageID}/{pageNumber?}")]
        public IActionResult Message(int messageID, int pageNumber = 1)
        {
            var message = this.SqliteDatabase.Messages
                .Where(message => message.ID == messageID)
                .Include(message => message.OriginatorContact)
                .Include(message => message.DiscussionList)
                .SingleOrDefault();

            var children = this.SqliteDatabase.Messages
                .Where(message => message.ParentID == messageID)
                .Include(message => message.OriginatorContact)
                .Include(message => message.DiscussionList)
                .Page(pageNumber, this.PageSize);

            var pageCount = this.SqliteDatabase.Messages
                .Where(message => message.ParentID == messageID)
                .PageCount(this.PageSize);


            var model = new MessagePageModel()
            {
                Message = message,
                Children = children,
                PageNumber = pageNumber,
                TotalPages = pageCount,
                Theme = this.Theme
            };

            return View("Message", model);
        }

        #endregion
    }
}
