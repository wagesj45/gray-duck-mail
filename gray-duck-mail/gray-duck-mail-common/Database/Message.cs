using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDuckMail.Common.Database
{
    /// <summary> A database table that . </summary>
    public class Message
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary> Gets or sets the identifier of the email as provided by <see cref="MimeKit.MimeMessage.MessageId"/>. </summary>
        /// <value> The identifier of the email as provided by <see cref="MimeKit.MimeMessage.MessageId"/>. </value>
        public string EmailID { get; set; }

        /// <summary> Gets or sets the identifier of the parent message if this message was sent as a reply. </summary>
        /// <value> The identifier of the parent message. </value>
        public int? ParentID { get; set; }

        /// <summary> Gets or sets the identifier of the <see cref="DiscussionList"/> this message was relayed to. </summary>
        /// <value> The identifier of the discussion list. </value>
        public int DiscussionListID { get; set; }

        /// <summary>
        /// Gets or sets the raw MIME text content of the original <see cref="MimeKit.MimeMessage"/>.
        /// </summary>
        /// <value> The raw message content. </value>
        public string Raw { get; set; }

        /// <summary> Gets or sets the subject of the original <see cref="MimeKit.MimeMessage.Subject"/>. </summary>
        /// <value> The email subject. </value>
        public string Subject { get; set; }

        /// <summary> Gets or sets the raw contents of the original email body as provided by <see cref="MimeKit.MimeMessage.Body"/>. </summary>
        /// <value> The email body. </value>
        public string BodyRaw { get; set; }

        /// <summary>
        /// Gets or sets the HTML code, if present, in the original email as provided by
        /// <see cref="MimeKit.MimeMessage.HtmlBody"/>.
        /// </summary>
        /// <value> The HTML code of the body. </value>
        public string BodyHTML { get; set; }

        /// <summary>
        /// Gets or sets the plain text, if present, in the original email as provided by
        /// <see cref="MimeKit.MimeMessage.TextBody"/>.
        /// </summary>
        /// <value> The text of the body. </value>
        public string BodyText { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DateTime">date and time</see> the message was recieved and
        /// processed by the system.
        /// </summary>
        /// <value> The time the message was recieved. </value>
        public DateTime Recieved { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the <see cref="Contact"/> that sent the message to the
        /// discussion list.
        /// </summary>
        /// <value> The identifier of the originator contact. </value>
        public int OriginatorContactID { get; set; }

        /// <summary>
        /// Gets or sets the message that this message was a response to, if it exists. If this is the
        /// first message in a chain, the parent will be <see langword="null"/>.
        /// </summary>
        /// <value> The parent message. </value>
        public virtual Message Parent { get; set; }

        /// <summary> Gets or sets the messages sent in response to this message, if any exist. </summary>
        /// <value> The children. </value>
        public virtual ICollection<Message> Children { get; set; }

        /// <summary> Gets or sets a list of identifiers of the <see cref="RelayIdentifier">relay identifiers</see>. </summary>
        /// <value> A list of relay identifiers. </value>
        public virtual ICollection<RelayIdentifier> RelayIdentifiers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Contact"/> that sent this message to the
        /// <see cref="DiscussionList"/>.
        /// </summary>
        /// <value> The original sender. </value>
        public virtual Contact OriginatorContact { get; set; }

        /// <summary> Gets or sets the discussion list this <see cref="Message"/> was sent to. </summary>
        /// <value> The discussion list. </value>
        public virtual DiscussionList DiscussionList { get; set; }

        #endregion
    }
}
