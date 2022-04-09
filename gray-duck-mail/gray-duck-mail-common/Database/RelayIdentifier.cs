using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDuckMail.Common.Database
{
    /// <summary>
    /// A database storing information on the <see cref="Message.EmailID"/> of messages that were
    /// relayed to members of a <see cref="DiscussionList"/>.
    /// </summary>
    public class RelayIdentifier
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary> Gets or sets the identifier of the <see cref="Message"/> relayed to a <see cref="DiscussionList"/>. </summary>
        /// <value> The identifier of the message. </value>
        public int MessageID { get; set; }

        /// <summary> Gets or sets the <see cref="Message.EmailID"/> of the relay email. </summary>
        /// <value> The identifier of the relay email. </value>
        public string RelayEmailID { get; set; }

        /// <summary> Gets or sets the message that was relayed to a <see cref="DiscussionList"/>. </summary>
        /// <value> The message. </value>
        public virtual Message Message { get; set; }

        #endregion
    }
}
