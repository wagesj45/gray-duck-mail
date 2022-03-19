using MimeKit;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common
{
    /// <summary> An indexed <see cref="MimeMessage"/>. </summary>
    public class IndexedMimeMessage : MimeMessage
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        /// <summary> Gets or sets the zero-based index of this object. </summary>
        /// <value> The index. </value>
        public int Index { get; private set; }

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

        /// <summary> Indexes a <see cref="MimeMessage"/> into an <see cref="IndexedMimeMessage"/>. </summary>
        /// <param name="index">            The index. </param>
        /// <param name="origionalMessage"> Message describing the origional. </param>
        /// <returns> An IndexedMimeMessage. </returns>
        public static IndexedMimeMessage IndexMimeMessage(int index, MimeMessage origionalMessage)
        {
            var clonedMimeMessage = origionalMessage as IndexedMimeMessage;
            clonedMimeMessage.Index = index;

            return clonedMimeMessage;
        }

        #endregion
    }
}
