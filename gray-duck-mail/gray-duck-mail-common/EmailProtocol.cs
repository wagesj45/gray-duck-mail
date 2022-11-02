using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDuckMail.Common
{
    /// <summary> Values that represent email protocols for the <see cref="EmailClientWrapper"/>. </summary>
    /// <seealso cref="EmailClientWrapper"/>
    public enum EmailProtocol
    {
        /// <summary> The default email type. If this is chosen, an error has likely occurred. </summary>
        Unknown = 0,
        /// <summary> An email client that connects using the <see href="https://en.wikipedia.org/wiki/Post_Office_Protocol">POP3</see> protocol. </summary>
        POP3 = 1,
        /// <summary> An email client that connects using the <see href="https://en.wikipedia.org/wiki/Internet_Message_Access_Protocol">IMAP</see> protocol. </summary>
        IMAP = 2
    }
}
