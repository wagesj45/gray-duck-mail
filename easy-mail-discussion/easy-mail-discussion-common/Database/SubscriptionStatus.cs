using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    /// <summary> Values that represent subscription status of a contact in a discussion list. </summary>
    /// <remarks> These  </remarks>
    public enum SubscriptionStatus
    {
        /// <summary> No assignment can be determined. </summary>
        Unknown = 0,
        /// <summary> The contact has been assigned to a list, but has not yet been sent a confirmation message. </summary>
        Created = 1,
        /// <summary> The contact has been added to the discussion list, but has not confirmed their subscription. </summary>
        AwaitingConfirmation = 2,
        /// <summary> The contact has confirmed their subscription to the discussion list. </summary>
        Subscribed = 3,
        /// <summary> The contact has requested to be unsubscripted from the discussion list. </summary>
        Unsubscribed = 4,
        /// <summary> The contact has requested access to a discussion list. </summary>
        Requested = 5,
        /// <summary> The contact has been denied access to the discussion list by the owner. </summary>
        Denied = 6,
        /// <summary> The contact's email address bounced for this discussion list. </summary>
        Bounced = 7
    }
}
