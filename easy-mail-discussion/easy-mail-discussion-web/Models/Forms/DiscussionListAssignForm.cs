using System.Collections.Generic;

namespace EasyMailDiscussion.Web.Models.Forms
{
    /// <summary> Model for the form input creating or modifying discussion list assignments. </summary>
    public class DiscussionListAssignForm
    {
        #region Properties

        public int? ID { get; set; }

        public int[] ContactID { get; set; }

        public string[] Assigned { get; set; }

        public IEnumerable<(int ContactID, bool IsAssigned)> Assignments
        {
            get
            {
                for(int i = 0; i < ContactID.Length; i++)
                {
                    yield return (this.ContactID[i], !string.IsNullOrWhiteSpace(this.Assigned[i]));
                }
            }
        }

        #endregion
    }
}
