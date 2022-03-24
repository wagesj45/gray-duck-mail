using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models
{
    /// <summary> A data model for the archive page. </summary>
    public class ArchivePageModel
    {
        public DiscussionList DiscussionList { get; set; }

        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<Message> Messages { get; set;} = Enumerable.Empty<Message>();
    }
}
