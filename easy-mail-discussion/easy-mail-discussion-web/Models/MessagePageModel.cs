using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models
{
    /// <summary> A data model for the message page. </summary>
    public class MessagePageModel
    {
        public Message Message { get; set; }

        public IEnumerable<Message> Children { get; set; } = Enumerable.Empty<Message>();

        public int PageNumber { get; set; }

        public int TotalPages { get; set; }
    }
}
