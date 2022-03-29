using EasyMailDiscussion.Common.Database;

namespace EasyMailDiscussion.Web.Models
{
    /// <summary> A data model for the contact removal page. </summary>
    public class RemoveContactModel
    {
        #region Properties
        
        /// <summary> Gets or sets the contact. </summary>
        /// <value> The contact. </value>
        public Contact Contact { get; set; } 

        #endregion
    }
}
