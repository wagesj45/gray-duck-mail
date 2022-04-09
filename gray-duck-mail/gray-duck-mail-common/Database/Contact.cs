using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDuckMail.Common.Database
{
    /// <summary>
    /// A database table that stores information on individual people that can be assigned to a
    /// <see cref="DiscussionList"/>.
    /// </summary>
    public class Contact
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary> Gets or sets the name of the person. </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary> Gets or sets the email address of the person. </summary>
        /// <value> The email. </value>
        public string Email { get; set; } 

        /// <summary>
        /// Gets or sets a value indicating whether the contact is activated in the system. Deactivated
        /// users can no longer recieve mailings, but remain for archival purposes.
        /// </summary>
        /// <value> True if activated, false if not. </value>
        public bool Activated { get; set; }

        /// <summary> Gets or sets the subscriptions to various discussion lists. </summary>
        /// <value> The contact subscriptions. </value>
        public virtual ICollection<ContactSubscription> ContactSubscriptions { get; set; }

        /// <summary> Gets or sets the messages this person has sent to various discussion lists. </summary>
        /// <value> The messages. </value>
        public virtual ICollection<Message> Messages { get; set; }

        #endregion
    }
}
