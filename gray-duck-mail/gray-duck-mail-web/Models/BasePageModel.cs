namespace GrayDuckMail.Web.Models
{
    /// <summary> A data model that contains shared data between all views. </summary>
    /// <remarks> This is the model used by the shared <c>_Layout.cshtml</c> partial view.  </remarks>
    public class BasePageModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the theme used by
        /// <see href="https://picocss.com/docs/themes.html">Pico.css</see>.
        /// </summary>
        /// <value> The theme. </value>
        public string Theme { get; set; }

        #endregion
    }
}
