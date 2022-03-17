using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    /// <summary>
    /// An object representing a <see cref="Contact"/>'s subscription status with a discussion list.
    /// </summary>
    public class ContactSubscription
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary> Gets or sets the identifier of the discussion list. </summary>
        /// <value> The identifier of the discussion list. </value>
        public int DiscussionListID { get; set; }

        /// <summary> Gets or sets the identifier of the contact. </summary>
        /// <value> The identifier of the contact. </value>
        public int ContactID { get; set; }

        /// <summary> Gets or sets the contact. </summary>
        /// <value> The contact. </value>
        public virtual Contact Contact { get; set; }

        /// <summary> Gets or sets the subscription status of the <see cref="Contact"/>. </summary>
        /// <value> The status. </value>
        public SubscriptionStatus Status { get; set; }

        /// <summary> Gets or sets a discussion list. </summary>
        /// <value> A discussion list. </value>
        public virtual DiscussionList DiscussionList { get; set; }

        #endregion
    }
}
