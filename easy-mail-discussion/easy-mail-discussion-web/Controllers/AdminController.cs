using EasyMailDiscussion.Common.Database;
using EasyMailDiscussion.Web.Models;
using EasyMailDiscussion.Web.Models.Forms;
using Microsoft.AspNetCore.Authorization;
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
            return View("Index");
        }

        /// <summary> Exports the database as a downloadable file. </summary>
        /// <returns> A file stream to return to the caller. </returns>
        /// <remarks> Fulfills the <c>/Admin/ExportDatabase</c> request. </remarks>
        public FileResult ExportDatabase()
        {
            var database = System.IO.File.ReadAllBytes(SqliteDatabase.DatabaseFilePath.AbsolutePath);
            var filename = string.Format("easy-mail-discussions-{0}.db.zip", DateTime.Now.ToString("yyyy-MM-dd-HH-mm"));
            var contentType = "application/zip";

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    var entry = archive.CreateEntry(filename, CompressionLevel.Optimal);
                    using (var zipStream = entry.Open())
                    {
                        zipStream.Write(database, 0, database.Length);
                    }
                }

                return File(memoryStream.ToArray(), contentType, filename, false);
            }
        }

        [HttpPost]
        public IActionResult ImportDatabase(ImportDatabaseForm formInput)
        {
            var stream = formInput.DatabaseFile.OpenReadStream();
            System.IO.File.Delete(this.SqliteDatabase.DatabaseFilePath.AbsolutePath);
            using(var newstream = System.IO.File.Create(this.SqliteDatabase.DatabaseFilePath.AbsolutePath+".new"))
            {
                formInput.DatabaseFile.CopyTo(newstream);
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}
