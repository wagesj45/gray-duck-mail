using GrayDuckMail.Common.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Linq;
using System.Text.Json;

namespace GrayDuckMail.Web.Controllers
{
    /// <summary>
    /// A controller used as a base class in the <see cref="GrayDuckMail.Web"/> project.
    /// </summary>
    public abstract class BaseController : Controller
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary> (Immutable) The port designated for internal requests. </summary>
        internal const int INTERNAL_PORT = 80;

        /// <summary> (Immutable) The port designated for external requests. </summary>
        internal const int EXTERNAL_PORT = 5000;

        /// <summary> (Immutable) The cookie name for the fuzzy search option. </summary>
        private const string COOKIE_USE_FUZZY_SEARCH = "UseFuzzySearch";

        /// <summary> (Immutable) size of the cookie page. </summary>
        private const string COOKIE_PAGE_SIZE = "PageSize";

        /// <summary> (Immutable) the cookie theme. </summary>
        private const string COOKIE_THEME = "Theme";

        /// <summary> The application lifetime interface. </summary>
        internal IHostApplicationLifetime applicationLifetime = default;

        /// <summary> A lazily initialized SQLite database context. </summary>
        private Lazy<SqliteDatabase> sqliteDatabase = new Lazy<SqliteDatabase>(() =>
        {
            logger.Trace("Initializing database for controller.");
            return new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);
        });

        #endregion

        #region Constructors

        /// <summary> Constructor. </summary>
        /// <param name="lifetime"> The application lifetime interface. </param>
        public BaseController(IHostApplicationLifetime lifetime)
        {
            this.applicationLifetime = lifetime;
        }

        #endregion

        #region Properties

        /// <summary> Gets the SQLite database context. </summary>
        /// <value> The sqlite database. </value>
        public SqliteDatabase SqliteDatabase
        {
            get => sqliteDatabase.Value;
        }

        /// <summary> Gets or sets a value indicating whether search functions will employ fuzzy search. </summary>
        /// <value> True if use fuzzy search, false if not. </value>
        public bool UseFuzzySearch
        {
            get
            {
                if (CookieExists(COOKIE_USE_FUZZY_SEARCH))
                {
                    return GetCookie<bool>(COOKIE_USE_FUZZY_SEARCH);
                }
                else
                {
                    SetCookie(COOKIE_USE_FUZZY_SEARCH, false);
                    return false;
                }
            }
            set
            {
                SetCookie(COOKIE_USE_FUZZY_SEARCH, value);
            }
        }

        /// <summary> Gets or sets the number of items to display on a page. </summary>
        /// <value> The number of items on the page. </value>
        public int PageSize
        {
            get
            {
                if (CookieExists(COOKIE_PAGE_SIZE))
                {
                    return GetCookie<int>(COOKIE_PAGE_SIZE);
                }
                else
                {
                    SetCookie(COOKIE_PAGE_SIZE, 10);
                    return 10;
                }
            }
            set
            {
                SetCookie(COOKIE_PAGE_SIZE, value);
            }
        }

        /// <summary>
        /// Gets or sets the theme used by
        /// <see href="https://picocss.com/docs/themes.html">Pico.css</see>.
        /// </summary>
        /// <value> The Pico.css theme. </value>
        public string Theme
        {
            get
            {
                if (CookieExists(COOKIE_THEME))
                {
                    return GetCookie<string>(COOKIE_THEME);
                }
                else
                {
                    SetCookie(COOKIE_THEME, ThemeHelper.DefaultTheme);
                    return string.Empty;
                }
            }
            set
            {
                if (ThemeHelper.Themes.Contains(value))
                {
                    SetCookie(COOKIE_THEME, value);
                }
                else
                {
                    SetCookie(COOKIE_THEME, ThemeHelper.DefaultTheme);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the current request comes from the designated external port.
        /// </summary>
        /// <value> True if request comes from the external port, false if not. </value>
        public bool RequestFromExternalPort { get; set; }

        #endregion

        #region Methods

        /// <summary> Called before the action method is invoked. </summary>
        /// <remarks>
        /// This override provides logging on the path being processed by the
        /// <see cref="Microsoft.AspNetCore.Http.HttpRequest">HTTP request</see>.
        /// </remarks>
        /// <param name="context"> The action executing context. </param>
        /// <seealso cref="Controller.OnActionExecuting(ActionExecutingContext)"/>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            logger.Info("Serving page '{0}'", context.HttpContext.Request.Path);

            base.OnActionExecuting(context);
        }

        /// <summary> Sets a cookie. </summary>
        /// <param name="cookieName"> Name of the cookie. </param>
        /// <param name="value">      The value. </param>
        internal void SetCookie(string cookieName, object value)
        {
            var stringValue = string.Empty;

            if (value.GetType().IsEnum)
            {
                stringValue = Enum.GetName(value.GetType(), value);
            }
            else
            {
                stringValue = JsonSerializer.Serialize(value);
            }
            Response.Cookies.Append(cookieName, stringValue);
        }

        /// <summary>
        /// Gets a cookie. If the cookie has been set in order to be returned to the client, the Response
        /// version of the cookie is returned, otherwise the client version of the cookie is returned.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="cookieName"> Name of the cookie. </param>
        /// <returns> The cookie&lt; t&gt; </returns>
        internal T GetCookie<T>(string cookieName)
        {
            var cookie = Request.Cookies[cookieName];

            if (!string.IsNullOrWhiteSpace(cookie))
            {
                var cookieValue = cookie;

                if (typeof(T).IsEnum)
                {
                    if (Enum.TryParse(typeof(T), cookieValue, out var t))
                    {
                        return (T)t;
                    }
                }
                else
                {
                    return JsonSerializer.Deserialize<T>(cookieValue);
                }
            }

            return default(T);
        }

        /// <summary>
        /// Queries if a given cookie exists in the <see cref="Microsoft.AspNetCore.Http.HttpRequest">
        /// request</see>.
        /// </summary>
        /// <param name="cookieName"> Name of the cookie. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        internal bool CookieExists(string cookieName)
        {
            return Request.Cookies.ContainsKey(cookieName);
        }

        #endregion
    }
}
