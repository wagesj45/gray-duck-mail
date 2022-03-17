using EasyMailDiscussion.Common.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common
{
    public static class EmailAliasHelper
    {
        #region Methods

        public static string GetSubscriberAlias(DiscussionList discussionList)
        {
            return GetSubscriberAlias(discussionList.BaseEmailAddress);
        }

        public static string GetSubscriberAlias(string baseEmailAddress)
        {
            return string.Format("subscribe+{0}", baseEmailAddress);
        }

        #endregion
    }
}
