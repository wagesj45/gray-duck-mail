namespace GrayDuckMail.Web.Models.Forms
{
    /// <summary>
    /// Model for the form input creating or modifying a
    /// <see cref="Common.Database.Contact"/>.
    /// </summary>
    public class ContactForm : BaseFormInput<ContactForm>
    {
        #region Properties

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        /// <seealso cref="Common.Database.Contact.ID"/>
        public int? ID { get; set; }

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

        #endregion
    }
}
