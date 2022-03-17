using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models.Forms
{
    /// <summary> Model for the form input creating or modifying discussion list assignments. </summary>
    public class DiscussionListAssignForm
    {
        #region Members

        public const string UNCHECKED_VALUE = "N";
        public const string CHECKED_VALUE = "Y";

        #endregion

        #region Properties

        public int DiscussionListID { get; set; }

        public int[] ContactID { get; set; }

        public int[] Assigned { get; set; }

        public IEnumerable<(int ContactID, bool IsAssigned)> Assignments
        {
            get
            {
                for(int i = 0; i < ContactID.Length; i++)
                {
                    yield return (this.ContactID[i], this.Assigned.Contains(this.ContactID[i]));
                }
            }
        }

        #endregion
    }
}
