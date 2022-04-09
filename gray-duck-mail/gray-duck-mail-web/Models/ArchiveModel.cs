using GrayDuckMail.Common;
using GrayDuckMail.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace GrayDuckMail.Web.Models
{
    /// <summary> A data model for the archive page. </summary>
    public class ArchiveModel
    {
        #region Properties
        
        /// <summary> Gets or sets a discussion list. </summary>
        /// <value> A list of discussions. </value>
        public DiscussionList DiscussionList { get; set; }

        /// <summary> Gets or sets the selected page number. </summary>
        /// <value> The page number. </value>
        public int PageNumber { get; set; }

        /// <summary> Gets or sets the total number of pages. </summary>
        /// <value> The total number of pages. </value>
        public int TotalPages { get; set; }

        /// <summary> Gets or sets the top level messages to display on the page. </summary>
        /// <value> The messages. </value>
        public IEnumerable<Tree<Message>> Messages { get; set; } = Enumerable.Empty<Tree<Message>>(); 

        #endregion
    }
}
