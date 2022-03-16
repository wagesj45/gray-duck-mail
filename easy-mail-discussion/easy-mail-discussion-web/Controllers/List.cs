using EasyMailDiscussion.Common.Database;
using EasyMailDiscussion.Web.Models;
using EasyMailDiscussion.Web.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;

namespace EasyMailDiscussion.Web.Controllers
{
    public class List : Controller
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        public IActionResult Index()
        {
            var database = new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);

            var model = new DiscussionListsModel()
            {
                DiscussionLists = database.DiscussionLists.ToArray()
            };

            return View(model);
        }

        public IActionResult New()
        {
            return View("Edit");
        }

        public IActionResult Edit(int id)
        {
            var database = new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);
            var discussionList = database.DiscussionLists.Where(list => list.ID == id).FirstOrDefault();

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

            var database = new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);

            var discussionList = database.DiscussionLists.Where(list => list.ID == formInput.ID).FirstOrDefault();

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

            database.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var database = new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);
            var discussionList = database.DiscussionLists.Where(list => list.ID == id).FirstOrDefault();

            if (discussionList == null)
            {
                logger.Error("Could not find discussion list with ID = {0}", id);
                return View("Error");
            }

            var model = new EditDiscussionListModel()
            {
                DiscussionList = discussionList
            };

            return View("Remove", model);
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

            var database = new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);

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

            database.DiscussionLists.Add(discussionList);

            database.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
