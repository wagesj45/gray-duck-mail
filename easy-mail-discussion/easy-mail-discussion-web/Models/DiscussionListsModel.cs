using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;

namespace EasyMailDiscussion.Web.Models
{
    public class DiscussionListsModel
    {
        public IEnumerable<DiscussionList> DiscussionLists { get; set; }
    }
}
