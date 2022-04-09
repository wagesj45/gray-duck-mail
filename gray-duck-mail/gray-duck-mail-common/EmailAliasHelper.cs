using GrayDuckMail.Common.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDuckMail.Common
{
    /// <summary>
    /// A helper class generating alias names based on the
    /// <see cref="DiscussionList.BaseEmailAddress"/>.
    /// </summary>
    /// <remarks>
    /// The aliases described by this class are required for functional emails processed by the
    /// system.
    /// </remarks>
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

        /// <summary> Gets the bounce address alias. </summary>
        /// <param name="discussionList"> The discussion list database object. </param>
        /// <returns> The bounce address alias. </returns>
        public static string GetBounceAlias(DiscussionList discussionList)
        {
            return GetBounceAlias(discussionList.BaseEmailAddress);
        }

        /// <summary> Gets the bounce address alias. </summary>
        /// <param name="baseEmailAddress"> The base email address. </param>
        /// <returns> The bounce alias. </returns>
        public static string GetBounceAlias(string baseEmailAddress)
        {
            return string.Format("bounce-{0}", baseEmailAddress);
        }

        #endregion
    }
}
