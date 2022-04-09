using Microsoft.AspNetCore.Http;

namespace GrayDuckMail.Web.Models.Forms
{
    /// <summary> Model for the form input importing a SQLite database file. </summary>
    public class ImportDatabaseForm : BaseFormInput<ImportDatabaseForm>
    {
        #region Properties

        /// <summary> Gets or sets the database file. </summary>
        /// <value> The database file. </value>
        public IFormFile DatabaseFile { get; set; }

        #endregion
    }
}
