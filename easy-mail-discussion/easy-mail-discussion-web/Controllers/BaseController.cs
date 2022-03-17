using EasyMailDiscussion.Common.Database;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;

namespace EasyMailDiscussion.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
    }
}
