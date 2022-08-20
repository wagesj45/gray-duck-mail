using GrayDuckMail.Common.Database;

namespace GrayDuckMail.Web.Models
{
    /// <summary> A data model for the external unsubscription page. </summary>
    public class UnsubscribeModel : BasePageModel
    {
        #region Properties
        
        /// <summary> Gets or sets the email address for which the action was taken. </summary>
        /// <value> The user's email address. </value>
        public string UserEmail { get; set; }

        /// <summary> Gets or sets the discussion list being unsubscribed from. </summary>
        /// <value> A discussion list. </value>
        public DiscussionList DiscussionList { get; set; }

        /// <summary> Gets or sets a value indicating whether the action was successful. </summary>
        /// <value> True if successful, false if not. </value>
        public bool Successful { get; set; }

        #endregion
    }
}
