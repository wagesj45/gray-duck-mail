using EasyMailDiscussion.Common.Database;
using System.Collections.Generic;

namespace EasyMailDiscussion.Web.Models
{
    public class ContactsModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
