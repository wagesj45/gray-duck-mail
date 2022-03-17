﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    /// <summary> Values that represent subscription status of a contact in a discussion list. </summary>
    public enum SubscriptionStatus
    {
        /// <summary> No assignment can be determined. </summary>
        Unknown = 0,
        /// <summary> The contact has been assigned to a list, but has not yet been sent a confirmation message. </summary>
        Created = 1,
        /// <summary> The contact has been added to the discussion list, but has not confirmed their subscription. </summary>
        Inactive = 2,
        /// <summary> The contact has confirmed their subscription to the discussion list. </summary>
        Subscribed = 3,
        /// <summary> The contact has requested to be unsubscripted from the discussion list. </summary>
        Unsubscribed = 4
    }
}
