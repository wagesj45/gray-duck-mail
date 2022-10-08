using GrayDuckMail.Common.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDuckMail.Common
{
    /// <summary> Defines an email to be sent. </summary>
    public class EmailDefinition
    {
        #region Properties

        /// <summary> Gets or sets the type of email. </summary>
        /// <value> The type. </value>
        public EmailDefinitionType Type { get; set; }

        public Contact Contact { get; set; }

        public DiscussionList DiscussionList { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public Message Message { get; set; }

        #endregion

        #region Methods

        /// <summary> Creates a subscription confirmation definition. </summary>
        /// <param name="discussionList"> The discussion list to which the subscription belongs. </param>
        /// <param name="contact">        The contact being mailed. </param>
        /// <returns> The new definition of a subscription confirmation. </returns>
        public static EmailDefinition CreateSubscriptionConfirmation(DiscussionList discussionList, Contact contact)
        {
            return new EmailDefinition()
            {
                DiscussionList = discussionList,
                Contact = contact,
                Type = EmailDefinitionType.SubscriptionConfirmation
            };
        }

        /// <summary> Creates an unsubscription confirmation definition. </summary>
        /// <param name="discussionList"> The discussion list to which the subscription belongs. </param>
        /// <param name="contact">        The contact being mailed. </param>
        /// <returns> The new definition of a unsubscription confirmation. </returns>
        public static EmailDefinition CreateUnsubscriptionConfirmation(DiscussionList discussionList, Contact contact)
        {
            return new EmailDefinition()
            {
                DiscussionList = discussionList,
                Contact = contact,
                Type = EmailDefinitionType.UbsubscriptionConfirmation
            };
        }

        /// <summary> Creates an onboarding message definition. </summary>
        /// <param name="discussionList"> The discussion list to which the contact belongs. </param>
        /// <param name="contact">        The contact being mailed. </param>
        /// <returns> The new definition of an onboarding message. </returns>
        public static EmailDefinition CreateOnboarding(DiscussionList discussionList, Contact contact)
        {
            return new EmailDefinition()
            {
                DiscussionList = discussionList,
                Contact = contact,
                Type = EmailDefinitionType.Onboarding
            };
        }

        /// <summary> Creates a notification to the owner of the <paramref name="discussionList"/>. </summary>
        /// <param name="discussionList"> The discussion list to which the contact belongs. </param>
        /// <param name="contact">        The contact being mailed. </param>
        /// <returns> The new definition of an onboarding message. </returns>
        public static EmailDefinition CreateOwnerNotification(DiscussionList discussionList, Contact contact)
        {
            return new EmailDefinition()
            {
                DiscussionList = discussionList,
                Contact = contact,
                Type = EmailDefinitionType.RequestOwnerNotification
            };
        }

        /// <summary> Creates a relayed message definition. </summary>
        /// <param name="discussionList"> The discussion list to which the message belongs. </param>
        /// <param name="contact">        The contact sending the message. </param>
        /// <param name="message">        The email message. </param>
        /// <returns> The new definition of a relayed message. </returns>
        public static EmailDefinition CreateRelay(DiscussionList discussionList, Contact contact, Message message)
        {
            return new EmailDefinition()
            {
                DiscussionList = discussionList,
                Contact = contact,
                Message = message,
                Type = EmailDefinitionType.Relay
            };
        }

        #endregion
    }
}
