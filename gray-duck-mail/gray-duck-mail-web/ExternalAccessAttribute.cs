using GrayDuckMail.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;

namespace GrayDuckMail.Web
{
    /// <summary> Attribute for declaring a controller route method as accessable externally. </summary>
    /// <seealso cref="BaseController.INTERNAL_PORT"/>
    /// <seealso cref="BaseController.EXTERNAL_PORT"/>
    /// <seealso href="http://grayduckmail.com/security.html"/>
    public class ExternalAccessAttribute : ActionFilterAttribute
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        /// <summary> Called before the action method is invoked. </summary>
        /// <param name="filterContext"> Context for the filter. </param>
        /// <remarks> Logs executing actions that are decorated with this attribute. </remarks>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var localPort = filterContext.HttpContext.Connection.LocalPort;

            if (localPort == BaseController.INTERNAL_PORT)
            {
                logger.Debug("The request is being processed from the designated internal port.");
            }
            else if (localPort == BaseController.EXTERNAL_PORT)
            {
                logger.Info("The request is being processed from the designated external port. Request Origin: {0}", filterContext.HttpContext.Connection.RemoteIpAddress);
            }
            else
            {
                logger.Error("The request is being processed from an unknown port ({0})). The docker container is likely misconfigured. Remote Origin: {1}", localPort, filterContext.HttpContext.Connection.RemoteIpAddress);
            }
        } 

        #endregion
    }
}
