using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    /// <summary> An object representing an email discussion list. </summary>
    public class DiscussionList
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary> Gets or sets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary> Gets or sets the description. </summary>
        /// <value> The description. </value>
        public string Description { get; set; }

        /// <summary> Gets or sets the contacts. </summary>
        /// <value> The contacts. </value>
        public virtual ICollection<ContactSubscription> Contacts { get; set; }

        /// <summary> Gets or sets the email server configuration. </summary>
        /// <value> The email server configuration. </value>
        public EmailConfiguration EmailServerConfiguration { get; set; }

        #endregion

        #region Constructors

        public DiscussionList()
        {
            this.Contacts = new HashSet<ContactSubscription>();
        }

        #endregion
    }
}
