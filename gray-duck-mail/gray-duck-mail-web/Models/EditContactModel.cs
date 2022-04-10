using GrayDuckMail.Common.Database;

namespace GrayDuckMail.Web.Models
{
    /// <summary> A data model for the edit contact page. </summary>
    public class EditContactModel : BasePageModel
    {
        #region Properties
        
        /// <summary> Gets or sets the contact. </summary>
        /// <value> The contact. </value>
        public Contact Contact { get; set; } 

        #endregion
    }
}
