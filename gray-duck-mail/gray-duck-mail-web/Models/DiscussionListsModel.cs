using GrayDuckMail.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace GrayDuckMail.Web.Models
{
    /// <summary> A data model for the discussion list page. </summary>
    public class DiscussionListsModel
    {
        #region Properties
        
        /// <summary> Gets or sets the discussion lists to display on the page. </summary>
        /// <value> The discussion lists. </value>
        public IEnumerable<DiscussionList> DiscussionLists { get; set; } = Enumerable.Empty<DiscussionList>();

        /// <summary> Gets or sets the page number. </summary>
        /// <value> The page number. </value>
        public int PageNumber { get; set; }

        /// <summary> Gets or sets the total number of pages. </summary>
        /// <value> The total number of pages. </value>
        public int TotalPages { get; set; }

        #endregion
    }
}
