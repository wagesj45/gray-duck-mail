using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    /// <summary>
    /// A database table that stores subscription information linking a <see cref="Contact"/> to a
    /// <see cref="DiscussionList"/>.
    /// </summary>
    public class ContactSubscription
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the <see cref="DiscussionList"/> that the
        /// <see cref="Contact"/> is assigned to.
        /// </summary>
        /// <value> The identifier of the discussion list. </value>
        public int DiscussionListID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the <see cref="Contact"/> that the
        /// <see cref="DiscussionList"/> is assigned to.
        /// </summary>
        /// <value> The identifier of the contact. </value>
        public int ContactID { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Contact"/> that the <see cref="DiscussionList"/> is assigned to.
        /// </summary>
        /// <value> The contact. </value>
        public virtual Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the subscription status of the <see cref="Contact"/> for the given
        /// <see cref="DiscussionList"/>.
        /// </summary>
        /// <value> The subscription status. </value>
        public SubscriptionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DiscussionList"/> that the <see cref="Contact"/> is assigned to.
        /// </summary>
        /// <value> A discussion list. </value>
        public virtual DiscussionList DiscussionList { get; set; }

        #endregion
    }
}
