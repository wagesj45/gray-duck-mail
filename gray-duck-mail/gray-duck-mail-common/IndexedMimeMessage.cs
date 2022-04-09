using MimeKit;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDuckMail.Common
{
    /// <summary> An indexed <see cref="MimeMessage"/>. </summary>
    /// <remarks>
    /// The <see cref="MailKit.Net.Pop3.Pop3Client"/> works using message indexes when communicating
    /// with the remote server. Messages from
    /// <see cref="MailKit.Net.Pop3.Pop3Client.GetMessages(int, int, System.Threading.CancellationToken, MailKit.ITransferProgress)"/>
    /// do not include these indices so we must manually index them using a
    /// <see cref="System.Linq.Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, int, TResult})"/>.
    /// </remarks>
    /// <seealso cref="MailKit.Net.Pop3.Pop3Client"/>
    public class IndexedMimeMessage
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        /// <summary> Gets or sets the zero-based index of this object. </summary>
        /// <value> The index. </value>
        public int Index { get; private set; }

        /// <summary> Gets or sets the message. </summary>
        /// <value> The message. </value>
        public MimeMessage Message { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that prevents a default instance of this class from being created.
        /// </summary>
        private IndexedMimeMessage()
        {
            this.Index = -1;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Indexes a <see cref="MimeMessage"/> into an <see cref="IndexedMimeMessage"/>.
        /// </summary>
        /// <param name="index">           The index. </param>
        /// <param name="originalMessage"> The original message object. </param>
        /// <returns> An indexed message. </returns>
        public static IndexedMimeMessage IndexMimeMessage(int index, MimeMessage originalMessage)
        {
            logger.Trace("Assigning index {0} to {1}.", index, originalMessage.MessageId);

            var indexedMimeMessage = new IndexedMimeMessage
            {
                Index = index,
                Message = originalMessage
            };

            return indexedMimeMessage;
        }

        /// <summary> Tests if this object is considered equal to another. </summary>
        /// <param name="obj"> The object to compare with the current object. </param>
        /// <returns>
        /// <see langword="true" /> if the specified object  is equal to the current object; otherwise,
        /// <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is IndexedMimeMessage))
            {
                return false;
            }
            else
            {
                var message = (IndexedMimeMessage)obj;

                return message.Index == this.Index;
            }
        }

        /// <summary> Serves as the default hash function. </summary>
        /// <returns> A hash code for the current object. </returns>
        public override int GetHashCode()
        {
            return this.Index;
        }

        #endregion
    }
}
