using EasyMailDiscussion.Common;
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
    public class ListController : BaseController
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        public IActionResult Index()
        {
            var model = new DiscussionListsModel()
            {
                DiscussionLists = this.SqliteDatabase.DiscussionLists.ToArray()
            };

            return View(model);
        }

        public IActionResult New()
        {
            return View("Edit", new EditDiscussionListModel());
        }

        public IActionResult Edit(int id)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists.Where(list => list.ID == id).FirstOrDefault();

            if (discussionList == null)
            {
                logger.Error("Could not find discussion list with ID = {0}", id);
                return View("Error");
            }

            var model = new EditDiscussionListModel()
            {
                DiscussionList = discussionList
            };

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(DiscussionListForm formInput)
        {
            if (formInput == null)
            {
                logger.Error("Form input was malformed or missing for /List/Edit");
                return View("Error");
            }

            if (!formInput.ID.HasValue)
            {
                logger.Error("Attempting to edit a discussion list which does not exist.");
                return View("Error");
                //This is wrong, and we will not assume that the user was trying to create a new discussion list.
            }

            var discussionList = this.SqliteDatabase.DiscussionLists.Where(list => list.ID == formInput.ID).FirstOrDefault();

            if (discussionList == null)
            {
                logger.Error("Could not find an existing discussion list with ID {0} to edit.", formInput.ID);
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
            discussionList.UseSSL = formInput.UseSSLChecked;

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists.Where(list => list.ID == id).SingleOrDefault();

            if (discussionList == null)
            {
                logger.Error("Could not find discussion list with ID = {0}", id);
                return View("Error");
            }

            var model = new RemoveDiscussionListModel()
            {
                DiscussionList = discussionList
            };

            return View("Remove", model);
        }

        public IActionResult ConfirmRemove(int id)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists.Where(list => list.ID == id).SingleOrDefault();

            if (discussionList == null)
            {
                logger.Error("Could not find discussion list with ID = {0}", id);
                return View("Error");
            }

            this.SqliteDatabase.DiscussionLists.Remove(discussionList);

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(DiscussionListForm formInput)
        {
            if (formInput == null)
            {
                logger.Error("Form input was malformed or missing for /List/Create");
                return View("Error");
            }

            if (formInput.ID.HasValue)
            {
                logger.Error("Attempting to create a discussion list with an existing ID.");
                //This is wrong, but not a breaking data structure. We can safely ignore the ID.
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
                UseSSL = formInput.UseSSLChecked
            };

            this.SqliteDatabase.DiscussionLists.Add(discussionList);

            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Assign(int id)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists.Where(list => list.ID == id).FirstOrDefault();
            var contacts = this.SqliteDatabase.Contacts.ToArray();
            var subscriptions = this.SqliteDatabase.ContactSubscriptions.Where(subscription => subscription.DiscussionListID == id)
                .Include(subscription => subscription.Contact)
                .Include(subscription => subscription.DiscussionList)
                .ToArray();

            if (discussionList == null)
            {
                logger.Error("Could not find discussion list with ID = {0}", id);
                return View("Error");
            }

            var model = new DiscussionListAssignModel()
            {
                DiscussionList = discussionList,
                Contacts = contacts,
                Subscriptions = subscriptions
            };

            return View("Assign", model);
        }

        [HttpPost]
        public IActionResult Assign(DiscussionListAssignForm formInput)
        {
            foreach (var assignment in formInput.Assignments)
            {
                var subscription = this.SqliteDatabase.ContactSubscriptions.Where(subscription => subscription.DiscussionListID == formInput.DiscussionListID && subscription.ContactID == assignment.ContactID).FirstOrDefault();

                if (assignment.IsAssigned)
                {
                    if (subscription == null)
                    {
                        logger.Debug("Assigning Contact {0} to Discussion List {1}.", assignment.ContactID, formInput.DiscussionListID);
                        subscription = new ContactSubscription()
                        {
                            ContactID = assignment.ContactID,
                            DiscussionListID = formInput.DiscussionListID,
                            Status = SubscriptionStatus.Created
                        };
                        this.SqliteDatabase.ContactSubscriptions.Add(subscription);
                    }
                    else if(!EmailHelper.ContactAssociatedStatuses.Contains(subscription.Status))
                    {
                        logger.Debug("Assigning Contact {0} to Discussion List {1}.", assignment.ContactID, formInput.DiscussionListID);
                        subscription.Status = SubscriptionStatus.AwaitingConfirmation;
                    }
                }
                else
                {
                    if (subscription != null && EmailHelper.ContactAssociatedStatuses.Contains(subscription.Status))
                    {
                        logger.Debug("Removing Contact {0} to Discussion List {1}.", assignment.ContactID, formInput.DiscussionListID);

                        subscription.Status = SubscriptionStatus.Denied;
                    }
                }
            }

            logger.Info("Saving assignments.");
            this.SqliteDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        [Route("List/Archive/{id}/{pageNumber?}")]
        public IActionResult Archive(int id, int pageNumber = 1)
        {
            var discussionList = this.SqliteDatabase.DiscussionLists
                .Where(discussionList => discussionList.ID == id)
                .SingleOrDefault();
            var messages = this.SqliteDatabase.Messages
                .Where(message => message.DiscussionListID == id)
                .Where(message => message.ParentID == null)
                .Include(message => message.OriginatorContact)
                .Include(message => message.Children)
                .Page(pageNumber, DockerEnvironmentVariables.PageSize)
                .ToArray();
            var pageCount = this.SqliteDatabase.Messages
                .Where(message => message.DiscussionListID == id)
                .Where(message => message.ParentID == null)
                .PageCount(DockerEnvironmentVariables.PageSize);

            var model = new ArchivePageModel()
            {
                DiscussionList = discussionList,
                PageNumber = pageNumber,
                TotalPages = pageCount,
                Messages = messages
            };

            return View("Archive", model);
        }

        [Route("List/Message/{id}/{pageNumber?}")]
        public IActionResult Message(int id, int pageNumber = 1)
        {
            var message = this.SqliteDatabase.Messages
                .Where(message => message.ID == id)
                .Include(message => message.OriginatorContact)
                .Include(message => message.DiscussionList)
                .SingleOrDefault();

            var children = this.SqliteDatabase.Messages
                .Where(message => message.ParentID == id)
                .Include(message => message.OriginatorContact)
                .Include(message => message.DiscussionList)
                .Page(pageNumber, DockerEnvironmentVariables.PageSize);

            var pageCount = this.SqliteDatabase.Messages
                .Where(message => message.ParentID == id)
                .PageCount(DockerEnvironmentVariables.PageSize);


            var model = new MessagePageModel()
            {
                Message = message,
                Children = children,
                PageNumber = pageNumber,
                TotalPages = pageCount
            };

            return View("Message", model);
        }

        #endregion
    }
}
