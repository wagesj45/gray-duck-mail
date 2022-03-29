namespace EasyMailDiscussion.Web.Models.Forms
{
    /// <summary>
    /// Model for the form input creating or modifying
    /// <see cref="Common.Database.DiscussionList"/>.
    /// </summary>
    public class DiscussionListForm
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        /// <seealso cref="Common.Database.DiscussionList.ID"/>
        public int ID { get; set; }

        /// <summary> Gets or sets the name of the discussion list. </summary>
        /// <value> The name. </value>
        /// <seealso cref="Common.Database.DiscussionList.Name"/>
        public string Name { get; set; }

        /// <summary> Gets or sets the description of the discussion list. </summary>
        /// <value> The description. </value>
        /// <seealso cref="Common.Database.DiscussionList.Description"/>
        public string Description { get; set; }

        /// <summary> Gets or sets the base email address of the discussion list. </summary>
        /// <value> The base email address. </value>
        /// <seealso cref="Common.Database.DiscussionList.BaseEmailAddress"/>
        public string BaseEmailAddress { get; set; }

        /// <summary> Gets or sets the username used to connect to the remote mail server. </summary>
        /// <value> The name of the user. </value>
        /// <seealso cref="Common.Database.DiscussionList.UserName"/>
        public string UserName { get; set; }

        /// <summary> Gets or sets the password used to connect to the remote mail server. </summary>
        /// <value> The password. </value>
        /// <seealso cref="Common.Database.DiscussionList.Password"/>
        public string Password { get; set; }

        /// <summary> Gets or sets the incoming mail server address. </summary>
        /// <value> The incoming mail server. </value>
        /// <seealso cref="Common.Database.DiscussionList.IncomingMailServer"/>
        public string IncomingMailServer { get; set; }

        /// <summary> Gets or sets the incoming mail server port. </summary>
        /// <value> The incoming mail port. </value>
        /// <seealso cref="Common.Database.DiscussionList.IncomingMailPort"/>
        public int IncomingMailPort { get; set; }

        /// <summary> Gets or sets the outgoing mail server address. </summary>
        /// <value> The outgoing mail server. </value>
        /// <seealso cref="Common.Database.DiscussionList.OutgoingMailServer"/>
        public string OutgoingMailServer { get; set; }

        /// <summary> Gets or sets the outgoing mail server port. </summary>
        /// <value> The outgoing mail port. </value>
        /// <seealso cref="Common.Database.DiscussionList.OutgoingMailPort"/>
        public int OutgoingMailPort { get; set; }

        /// <summary>
        /// Gets or sets a value describing if the connection to the <see cref="IncomingMailServer"/> and
        /// <see cref="OutgoingMailServer"/> use an encrypted connection.
        /// </summary>
        /// <value> The SSL value. </value>
        /// <seealso cref="Common.Database.DiscussionList.UseSSL"/>
        public string UseSSL { get; set; }

        /// <summary>
        /// Gets a value describing if the connection to the <see cref="IncomingMailServer"/> and
        /// <see cref="OutgoingMailServer"/> use an encrypted connection.
        /// </summary>
        /// <value> True if <see cref="UseSSL"/> is checked, false if not. </value>
        /// <seealso cref="Common.Database.DiscussionList.UseSSL"/>
        public bool UseSSLChecked
        {
            get
            {
                return (!string.IsNullOrWhiteSpace(this.UseSSL));
            }
        }

        #endregion
    }
}
