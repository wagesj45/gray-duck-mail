using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    /// <summary> A contact that can be added to a discussion list. </summary>
    public class Contact
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary> Gets or sets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary> Gets or sets the email. </summary>
        /// <value> The email. </value>
        public string Email { get; set; } 

        /// <summary> Gets or sets a value indicating whether the contact is activated in the system. Deactivated users can no longer recieve mailings, but remain for archival purposes. </summary>
        /// <value> True if activated, false if not. </value>
        public bool Activated { get; set; }

        public virtual ICollection<ContactSubscription> ContactSubscriptions { get; set; }

        #endregion
    }
}
