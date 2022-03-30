using EasyMailDiscussion.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMailDiscussion.Web.Controllers
{
    /// <summary> Handles web requests for the default landing pages. </summary>
    public class HomeController : BaseController
    {
        #region Members
        
        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors
        
        /// <summary> Constructor. </summary>
        /// <param name="lifetime"> The application lifetime interface. </param>
        public HomeController(IHostApplicationLifetime lifetime)
            : base(lifetime)
        {
            //
        }

        #endregion

        #region Methods

        /// <summary> Gets the index or default request. </summary>
        /// <remarks>
        /// <para>
        /// Fulfills the <c>/</c> request.
        /// </para>
        /// <para>
        /// This is the main landing page for the application.
        /// </para>
        /// </remarks>
        /// <returns> A response to return to the caller. </returns>
        [Route("/")]
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

        /// <summary> Gets the error page. </summary>
        /// <returns> A response to return to the caller. </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 

        #endregion
    }
}
