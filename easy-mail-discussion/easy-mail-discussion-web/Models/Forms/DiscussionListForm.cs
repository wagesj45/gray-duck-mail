namespace EasyMailDiscussion.Web.Models.Forms
{
    /// <summary> Model for the form input creating or modifying discussion list.. </summary>
    public class DiscussionListForm
    {
        #region Properties

        public int? ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string BaseEmailAddress { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string IncomingMailServer { get; set; }

        public int IncomingMailPort { get; set; }
        
        public string OutgoingMailServer { get; set; }

        public int OutgoingMailPort { get; set; }

        public string UseSSL { get; set; }

        public bool UseSSLChecked
        {
            get
            {
                return (this.UseSSL ?? string.Empty).Length > 0;
            }
        }

        #endregion
    }
}
