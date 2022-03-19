using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common
{
    /// <summary> An indexed <see cref="MimeMessage"/>. </summary>
    public class IndexedMimeMessage : MimeMessage
    {
        #region Properties

        /// <summary> Gets or sets the zero-based index of this object. </summary>
        /// <value> The index. </value>
        public int Index { get; private set; }

        #endregion

        #region Constructors

        /// <summary> Constructor. </summary>
        /// <param name="index">           The index. </param>
        /// <param name="originalMessage"> Message describing the original. </param>
        public IndexedMimeMessage(int index, MimeMessage originalMessage)
        {
            this.Index = index;
        }

        #endregion
    }
}
