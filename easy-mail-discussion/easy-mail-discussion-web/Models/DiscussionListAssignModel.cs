using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models
{
    public class DiscussionListAssignModel
    {
        public DiscussionList DiscussionList { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

        public IEnumerable<ContactSubscription> Subscriptions { get; set; }

        public SubscriptionStatus GetSubscription(int contactID)
        {
            var subscriptionStatus = this.Subscriptions.Join(this.Contacts, outer => outer.ContactID, inner => inner.ID, (outer, inner) => new { Subscription = outer, Contact = inner })
                .Where(a => a.Subscription.DiscussionListID == this.DiscussionList.ID)
                .Select(a => a.Subscription.Status)
                .FirstOrDefault();

            return subscriptionStatus;
        }
    }
}
