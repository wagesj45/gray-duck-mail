using GrayDuckMail.Common.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;

namespace GrayDuckMail.Web
{
    /// <summary> Attribute for specifying a custom view layout. </summary>
    public class ViewLayoutAttribute : ResultFilterAttribute
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary> The custom layout to be used. </summary>
        private string layout;

        #endregion

        #region Constructor

        /// <summary> Constructor. </summary>
        /// <param name="layoutName"> Name of the custom layout to be used. </param>
        public ViewLayoutAttribute(string layoutName)
        {
            this.layout = layoutName;
        }

        #endregion

        #region Methods

        /// <summary> Executes before a route method. </summary>
        /// <param name="context"> The executing context. </param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!string.IsNullOrWhiteSpace(this.layout))
            {
                var viewResult = context.Result as ViewResult;

                if (viewResult != null)
                {
                    logger.Info(LanguageHelper.FormatValue(ResourceName.Logger_Format_UsingCustomView, this.layout));
                    viewResult.ViewData["Layout"] = this.layout;
                }
            }

        } 

        #endregion
    }
}
