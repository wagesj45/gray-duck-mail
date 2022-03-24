using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models
{
    public class DiscussionListsModel
    {
        public IEnumerable<DiscussionList> DiscussionLists { get; set; } = Enumerable.Empty<DiscussionList>();
    }
}
