using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models
{
    public class DiscussionListAssignModel
    {
        public DiscussionList DiscussionList { get; set; }

        public IEnumerable<Contact> Contacts { get; set; } = Enumerable.Empty<Contact>();

        public IEnumerable<ContactSubscription> Subscriptions { get; set; } = Enumerable.Empty<ContactSubscription>();

        public SubscriptionStatus GetSubscription(int contactID)
        {
            var subscriptionStatus = this.Subscriptions
                .Where(subscription => subscription.ContactID == contactID)
                .Where(subscription => subscription.DiscussionListID == this.DiscussionList.ID)
                .Select(subscription => subscription.Status)
                .FirstOrDefault();

            return subscriptionStatus;
        }

        public bool HasSubscription(int contactID)
        { 
            return this.Subscriptions.Where(a => a.ContactID == contactID).Any();
        }
    }
}
