using EasyMailDiscussion.Common;
using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models
{
    /// <summary> A data model for the contacts page. </summary>
    public class ContactSearchModel
    {
        #region Properties

        /// <summary> Gets or sets the page number. </summary>
        /// <value> The page number. </value>
        public int PageNumber { get; set; }

        /// <summary> Gets or sets the total number of pages. </summary>
        /// <value> The total number of pages. </value>
        public int TotalPages { get; set; }

        /// <summary> Gets or sets a value indicating whether this search was a fuzzy search. </summary>
        /// <value> True if this search is a fuzzy search, false if not. </value>
        public bool IsFuzzySearch { get; set; }
        
        /// <summary> Gets or sets the contacts to display on the page. </summary>
        /// <value> The contacts. </value>
        public SearchCache<Contact> Contacts { get; set; }

        #endregion
    }
}
