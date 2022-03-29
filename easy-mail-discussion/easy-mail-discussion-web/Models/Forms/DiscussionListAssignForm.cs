using System.Collections.Generic;
using System.Linq;

namespace EasyMailDiscussion.Web.Models.Forms
{
    /// <summary>
    /// Model for the form input creating or modifying
    /// <see cref="Common.Database.ContactSubscription">discussion list
    /// assignments</see>.
    /// </summary>
    public class DiscussionListAssignForm
    {
        #region Properties

        /// <summary> Gets or sets the identifier of the discussion list. </summary>
        /// <value> The identifier of the discussion list. </value>
        /// <seealso cref="Common.Database.DiscussionList"/>
        /// <seealso cref="Common.Database.DiscussionList.ID"/>
        public int DiscussionListID { get; set; }

        /// <summary>
        /// Gets or sets an array of identifiers of the contacts being assigned or unassigned.
        /// </summary>
        /// <value> The identifiers of the contacts. </value>
        /// <seealso cref="Common.Database.Contact"/>
        /// <seealso cref="Common.Database.Contact.ID"/>
        public int[] ContactID { get; set; }

        /// <summary>
        /// Gets or sets the assignments connecting <see cref="ContactID">contacts</see> to the
        /// <see cref="DiscussionListID">discussion list</see>.
        /// </summary>
        /// <value> The assigned. </value>
        /// <seealso cref="Common.Database.Contact.ContactSubscriptions"/>
        /// <seealso cref="Common.EmailHelper.ContactAuthorizedStatuses"/>
        /// <seealso cref="Common.EmailHelper.ContactUnassignableStatuses"/>
        /// <seealso cref="Common.EmailHelper.IsAssignable(Common.Database.DiscussionList, Common.Database.Contact)"/>
        /// <seealso cref="Common.EmailHelper.IsAuthorizedForMailDistribution(Common.Database.DiscussionList, Common.Database.Contact) "/>
        public int[] Assigned { get; set; }

        /// <summary>
        /// Gets the assignments connecting <see cref="ContactID">contacts</see> to the
        /// <see cref="DiscussionListID">discussion list</see>.
        /// </summary>
        /// <remarks>
        /// This is a helper property that processes the string value sent from the HTTP form for
        /// <see cref="ContactID"/> and <see cref="Assigned"/>. This method assumes that the form data is
        /// properly formed and the arrays are synced.
        /// </remarks>
        /// <value> The assignments. </value>
        /// <seealso cref="ContactID"/>
        /// <seealso cref="Assigned"/>
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
