using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models
{
    /// <summary> A data model for the message page. </summary>
    public class MessagePageModel
    {
        #region Properties
        
        /// <summary> Gets or sets the message. </summary>
        /// <value> The message. </value>
        public Message Message { get; set; }

        /// <summary> Gets or sets the messages sent in reply to <see cref="Message"/>. </summary>
        /// <value> The children. </value>
        public IEnumerable<Message> Children { get; set; } = Enumerable.Empty<Message>();

        /// <summary> Gets or sets the page number. </summary>
        /// <value> The page number. </value>
        public int PageNumber { get; set; }

        /// <summary> Gets or sets the total number of pages. </summary>
        /// <value> The total number of pages. </value>
        public int TotalPages { get; set; } 

        #endregion
    }
}
