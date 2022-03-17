namespace EasyMailDiscussion.Web.Models.Forms
{
    /// <summary> Model for the form input creating or modifying discussion list.. </summary>
    public class ContactForm
    {
        #region Properties

        public int? ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Activated { get; set; }

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
