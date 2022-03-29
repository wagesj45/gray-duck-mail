namespace EasyMailDiscussion.Web.Models.Forms
{
    /// <summary>
    /// Model for the form input creating or modifying a
    /// <see cref="Common.Database.Contact"/>.
    /// </summary>
    public class ContactForm
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        /// <seealso cref="Common.Database.Contact.ID"/>
        public int ID { get; set; }

        /// <summary> Gets or sets the name of the contact. </summary>
        /// <value> The name. </value>
        /// <seealso cref="Common.Database.Contact.Name"/>
        public string Name { get; set; }

        /// <summary> Gets or sets the email address of the contact. </summary>
        /// <value> The email. </value>
        /// <seealso cref="Common.Database.Contact.Email"/>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the contact's email address has been confirmed.
        /// </summary>
        /// <value> The activated. </value>
        /// <seealso cref="Common.Database.Contact.Activated"/>
        public string Activated { get; set; }

        /// <summary>
        /// Gets a value indicating if the contact's email address has been confirmed.
        /// </summary>
        /// <remarks>
        /// This is a helper property that processes the string value sent from the HTTP form for
        /// <see cref="Activated"/>.
        /// </remarks>
        /// <value> True if <see cref="Activated"/> is checked, false if not. </value>
        /// <seealso cref="Common.Database.Contact.Activated"/>
        public bool ActivatedChecked
        {
            get
            {
                return (!string.IsNullOrWhiteSpace(this.Activated));
            }
        }

        #endregion
    }
}
