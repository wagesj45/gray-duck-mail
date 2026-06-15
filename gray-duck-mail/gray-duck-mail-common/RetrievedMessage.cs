using GrayDuckMail.Common.Localization;
using MailKit;
using MimeKit;
using NLog;
using System;

namespace GrayDuckMail.Common
{
    /// <summary>
    /// A <see cref="MimeMessage"/> retrieved from a mail server together with the identifiers
    /// required to delete it over POP3 or IMAP.
    /// </summary>
    public class RetrievedMessage
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        /// <summary> Gets the message. </summary>
        /// <value> The message. </value>
        public MimeMessage Message { get; private set; }

        /// <summary>
        /// Gets the zero-based POP3 message index when fetched over POP3.
        /// </summary>
        /// <value> The POP3 index, if applicable. </value>
        public int? Pop3Index { get; private set; }

        /// <summary>
        /// Gets the IMAP unique identifier when fetched over IMAP.
        /// </summary>
        /// <value> The IMAP unique identifier, if applicable. </value>
        public UniqueId? ImapUniqueId { get; private set; }

        /// <summary> Gets a log-friendly server identifier (POP3 index or IMAP UID). </summary>
        /// <value> The server identifier. </value>
        public string ServerIdentifier
        {
            get
            {
                if (this.Pop3Index.HasValue)
                {
                    return this.Pop3Index.Value.ToString();
                }

                if (this.ImapUniqueId.HasValue)
                {
                    return this.ImapUniqueId.Value.ToString();
                }

                return "?";
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that prevents a default instance of this class from being created.
        /// </summary>
        private RetrievedMessage()
        {
        }

        #endregion

        #region Methods

        /// <summary> Creates a retrieved message from a POP3 fetch result. </summary>
        /// <param name="pop3Index"> The POP3 message index. </param>
        /// <param name="message">   The message. </param>
        /// <returns> A retrieved message. </returns>
        public static RetrievedMessage FromPop3(int pop3Index, MimeMessage message)
        {
            logger.Trace(LanguageHelper.FormatValue(ResourceName.Logger_Format_AssigningMimeMessageIndex, pop3Index, message.MessageId));

            return new RetrievedMessage
            {
                Pop3Index = pop3Index,
                Message = message
            };
        }

        /// <summary> Creates a retrieved message from an IMAP fetch result. </summary>
        /// <param name="imapUniqueId"> The IMAP unique identifier. </param>
        /// <param name="message">      The message. </param>
        /// <returns> A retrieved message. </returns>
        public static RetrievedMessage FromImap(UniqueId imapUniqueId, MimeMessage message)
        {
            logger.Trace(LanguageHelper.FormatValue(ResourceName.Logger_Format_AssigningMimeMessageIndex, imapUniqueId, message.MessageId));

            return new RetrievedMessage
            {
                ImapUniqueId = imapUniqueId,
                Message = message
            };
        }

        /// <summary> Tests if this object is considered equal to another. </summary>
        /// <param name="obj"> The object to compare with the current object. </param>
        /// <returns>
        /// <see langword="true" /> if the specified object  is equal to the current object; otherwise,
        /// <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is RetrievedMessage other))
            {
                return false;
            }

            return this.Pop3Index == other.Pop3Index
                && this.ImapUniqueId == other.ImapUniqueId
                && this.Message?.MessageId == other.Message?.MessageId;
        }

        /// <summary> Serves as the default hash function. </summary>
        /// <returns> A hash code for the current object. </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Pop3Index, this.ImapUniqueId, this.Message?.MessageId);
        }

        #endregion
    }
}
