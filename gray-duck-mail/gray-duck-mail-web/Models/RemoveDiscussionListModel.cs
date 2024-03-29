﻿using GrayDuckMail.Common.Database;

namespace GrayDuckMail.Web.Models
{
    /// <summary> A data model for the discussion list removal page. </summary>
    public class RemoveDiscussionListModel : BasePageModel
    {
        #region Properties
        
        /// <summary> Gets or sets a discussion list. </summary>
        /// <value> The discussion list. </value>
        public DiscussionList DiscussionList { get; set; } 

        #endregion
    }
}
