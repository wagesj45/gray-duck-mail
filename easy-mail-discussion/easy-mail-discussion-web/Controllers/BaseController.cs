using EasyMailDiscussion.Common.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;

namespace EasyMailDiscussion.Web.Controllers
{
    /// <summary>
    /// A controller used as a base class in the <see cref="EasyMailDiscussion.Web"/> project.
    /// </summary>
    public class BaseController : Controller
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary> A lazily initialized SQLite database context. </summary>
        private Lazy<SqliteDatabase> sqliteDatabase = new Lazy<SqliteDatabase>(() =>
        {
            logger.Trace("Initializing database for controller.");
            return new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);
        });

        #endregion

        #region Properties
        
        /// <summary> Gets the SQLite database context. </summary>
        /// <value> The sqlite database. </value>
        public SqliteDatabase SqliteDatabase
        {
            get => sqliteDatabase.Value;
        }

        #endregion

        #region Methods

        /// <summary> Called before the action method is invoked. </summary>
        /// <remarks>
        /// This override provides logging on the path being processed by the
        /// <see cref="Microsoft.AspNetCore.Http.HttpRequest">HTTP request</see>.
        /// </remarks>
        /// <param name="context"> The action executing context. </param>
        /// <seealso cref="Controller.onac"/>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            logger.Info("Serving page '{0}'", context.HttpContext.Request.Path);

            base.OnActionExecuting(context);
        } 

        #endregion
    }
}
