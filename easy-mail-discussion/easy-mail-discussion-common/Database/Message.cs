using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    public class Message
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary> Gets or sets the identifier of the email as provided by <see cref="MimeKit.MimeMessage"/>. </summary>
        /// <value> The identifier of the email as provided by <see cref="MimeKit.MimeMessage"/>. </value>
        public string EmailID { get; set; }

        /// <summary> Gets or sets the identifier of the parent. </summary>
        /// <value> The identifier of the parent. </value>
        public int? ParentID { get; set; }

        /// <summary> Gets or sets the identifier of the discussion list. </summary>
        /// <value> The identifier of the discussion list. </value>
        public int DiscussionListID { get; set; }

        /// <summary> Gets or sets the raw message. </summary>
        /// <value> The raw message. </value>
        public string Raw { get; set; }

        /// <summary> Gets or sets the subject of the email. </summary>
        /// <value> The email subject. </value>
        public string Subject { get; set; }

        /// <summary> Gets or sets the body of the email. </summary>
        /// <value> The email body. </value>
        public string BodyRaw { get; set; }

        /// <summary> Gets or sets the body HTML. </summary>
        /// <value> The body HTML. </value>
        public string BodyHTML { get; set; }

        /// <summary> Gets or sets the body text. </summary>
        /// <value> The body text. </value>
        public string BodyText { get; set; }

        /// <summary> Gets or sets the Date/Time the message was recieved. </summary>
        /// <value> The time the message was recieved. </value>
        public DateTime Recieved { get; set; }

        /// <summary> Gets or sets the identifier of the originator contact. </summary>
        /// <value> The identifier of the originator contact. </value>
        public int OriginatorContactID { get; set; }

        /// <summary> Gets or sets the parent. </summary>
        /// <value> The parent. </value>
        public virtual Message Parent { get; set; }

        /// <summary> Gets or sets the children. </summary>
        /// <value> The children. </value>
        public virtual ICollection<Message> Children { get; set; }

        /// <summary> Gets or sets a list of identifiers of the relays. </summary>
        /// <value> A list of identifiers of the relays. </value>
        public virtual ICollection<RelayIdentifier> RelayIdentifiers { get; set; }

        /// <summary> Gets or sets the originator contact. </summary>
        /// <value> The originator contact. </value>
        public virtual Contact OriginatorContact { get; set; }

        /// <summary> Gets or sets a list of discussions. </summary>
        /// <value> A list of discussions. </value>
        public virtual DiscussionList DiscussionList { get; set; }

        #endregion
    }
}
