using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    public class RelayIdentifier
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary> Gets or sets the identifier of the message. </summary>
        /// <value> The identifier of the message. </value>
        public int MessageID { get; set; }

        /// <summary> Gets or sets the identifier of the relay email. </summary>
        /// <value> The identifier of the relay email. </value>
        public string RelayEmailID { get; set; }

        /// <summary> Gets or sets the message. </summary>
        /// <value> The message. </value>
        public virtual Message Message { get; set; }

        #endregion
    }
}
