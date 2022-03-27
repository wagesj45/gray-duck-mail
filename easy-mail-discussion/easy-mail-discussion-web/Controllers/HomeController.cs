using EasyMailDiscussion.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMailDiscussion.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Members
        
        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods
        
        public IActionResult Index()
        {
            var numberOfDiscussionLists = this.SqliteDatabase.DiscussionLists.Count();
            var numberOfMessages = this.SqliteDatabase.Messages.Count();
            var numberOfContacts = this.SqliteDatabase.Contacts.Count();

            var model = new HomepageModel()
            {
                NumberOfDiscussionLists = numberOfDiscussionLists,
                NumberOfMessages = numberOfMessages,
                NumberOfContacts = numberOfContacts
            };

            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 

        #endregion
    }
}
