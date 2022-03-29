﻿using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models
{
    /// <summary> A data model for the contacts page. </summary>
    public class ContactsModel
    {
        #region Properties
        
        /// <summary> Gets or sets the contacts to display on the page. </summary>
        /// <value> The contacts. </value>
        public IEnumerable<Contact> Contacts { get; set; } = Enumerable.Empty<Contact>(); 

        #endregion
    }
}
