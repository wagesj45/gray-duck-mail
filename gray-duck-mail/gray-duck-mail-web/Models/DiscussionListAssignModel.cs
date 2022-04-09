using GrayDuckMail.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace GrayDuckMail.Web.Models
{
    /// <summary> A data model for the discussion list assignment page. </summary>
    public class DiscussionListAssignModel
    {
        #region Properties
        
        /// <summary> Gets or sets a discussion list . </summary>
        /// <value> A list of discussions. </value>
        public DiscussionList DiscussionList { get; set; }

        /// <summary> Gets or sets the contacts to display on the page. </summary>
        /// <value> The contacts. </value>
        public IEnumerable<Contact> Contacts { get; set; } = Enumerable.Empty<Contact>();

        /// <summary> Gets or sets the subscription statuses to display on the page. </summary>
        /// <value> The subscriptions. </value>
        public IEnumerable<ContactSubscription> Subscriptions { get; set; } = Enumerable.Empty<ContactSubscription>(); 

        #endregion

        #region Methods

        /// <summary> Gets a subscription status for a <see cref="Contact"/>. </summary>
        /// <param name="contactID"> Identifier for the contact. </param>
        /// <returns> The subscription. </returns>
        public SubscriptionStatus GetSubscription(int contactID)
        {
            var subscriptionStatus = this.Subscriptions
                .Where(subscription => subscription.ContactID == contactID)
                .Where(subscription => subscription.DiscussionListID == this.DiscussionList.ID)
                .Select(subscription => subscription.Status)
                .FirstOrDefault();

            return subscriptionStatus;
        }

        /// <summary> Query if a <see cref="Contact"/> has an established subscription status. </summary>
        /// <param name="contactID"> Identifier for the contact. </param>
        /// <returns>
        /// True if the <see cref="Contact"/> has an established subscription status, false if not.
        /// </returns>
        public bool HasSubscription(int contactID)
        {
            return this.Subscriptions.Where(a => a.ContactID == contactID).Any();
        } 

        #endregion
    }
}
