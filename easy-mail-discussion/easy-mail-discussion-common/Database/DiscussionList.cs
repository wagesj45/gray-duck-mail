using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    /// <summary>
    /// A database table that stores information describing an email discussion and distribution list.
    /// </summary>
    public class DiscussionList
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary> Gets or sets the name of the discussion list. </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary> Gets or sets the description of the discussion list and its purpose. </summary>
        /// <value> The description. </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the base email address. This is the primary address used by the application to
        /// relay messages to other <see cref="Contact">members of the discussion list</see>.
        /// </summary>
        /// <value> The base email address. </value>
        public string BaseEmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the user name used when connecting to the remote
        /// <see cref="IncomingMailServer"/> and the <see cref="OutgoingMailServer"/>.
        /// </summary>
        /// <value> The name of the user. </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password used when connecting to the remote <see cref="IncomingMailServer"/>
        /// and the <see cref="OutgoingMailServer"/>.
        /// </summary>
        /// <value> The password. </value>
        public string Password { get; set; }

        /// <summary> Gets or sets the web address of the incoming mail server. </summary>
        /// <value> The incoming mail server. </value>
        public string IncomingMailServer { get; set; }

        /// <summary> Gets or sets the port number of incoming mail server. </summary>
        /// <value> The incoming mail port. </value>
        public int IncomingMailPort { get; set; }

        /// <summary> Gets or sets the web address of the outgoing SMTP server. </summary>
        /// <value> The outgoing mail server. </value>
        public string OutgoingMailServer { get; set; }

        /// <summary> Gets or sets the port number of the outgoing SMTP server. </summary>
        /// <value> The outgoing mail port. </value>
        public int OutgoingMailPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="IncomingMailServer"/> and
        /// <see cref="OutgoingMailServer"/> connection connect with SSL encryption.
        /// </summary>
        /// <value> True if use ssl, false if not. </value>
        public bool UseSSL { get; set; }

        /// <summary> Gets or sets the subscriptions to various discussion lists.. </summary>
        /// <value> The contact subscriptions. </value>
        public virtual ICollection<ContactSubscription> Subscriptions { get; set; }

        /// <summary> Gets or sets the messages that people associated with this list have sent. </summary>
        /// <value> The messages. </value>
        public virtual ICollection<Message> Messages { get; set; }

        #endregion
    }
}
