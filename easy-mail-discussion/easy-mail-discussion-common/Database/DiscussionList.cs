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

        public string BaseEmailAddress { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string IncomingMailServer { get; set; }

        public int IncomingMailPort { get; set; }

        public string OutgoingMailServer { get; set; }

        public int OutgoingMailPort { get; set; }

        public bool UseSSL { get; set; }

        /// <summary> Gets or sets the contacts. </summary>
        /// <value> The contacts. </value>
        public virtual ICollection<ContactSubscription> Subscriptions { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        #endregion
    }
}
