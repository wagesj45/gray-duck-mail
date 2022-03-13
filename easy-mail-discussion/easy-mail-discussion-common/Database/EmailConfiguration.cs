using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    public class EmailConfiguration
    {
        #region Properties

        public string BaseEmailAddress { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Uri IncomingMailServer { get; set; }

        public int IncomingMailPort { get; set; }

        public Uri OutgoingMailServer { get; set; }

        public int OutgoingMailPort { get; set; }

        public bool UseSSL { get; set; }

        #endregion
    }
}
