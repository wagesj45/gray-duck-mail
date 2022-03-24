using MimeKit;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common
{
    /// <summary> An indexed <see cref="MimeMessage"/>. </summary>
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
        /// <returns> An IndexedMimeMessage. </returns>
        public static IndexedMimeMessage IndexMimeMessage(int index, MimeMessage originalMessage)
        {
            var indexedMimeMessage = new IndexedMimeMessage
            {
                Index = index,
                Message = originalMessage
            };

            return indexedMimeMessage;
        }

        /// <summary> Determines whether the specified object is equal to the current object. </summary>
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
