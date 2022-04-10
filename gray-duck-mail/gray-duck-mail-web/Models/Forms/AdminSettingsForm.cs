namespace GrayDuckMail.Web.Models.Forms
{
    /// <summary> A model for the input governing the web administration settings. </summary>
    public class AdminSettingsForm : BaseFormInput<AdminSettingsForm>
    {
        #region Properties

        /// <summary> Gets or sets a value indicating whether search functions will employ fuzzy search. </summary>
        /// <value> True if fuzzy search is allowed, false if not. </value>
        /// <seealso cref="Controllers.BaseController.UseFuzzySearch"/>
        public string UseFuzzySearch { get; set; }

        /// <summary> Gets or sets the number of items to display on a page. </summary>
        /// <value> The number of items on the page. </value>
        /// <seealso cref="Controllers.BaseController.PageSize"/>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the theme used by
        /// <see href="https://picocss.com/docs/themes.html">Pico.css</see>.
        /// </summary>
        /// <value> The theme. </value>
        public string Theme { get; set; }

        #endregion
    }
}
