namespace EasyMailDiscussion.Web.Models
{
    /// <summary> A data model for the administration page. </summary>
    public class AdminModel
    {
        #region Properties

        /// <summary> Gets or sets a value indicating whether search functions will employ fuzzy search. </summary>
        /// <value> True if fuzzy search is allowed, false if not. </value>
        public bool UseFuzzySearch { get; set; }

        /// <summary> Gets or sets the number of items to display on a page. </summary>
        /// <value> The number of items on the page. </value>
        public int PageSize { get; set; }

        #endregion
    }
}
