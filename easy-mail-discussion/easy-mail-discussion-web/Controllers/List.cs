using EasyMailDiscussion.Web.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using NLog;

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
            return View();
        }

        public IActionResult New()
        {
            return View("Edit");
        }

        public IActionResult Create(DiscussionListForm formInput)
        {
            if (formInput == null)
            {
                logger.Error("Form input was malformed or missing for /List/Create");
                return View("Error");
            }

            if(formInput.ID.HasValue)
            {
                logger.Error("Attempting to create a discussion list with an existing ID.");
                //This is wrong, but not a breaking data structure. We can safely ignore the ID.
            }



            return View("Index");
        } 

        #endregion
    }
}
