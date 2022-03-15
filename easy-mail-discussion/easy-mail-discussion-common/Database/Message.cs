using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common.Database
{
    public class Message
    {
        #region Properties

        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Raw { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Recieved { get; set; }
        public Contact Originator { get; set; }

        public virtual Message Parent { get; set; }
        public virtual ICollection<Message> Children { get; set; }

        #endregion
    }
}
