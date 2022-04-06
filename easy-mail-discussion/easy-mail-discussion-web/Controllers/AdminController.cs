using EasyMailDiscussion.Common.Database;
using EasyMailDiscussion.Web.Models;
using EasyMailDiscussion.Web.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace EasyMailDiscussion.Web.Controllers
{
    /// <summary> Handles web requests for <see cref="Contact"/> manipulation operations. </summary>
    public class AdminController : BaseController
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary> Constructor. </summary>
        /// <param name="lifetime"> The lifetime. </param>
        public AdminController(IHostApplicationLifetime lifetime)
            : base(lifetime)
        {
            //
        }

        #endregion

        #region Methods

        /// <summary> Gets the index or default request. </summary>
        /// <remarks> Fulfills the <c>/Admin</c> request. </remarks>
        /// <returns> A response to return to the caller. </returns>
        [Route("Admin")]
        public IActionResult Index()
        {
            var model = new AdminModel()
            {
                UseFuzzySearch = this.UseFuzzySearch,
                PageSize = this.PageSize
            };

            return View("Index", model);
        }

        /// <summary> Exports the database as a downloadable file. </summary>
        /// <remarks> Fulfills the <c>/Admin/ExportDatabase</c> request. </remarks>
        /// <returns> A file stream to return to the caller. </returns>
        [Route("Admin/ExportDatabase")]
        public FileResult ExportDatabase()
        {
            var database = System.IO.File.ReadAllBytes(SqliteDatabase.DatabaseFilePath.AbsolutePath);
            var filename = string.Format("easy-mail-discussions-{0}.db", DateTime.Now.ToString("yyyy-MM-dd-HH-mm"));

            return File(database, SqliteDatabase.SQLITE_FILE_CONTENT_TYPE, filename, false);
        }

        /// <summary> Imports a SQLite database file and replaces the existing database file. </summary>
        /// <remarks>
        /// <para>
        /// Fulfills the <c>/Admin/ImportDatabase</c> post request.
        /// </para>
        /// <para>
        /// This method will initiate an application shut down. This is necessary because multiple
        /// service worker threads access the database file and we can never be sure that it is not being
        /// accessed except at application
        /// <see cref="Startup.Startup(Microsoft.Extensions.Configuration.IConfiguration)">start up</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="FormatException">
        ///     Thrown when the format of an input is incorrect.
        /// </exception>
        /// <param name="formInput"> The form input. </param>
        /// <returns> A response to return to the caller. </returns>
        /// <seealso cref="Program.Main(string[])"/>
        /// <seealso cref="Startup.Startup(Microsoft.Extensions.Configuration.IConfiguration)"/>
        /// <seealso cref="Startup.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Hosting.IWebHostEnvironment, IHostApplicationLifetime)"/>
        /// <seealso cref="Startup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
        [HttpPost]
        public IActionResult ImportDatabase(ImportDatabaseForm formInput)
        {
            if (formInput.DatabaseFile == null)
            {
                var nullException = new ArgumentException("The file uploaded is missing or was malformed.", nameof(formInput));
            }

            if (!SqliteDatabase.IsValidContentType(formInput.DatabaseFile.ContentType))
            {
                var formatException = new FormatException("The file upload was not in the corref SQLite file format.");
                logger.Error(formatException);

                throw formatException;
            }

            using (var stream = formInput.DatabaseFile.OpenReadStream())
            {
                using (var importedDatabaseStream = System.IO.File.Create(this.SqliteDatabase.ImportedDatabaseFilePath.AbsolutePath))
                {
                    // Write the imported database to the file system with a temporary file name.
                    formInput.DatabaseFile.CopyTo(importedDatabaseStream);
                }

                // Stop the ASP application so that the database file will be released by all contexts.
                // This will allow us to replace it at start up.
                this.applicationLifetime.StopApplication();
            }

            return RedirectToAction("Index");
        }

        /// <summary> Saves web administration settings. </summary>
        /// <param name="formInput"> The form input. </param>
        /// <returns> A response to return to the caller. </returns>
        [HttpPost]
        public IActionResult SaveSettings(AdminSettingsForm formInput)
        {
            this.UseFuzzySearch = formInput.IsChecked(f => f.UseFuzzySearch);
            this.PageSize = formInput.PageSize;

            return RedirectToAction("Index");
        }

        #endregion
    }
}
