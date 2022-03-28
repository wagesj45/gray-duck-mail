using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models
{
    /// <summary> A data model for the contacts page. </summary>
    public class HomepageModel
    {
        #region Properties

        /// <summary> Gets or sets the number of discussion lists. </summary>
        /// <value> The total number of discussion lists. </value>
        public int NumberOfDiscussionLists { get; set; }

        /// <summary> Gets or sets the number of messages. </summary>
        /// <value> The total number of messages. </value>
        public int NumberOfMessages { get; set; }

        /// <summary> Gets or sets the number of contacts. </summary>
        /// <value> The total number of contacts. </value>
        public int NumberOfContacts { get; set; }

        #endregion
    }
}
