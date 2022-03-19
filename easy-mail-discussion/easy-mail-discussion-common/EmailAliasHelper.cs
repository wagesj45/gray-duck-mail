using EasyMailDiscussion.Common.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common
{
    public static class EmailAliasHelper
    {
        #region Methods

        /// <summary> Gets the subscription confirmation address alias. </summary>
        /// <param name="discussionList"> The discussion list database object. </param>
        /// <returns> The subscription confirmation address alias. </returns>
        public static string GetSubscribeAlias(DiscussionList discussionList)
        {
            return GetSubscribeAlias(discussionList.BaseEmailAddress);
        }

        /// <summary> Gets the subscription confirmation address alias. </summary>
        /// <param name="baseEmailAddress"> The base email address. </param>
        /// <returns> The subscription confirmation address alias. </returns>
        public static string GetSubscribeAlias(string baseEmailAddress)
        {
            return string.Format("subscribe-{0}", baseEmailAddress);
        }

        /// <summary> Gets the unsubscribe confirmation address alias. </summary>
        /// <param name="discussionList"> The discussion list database object. </param>
        /// <returns> The unsubscribe confirmation address alias. </returns>
        public static string GetUnsubscribeAlias(DiscussionList discussionList)
        {
            return GetUnsubscribeAlias(discussionList.BaseEmailAddress);
        }

        /// <summary> Gets the unsubscribe confirmation address alias. </summary>
        /// <param name="baseEmailAddress"> The base email address. </param>
        /// <returns> The unsubscribe confirmation address alias. </returns>
        public static string GetUnsubscribeAlias(string baseEmailAddress)
        {
            return string.Format("unsubscribe-{0}", baseEmailAddress);
        }

        /// <summary> Gets the request address alias. </summary>
        /// <param name="discussionList"> The discussion list database object. </param>
        /// <returns> The request address alias. </returns>
        public static string GetRequestAlias(DiscussionList discussionList)
        {
            return GetRequestAlias(discussionList.BaseEmailAddress);
        }

        /// <summary> Gets the request address alias. </summary>
        /// <param name="baseEmailAddress"> The base email address. </param>
        /// <returns> The request address alias. </returns>
        public static string GetRequestAlias(string baseEmailAddress)
        {
            return string.Format("request-{0}", baseEmailAddress);
        }

        /// <summary> Gets the owner address alias. </summary>
        /// <param name="discussionList"> The discussion list database object. </param>
        /// <returns> The owner address alias. </returns>
        public static string GetOwnerAlias(DiscussionList discussionList)
        {
            return GetOwnerAlias(discussionList.BaseEmailAddress);
        }

        /// <summary> Gets the owner address alias. </summary>
        /// <param name="baseEmailAddress"> The base email address. </param>
        /// <returns> The owner address alias. </returns>
        public static string GetOwnerAlias(string baseEmailAddress)
        {
            return string.Format("owner-{0}", baseEmailAddress);
        }

        #endregion
    }
}
