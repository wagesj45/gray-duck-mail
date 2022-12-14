
namespace GrayDuckMail.Common.Localization
{
	/// <summary> Values that represent resource names as used in <see cref="Localization.Resources" />. </summary>
    /// <remarks> This is an automatically generated class. </remarks>
	public enum ResourceName
	{
		/// <summary> The default value. </summary>
		Undefined = 0,
		/// <summary> Gray Duck Mail </summary>
				ApplicationName,
		/// <summary> Could not create database file. </summary>
				Exception_DBNotCreated,
		/// <summary> Could not determine the formatting of the message. </summary>
				Exception_FormatNotDetermined,
		/// <summary> The file upload was not in the correct SQLite file format. </summary>
				Exception_MalformedDatabase,
		/// <summary> The file uploaded is missing or was malformed. </summary>
				Exception_MalformedUpload,
		/// <summary> No search term was provided. </summary>
				Exception_NoSearchTerm,
		/// <summary> The property selector was unable to resolve to a property name. </summary>
				Exception_PropertySelectorResolutionError,
		/// <summary> Creating email wrapper object. </summary>
				Logger_CreatingEmailWrapper,
		/// <summary> Message is a multipart message with at least one 'delivery-status' section. </summary>
				Logger_DeliveryStatusDetected,
		/// <summary> Disconnecting. </summary>
				Logger_Disconnecting,
		/// <summary> IMAP client disposing. </summary>
				Logger_DisposingIMAP,
		/// <summary> POP3 Client disposing. </summary>
				Logger_DisposingPOP3,
		/// <summary> Disposing of the client wrapper object. </summary>
				Logger_DisposingWrapper,
		/// <summary> The discussion list is empty. </summary>
				Logger_EmptyDiscussionList,
		/// <summary> A failed delivery was detected. </summary>
				Logger_FailedDeliveryDetected,
		/// <summary> The bounced email contains a failure report, but an unknown recipient status group. </summary>
				Logger_FailureDetectedUnknownRecipient,
		/// <summary> Assigning Contact {0} to Discussion List {1}. </summary>
				Logger_Format_AssigningContact,
		/// <summary> Assigning index {0} to {1}. </summary>
				Logger_Format_AssigningMimeMessageIndex,
		/// <summary> Authenticating with {0}:{1}. </summary>
				Logger_Format_AuthenticatingWith,
		/// <summary> Connecting to {0}:{1}. </summary>
				Logger_Format_ConnectingTo,
		/// <summary> Could not find contact with ID = {0}. </summary>
				Logger_Format_CouldNotFindContact,
		/// <summary> Could not find discussion list with ID = {0} </summary>
				Logger_Format_CouldNotFindDiscussionList,
		/// <summary> Creating db file at {0}. </summary>
				Logger_Format_CreatingDB,
		/// <summary> Database file created at {0}. </summary>
				Logger_Format_DBCreated,
		/// <summary> Could not create database file at {0}. </summary>
				Logger_Format_DBNotCreated,
		/// <summary> Deleting message {0}. </summary>
				Logger_Format_DeletingMessage,
		/// <summary> -- {0}: {1} </summary>
				Logger_Format_FailureStatusGroupsLine,
		/// <summary> Form input was malformed or missing for {0}. </summary>
				Logger_Format_FormInputMalformed,
		/// <summary> Invalid unsubscription request for non-existant contact with ID {0}. </summary>
				Logger_Format_InvalidUnsubscriptionContact,
		/// <summary> Invalid unsubscription request for non-existant discussion list with ID {0}. </summary>
				Logger_Format_InvalidUnsubscriptionDiscussionList,
		/// <summary> Invalid unsubscription status for contact with ID {0} and discussion list {1} due to subscription status {2}. </summary>
				Logger_Format_InvalidUnsubscriptionSubscriptionStatus,
		/// <summary> Loading assembly {0}. </summary>
				Logger_Format_LoadingAssembly,
		/// <summary> Performing fuzzy search: {0} </summary>
				Logger_Format_PerformingFuzzySearch,
		/// <summary> Sending onboarding email to {0} ({1}). </summary>
				Logger_Format_SendingOnboardingEmail,
		/// <summary> Sending a notication to the discussion list owner that {0} ({1}) has requested access to {2}. </summary>
				Logger_Format_SendingOwnerNotification,
		/// <summary> Sending the subscription confirmation email to {0} ({1}). </summary>
				Logger_Format_SendingSubscriptionConfirmation,
		/// <summary> Sending a test Owner Notification email to discussion list {0}. </summary>
				Logger_Format_SendingTest,
		/// <summary> Sending the subscription confirmation email to {0} ({1}). </summary>
				Logger_Format_SendingUnsubscriptionConfirmation,
		/// <summary> Serving page '{0}' </summary>
				Logger_Format_ServingPage,
		/// <summary> Email template processed: {0}. </summary>
				Logger_Format_TemplateProcessed,
		/// <summary> Removing Contact {0} to Discussion List {1}. </summary>
				Logger_Format_UnassigningContact,
		/// <summary> User {0} unsubscribing from {1}. </summary>
				Logger_Format_UserUnsubscribing,
		/// <summary> Found the following resource names in the assembly manifest: </summary>
				Logger_FoundResources,
		/// <summary> -- {0} </summary>
				Logger_FoundResourcesLine,
		/// <summary> Generating an email. </summary>
				Logger_GeneratingEmail,
		/// <summary> Getting messages. </summary>
				Logger_GettingMessages,
		/// <summary> Initializing database for controller. </summary>
				Logger_InitializingControllerDatabase,
		/// <summary> Invalid unsubscription request. No subscription status found. </summary>
				Logger_InvalidUnsubscriptionSubscription,
		/// <summary> Loading main HTML email template. </summary>
				Logger_LoadingHTMLTemplate,
		/// <summary> Mesasge body determined to contain HTML. </summary>
				Logger_MessageContainsHTML,
		/// <summary> Message body determined to contain plain text. </summary>
				Logger_MessageContainsPlainText,
		/// <summary> Relaying message to {0} ({1}) </summary>
				Logger_RelayingMessage,
		/// <summary> The request is being processed from the designated external port. Request Origin: {0} </summary>
				Logger_RequestOnExternalPort,
		/// <summary> The request is being processed from the designated internal port. </summary>
				Logger_RequestOnInternalPort,
		/// <summary> The request is being processed from an unknown port ({0})). The docker container is likely misconfigured. Remote Origin: {1} </summary>
				Logger_RequestOnUnknownPort,
		/// <summary> Saving assignments. </summary>
				Logger_SavingAssignments,
		/// <summary> The SMTP client is not connected. Connecting now. </summary>
				Logger_SMTPNotConnected,
		/// <summary> Email template read into memory. </summary>
				Logger_TemplateInMemory,
		/// <summary> An unknown client type was requested. </summary>
				Logger_UnknownClientType,
		/// <summary> Using IMAP client. </summary>
				Logger_UsingIMAP,
		/// <summary> Using POP3 client. </summary>
				Logger_UsingPOP3,
		/// <summary> This message is part of the '{0}' discussion list. You can unsubscribe by sending any message to <a href='mailto:{1}'>{1}</a> </summary>
				Mail_Format_HTMLUnsubscribeEmailMessage,
		/// <summary> This message is part of the '{0}' discussion list. You can unsubscribe by clicking here: <a href='{1}'>{1}</a> </summary>
				Mail_Format_HTMLUnsubscribeLinkMessage,
		/// <summary> The '{0}' email list administator has invited you to participate. To confirm your subscription, simply reply to this e-mail. If you do not wish to participate, you can ignore this email. </summary>
				Mail_Format_OnboardingBody,
		/// <summary> You've been invited to the '{0}' Email Discussion List </summary>
				Mail_Format_OnboardingSubheading,
		/// <summary> Subscribe to {0} </summary>
				Mail_Format_OnboardingSubject,
		/// <summary> {0} has requested access to the '{0}' Email Discussion List </summary>
				Mail_Format_OwnerNotificationSubheading,
		/// <summary> Request to join {0} </summary>
				Mail_Format_OwnerNotificationSubject,
		/// <summary> {0} - Message from {1} </summary>
				Mail_Format_Subject,
		/// <summary> - Message from {0} </summary>
		 /// <remarks> It is important that this message mirrors Mail_Format_Subject with all characters after {0}, including the first space. </remarks>
				Mail_Format_SubjectReplace,
		/// <summary> Glad to have you. To send a message to everyone on the discussion list, just send an email to <a href='mailto:{0}'>{0}</a>. When you recieve a message from someone in the group, you can simply reply to that email and everyone on the discussion list will get a copy. </summary>
				Mail_Format_SubscriptionConfirmationBody,
		/// <summary> You've been subscribed to the '{0}' Email Discussion List </summary>
				Mail_Format_SubscriptionConfirmationSubheading,
		/// <summary> Welcome to {0} </summary>
				Mail_Format_SubscriptionConfirmationSubject,
		/// <summary> This message is part of the '{0}' discussion list. You can unsubscribe by sending any message to {1}. </summary>
				Mail_Format_TextUnsubscribeEmailMessage,
		/// <summary> This message is part of the '{0}' discussion list. You can unsubscribe by clicking here: {1} </summary>
				Mail_Format_TextUnsubscribeLinkMessage,
		/// <summary> You have successfully unsubscribed from this discussion list. If you'd ever like to resubscribe, send a message to <a href='mailto:{0}'>{0}</a>. </summary>
				Mail_Format_UnsubscriptionConfirmationBody,
		/// <summary> You will no longer recieve messages from the '{0}' Email Discussion List </summary>
				Mail_Format_UnsubscriptionConfirmationSubheading,
		/// <summary> You have been unsubscribed from {0}. </summary>
				Mail_Format_UnsubscriptionConfirmationSubject,
		/// <summary> Welcome! </summary>
				Mail_OnboardingHeading,
		/// <summary> Owner </summary>
				Mail_Owner,
		/// <summary> Please visit the the web administration interface to process this request. </summary>
				Mail_OwnerNotificationBody,
		/// <summary> Discussion List Access Request </summary>
				Mail_OwnerNotificationHeading,
		/// <summary> Thanks for subscribing! </summary>
				Mail_SubscriptionConfirmationHeading,
		/// <summary> Sorry to see you go. </summary>
				Mail_UnsubscriptionConfirmationHeading,
	}
}