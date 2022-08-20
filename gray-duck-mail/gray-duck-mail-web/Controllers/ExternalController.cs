using GrayDuckMail.Common.Database;
using GrayDuckMail.Web.Models;
using GrayDuckMail.Web.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace GrayDuckMail.Web.Controllers
{
    /// <summary> Handles web requests from external sources. </summary>
    public class ExternalController : BaseController
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary> Constructor. </summary>
        /// <param name="lifetime"> The lifetime. </param>
        public ExternalController(IHostApplicationLifetime lifetime)
            : base(lifetime)
        {
            //
        }

        #endregion

        #region Methods

        /// <summary> Gets the index or default request. </summary>
        /// <remarks> Fulfills the <c>/Admin</c> request. </remarks>
        /// <returns> A response to return to the caller. </returns>
        [Route("/Unsubscribe")]
        public IActionResult Unsubscribe()
        {
            var model = new AdminModel()
            {
                UseFuzzySearch = this.UseFuzzySearch,
                PageSize = this.PageSize,
                Theme = this.Theme
            };

            return View("Index", model);
        }

        #endregion
    }
}
