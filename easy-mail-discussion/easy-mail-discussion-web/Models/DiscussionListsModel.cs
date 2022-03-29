using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models
{
    /// <summary> A data model for the discussion list page. </summary>
    public class DiscussionListsModel
    {
        #region Properties
        
        /// <summary> Gets or sets the discussion lists to display on the page. </summary>
        /// <value> The discussion lists. </value>
        public IEnumerable<DiscussionList> DiscussionLists { get; set; } = Enumerable.Empty<DiscussionList>(); 

        #endregion
    }
}
