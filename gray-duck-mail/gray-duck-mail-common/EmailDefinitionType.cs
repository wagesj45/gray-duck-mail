using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDuckMail.Common
{
    /// <summary> Values that represent the types of email sent by the system. </summary>
    public enum EmailDefinitionType
    {
        /// <summary> The default email type. If this is chosen, an error has likely occurred. </summary>
        Unknown = 0,
        /// <summary> A relayed email from a discussion list member. </summary>
        Relay = 1,
        /// <summary> A message sent to newly added list members. </summary>
        Onboarding = 2,
        /// <summary> A message sent to the owner of the discussion list. </summary>
        RequestOwnerNotification = 3,
        /// <summary> Confirms that a new user has been subscribed to the discussion list. </summary>
        SubscriptionConfirmation = 4,
        /// <summary> Confirmation that a user has been removed from a discussion list. </summary>
        UbsubscriptionConfirmation = 5
    }
}
