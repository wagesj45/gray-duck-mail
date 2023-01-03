
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
		/// <summary> Adding email definition to queue. </summary>
				Logger_AddingEmailDefinition,
		/// <summary> using SSL </summary>
				Logger_AppendUsingSSL,
		/// <summary> Application stopped. </summary>
				Logger_ApplicationStopped,
		/// <summary> Beginning email fetch loop. </summary>
				Logger_BeginningFetchLoop,
		/// <summary> Beginning onboarding loop. </summary>
				Logger_BeginningOnboarderLoop,
		/// <summary> Beginning email sender loop. </summary>
				Logger_BeginningSenderLoop,
		/// <summary> Committing changes to database. </summary>
				Logger_CommittingChangesToDatabase,
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
		/// <summary> Unable to fetch email definition from queue. </summary>
				Logger_EmailDefinitionFetchFailure,
		/// <summary> Found an email definition in the shared memory queue. </summary>
				Logger_EmailDefinitionFound,
		/// <summary> Email fetcher shutting down. </summary>
				Logger_EmailFetcherShutdown,
		/// <summary> Email sender shutting down. </summary>
				Logger_EmailSenderShutDown,
		/// <summary> The discussion list is empty. </summary>
				Logger_EmptyDiscussionList,
		/// <summary> A failed delivery was detected. </summary>
				Logger_FailedDeliveryDetected,
		/// <summary> The bounced email contains a failure report, but an unknown recipient status group. </summary>
				Logger_FailureDetectedUnknownRecipient,
		/// <summary> Fetching email defintion from queue. </summary>
				Logger_FetchingEmailDefinition,
		/// <summary> Filtering bounced messages. </summary>
				Logger_FilteringBouncedMessages,
		/// <summary> The email address for {0} appears to no longer be active. </summary>
				Logger_Format_AddressNotActive,
		/// <summary> Assigning Contact {0} to Discussion List {1}. </summary>
				Logger_Format_AssigningContact,
		/// <summary> Assigning index {0} to {1}. </summary>
				Logger_Format_AssigningMimeMessageIndex,
		/// <summary> Authenticating as {0}. </summary>
				Logger_Format_AuthenticatingAs,
		/// <summary> Authenticating with {0}:{1}. </summary>
				Logger_Format_AuthenticatingWith,
		/// <summary> Connecting to {0}:{1}. </summary>
				Logger_Format_ConnectingTo,
		/// <summary> Connecting to {0}:{1}{2} </summary>
				Logger_Format_ConnectingToSSL,
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
		/// <summary> Establishing database context using {0}. </summary>
				Logger_Format_EstablishingDatabaseContext,
		/// <summary> -- {0}: {1} </summary>
				Logger_Format_FailureStatusGroupsLine,
		/// <summary> Fetch loop complete. Waiting {0}. </summary>
				Logger_Format_FetchLoopComplete,
		/// <summary> Filtering {0} messages. </summary>
				Logger_Format_FilteringCount,
		/// <summary> Filtering message {0}. </summary>
				Logger_Format_FilteringMessage,
		/// <summary> Filtering messages for {0}. </summary>
				Logger_Format_FilteringMessages,
		/// <summary> Message {0} matches the filter criteria. </summary>
				Logger_Format_FilterMatch,
		/// <summary> Form input was malformed or missing for {0}. </summary>
				Logger_Format_FormInputMalformed,
		/// <summary> Importing exisiting database {0}. </summary>
				Logger_Format_ImportingExistingDatabase,
		/// <summary> Invalid unsubscription request for non-existant contact with ID {0}. </summary>
				Logger_Format_InvalidUnsubscriptionContact,
		/// <summary> Invalid unsubscription request for non-existant discussion list with ID {0}. </summary>
				Logger_Format_InvalidUnsubscriptionDiscussionList,
		/// <summary> Invalid unsubscription status for contact with ID {0} and discussion list {1} due to subscription status {2}. </summary>
				Logger_Format_InvalidUnsubscriptionSubscriptionStatus,
		/// <summary> Loading assembly {0}. </summary>
				Logger_Format_LoadingAssembly,
		/// <summary> Message {0} (Index {1}) processed. Marked for deletion from the server. </summary>
				Logger_Format_MessageProcessed,
		/// <summary> Onboarding loop complete. Waiting {0}. </summary>
				Logger_Format_OnboarderLoopComplete,
		/// <summary> Performing fuzzy search: {0} </summary>
				Logger_Format_PerformingFuzzySearch,
		/// <summary> Processing list {0}. </summary>
				Logger_Format_ProcessingList,
		/// <summary> Processing {0} messages. </summary>
				Logger_Format_ProcessingMessages,
		/// <summary> Processing subscription message from {0}. </summary>
				Logger_Format_ProcessingSubscriptionMessage,
		/// <summary> Email sender loop complete. Waiting {0}. </summary>
				Logger_Format_SenderLoopComplete,
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
		/// <summary> Setting {0} (ID {1}) as active. They have confirmed they control the email address by responding to the subscription confirmation email. </summary>
				Logger_Format_SettingActive,
		/// <summary> Email template processed: {0}. </summary>
				Logger_Format_TemplateProcessed,
		/// <summary> Removing Contact {0} to Discussion List {1}. </summary>
				Logger_Format_UnassigningContact,
		/// <summary> An unknown user has requested access to {0}. An alert will be sent to the owner address alias. </summary>
				Logger_Format_UnknownUserRequestedAccess,
		/// <summary> The sender is unrecognized or unauthorized to participate in {0}. We'll log it and let the message be deleted. </summary>
				Logger_Format_UnrecognizedOrUnauthorized,
		/// <summary> -- {0} </summary>
				Logger_Format_UnrecognizedOrUnauthorizedDomainLine,
		/// <summary> Encoding: {0} </summary>
				Logger_Format_UnrecognizedOrUnauthorizedEncoding,
		/// <summary> From: {0} ({1}) </summary>
				Logger_Format_UnrecognizedOrUnauthorizedFrom,
		/// <summary> A bounced email was recieved for an address that is not subscribed to {0}. Ignoring this message. </summary>
				Logger_Format_UnsubscribedBounce,
		/// <summary> {0}, who is already subscribed to {1}, has requested access again. Ignoring this message. </summary>
				Logger_Format_UserAlreadySubscribed,
		/// <summary> {0} has requested access to {1}, but has previously been denied. Ignoring this request. </summary>
				Logger_Format_UserPreviouslyDenied,
		/// <summary> {0} has requested access to {1}. Because they have previously be associated with the discussion list, they will be subscribed. </summary>
				Logger_Format_UserPreviouslySubscribed,
		/// <summary> User {0} subscribing to {1}. </summary>
				Logger_Format_UserSubscribing,
		/// <summary> User {0} unsubscribing from {1}. </summary>
				Logger_Format_UserUnsubscribing,
		/// <summary> Using custom view layout: {0} </summary>
				Logger_Format_UsingCustomView,
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
		/// <summary> Initializing shared memory object via static constructor. </summary>
				Logger_InitializingSharedMemory,
		/// <summary> Invalid unsubscription request. No subscription status found. </summary>
				Logger_InvalidUnsubscriptionSubscription,
		/// <summary> Loading main HTML email template. </summary>
				Logger_LoadingHTMLTemplate,
		/// <summary> Recieved a malformed EmailDefinition. </summary>
				Logger_MalformedEmailDefinition,
		/// <summary> Mesasge body determined to contain HTML. </summary>
				Logger_MessageContainsHTML,
		/// <summary> Message body determined to contain plain text. </summary>
				Logger_MessageContainsPlainText,
		/// <summary> No messages found. </summary>
				Logger_NoMessagesFound,
		/// <summary> No freshly created assignments waiting for onboarding. </summary>
				Logger_NoOnboardingAssignments,
		/// <summary> Onboarder shutting down. </summary>
				Logger_OnboarderShutDown,
		/// <summary> Registering service workers. </summary>
				Logger_RegisteringServiceWorkers,
		/// <summary> Relaying message to {0} ({1}) </summary>
				Logger_RelayingMessage,
		/// <summary> The request is being processed from the designated external port. Request Origin: {0} </summary>
				Logger_RequestOnExternalPort,
		/// <summary> The request is being processed from the designated internal port. </summary>
				Logger_RequestOnInternalPort,
		/// <summary> The request is being processed from an unknown port ({0})). The docker container is likely misconfigured. Remote Origin: {1} </summary>
				Logger_RequestOnUnknownPort,
		/// <summary> Running application. </summary>
				Logger_RunningApplication,
		/// <summary> Saving assignments. </summary>
				Logger_SavingAssignments,
		/// <summary> The SMTP client is not connected. Connecting now. </summary>
				Logger_SMTPNotConnected,
		/// <summary> Starting the main application. </summary>
				Logger_StartingApplication,
		/// <summary> Stopping the application. </summary>
				Logger_StoppingApplication,
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
		/// <summary> Allow the system to use fuzzy search. This allows for matching similar or mispelled search terms. </summary>
				View_Administration_AllowFuzzySearch,
		/// <summary> Choose a SQLite database file to import </summary>
				View_Administration_ChooseDatabase,
		/// <summary> Docker environment variable runtime values. </summary>
				View_Administration_DockerEnvironmentVariables,
		/// <summary> Export </summary>
				View_Administration_Export,
		/// <summary> Export Database </summary>
				View_Administration_ExportDatabase,
		/// <summary> Save a copy of your database, including contacts, discussion lists, and messages. </summary>
				View_Administration_ExportDatabaseDescription,
		/// <summary> Fuzzy search can give you better search results, but can be very slow. </summary>
				View_Administration_FuzzySearchExplaination,
		/// <summary> Administration </summary>
				View_Administration_Heading,
		/// <summary> Import </summary>
				View_Administration_Import,
		/// <summary> Import Database </summary>
				View_Administration_ImportDatabase,
		/// <summary> Import a database file to transfer contacts, discussion lists, and messages. </summary>
				View_Administration_ImportDatabaseDescription,
		/// <summary> WARNING: This will overwrite your existing database file. Please make sure you have a backup of your database before proceeding. </summary>
				View_Administration_ImportWarning,
		/// <summary> Number of items per page </summary>
				View_Administration_ItemsPerPage,
		/// <summary> Save Settings </summary>
				View_Administration_SaveSettings,
		/// <summary> Site Theme </summary>
				View_Administration_SiteTheme,
		/// <summary> Perform specialized tasks to manage and maintain your service here. </summary>
				View_Administration_Subheading,
		/// <summary> System </summary>
				View_Administration_System,
		/// <summary> Your system is currently configured to send </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Administration_SystemConfigurationPart1,
		/// <summary> emails at once, with a maximum of </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Administration_SystemConfigurationPart2,
		/// <summary> emails sent per hour. </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Administration_SystemConfigurationPart3,
		/// <summary> Administration </summary>
				View_Administration_Title,
		/// <summary> Value </summary>
				View_Administration_Value,
		/// <summary> Web Settings </summary>
				View_Administration_WebSettings,
		/// <summary> Activated </summary>
				View_Common_Activated,
		/// <summary> Archive </summary>
				View_Common_Archive,
		/// <summary> Cancel </summary>
				View_Common_Cancel,
		/// <summary> Create </summary>
				View_Common_Create,
		/// <summary> Description </summary>
				View_Common_Description,
		/// <summary> A short description of the discussion list. </summary>
				View_Common_DescriptionExplaination,
		/// <summary> Edit </summary>
				View_Common_Edit,
		/// <summary> Email </summary>
				View_Common_Email,
		/// <summary> Automatic email aliases will be used, such as </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Common_Format_ListEmailAddressExplainationPart1,
		/// <summary> bounce-list@example.com </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Common_Format_ListEmailAddressExplainationPart2,
		/// <summary> and </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Common_Format_ListEmailAddressExplainationPart3,
		/// <summary> unsubscribe-list@example.com </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Common_Format_ListEmailAddressExplainationPart4,
		/// <summary> . </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Common_Format_ListEmailAddressExplainationPart5,
		/// <summary> Page {0} of {1} </summary>
				View_Common_Format_PageCount,
		/// <summary> List Email Address </summary>
				View_Common_ListEmailAddress,
		/// <summary> Name </summary>
				View_Common_Name,
		/// <summary> Number of Discussion Lists </summary>
				View_Common_NumberOfDiscussionLists,
		/// <summary> Password </summary>
				View_Common_Password,
		/// <summary> Passwords are not encrypted when stored. Always secure your server, and never expose Gray Duck Mail's administration interface to the public internet! </summary>
				View_Common_PasswordWarning,
		/// <summary> Remove </summary>
				View_Common_Remove,
		/// <summary> Save Changes </summary>
				View_Common_SaveChanges,
		/// <summary> Search </summary>
				View_Common_Search,
		/// <summary> User Name </summary>
				View_Common_UserName,
		/// <summary> The user is activated and the email address is considered valid and working. </summary>
				View_Contacts_Edit_ActivatedDescription,
		/// <summary> Contact Details </summary>
				View_Contacts_Edit_ContactDetails,
		/// <summary> Create Contact </summary>
				View_Contacts_Edit_CreateContact,
		/// <summary> Edit Contact </summary>
				View_Contacts_Edit_Heading,
		/// <summary> New Contact </summary>
				View_Contacts_Edit_HeadingNew,
		/// <summary> Create a new contact below. </summary>
				View_Contacts_Edit_SubheadingNew,
		/// <summary> Edit the details for </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Contacts_Edit_SubheadingPart1,
		/// <summary> below. </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Contacts_Edit_SubheadingPart2,
		/// <summary> Contact Editor </summary>
				View_Contacts_Edit_Title,
		/// <summary> Create New Contact </summary>
				View_Contacts_Index_CreateNewContact,
		/// <summary> Contacts </summary>
				View_Contacts_Index_Heading,
		/// <summary> No contacts have been set up yet. You can </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Contacts_Index_NoContactsPart1,
		/// <summary> create a new contact </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Contacts_Index_NoContactsPart2,
		/// <summary> now. </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Contacts_Index_NoContactsPart3,
		/// <summary> View the contacts in your system below. </summary>
				View_Contacts_Index_Subheading,
		/// <summary> Contacts </summary>
				View_Contacts_Index_Title,
		/// <summary> Removing </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Contacts_Remove_HeadingPart1,
		/// <summary> Are you sure you want to remove this contact? </summary>
				View_Contacts_Remove_Subheading,
		/// <summary> Remove Contact? </summary>
				View_Contacts_Remove_Title,
		/// <summary> Create New Contact </summary>
				View_Contacts_Search_CreateNewContact,
		/// <summary> Search Results </summary>
				View_Contacts_Search_Heading,
		/// <summary> No contacts could be found. Try a more enabling </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Contacts_Search_NoContactsFoundPart1,
		/// <summary> Use Fuzzy Search </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Contacts_Search_NoContactsFoundPart2,
		/// <summary> in the Administration settings. </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Contacts_Search_NoContactsFoundPart3,
		/// <summary> Find's simliar and mispelled search terms. </summary>
				View_Contacts_Search_NoContactsFoundTooltip,
		/// <summary> Search for </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Contacts_Search_SubheadingPart1,
		/// <summary> Contact Search </summary>
				View_Contacts_Search_Title,
		/// <summary> {0} has been unsubscribed from {1}. </summary>
				View_External_Unsubscribe_Format_Successful,
		/// <summary> Unsubscribe </summary>
				View_External_Unsubscribe_Heading,
		/// <summary> Unsubscribe </summary>
				View_External_Unsubscribe_Title,
		/// <summary> There was an error while trying to unsubscribe. Either the contact or discussion list could not be found, or the contact is already unsubscribed. </summary>
				View_External_Unsubscribe_Unsuccessful,
		/// <summary> At a glance... </summary>
				View_Home_Index_AtAGlance,
		/// <summary> discussion </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Home_Index_DicussionListsInfoPart1,
		/// <summary> . </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Home_Index_DicussionListsInfoPart2,
		/// <summary> Welcome </summary>
				View_Home_Index_Heading,
		/// <summary> list </summary>
				View_Home_Index_List,
		/// <summary> lists </summary>
				View_Home_Index_Lists,
		/// <summary> message </summary>
				View_Home_Index_Message,
		/// <summary> messages </summary>
				View_Home_Index_Messages,
		/// <summary> You have a total of </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Home_Index_NumberOfMessagesPart1,
		/// <summary> . </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Home_Index_NumberOfMessagesPart2,
		/// <summary> Hello! Welcome to your email discussion lists. </summary>
				View_Home_Index_Subheading,
		/// <summary> Home Page </summary>
				View_Home_Index_Title,
		/// <summary> You have </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Home_Index_YouHave,
		/// <summary> {0} Archive Search </summary>
				View_List_ArchiveSearch_FormatTitle,
		/// <summary> {0} Archive </summary>
				View_List_ArchiveSearch_Format_Heading,
		/// <summary> Search for </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_List_ArchiveSearch_SubheadingPart1,
		/// <summary> Here you can view the archived messages sent on the '{0}' discussion list. </summary>
				View_List_Archive_Format_Subheading,
		/// <summary> {0} Archive </summary>
				View_List_Archive_Format_Title,
		/// <summary> Archive </summary>
				View_List_Archive_Heading,
		/// <summary> Awaiting Confirmation </summary>
				View_List_Assign_AwaitingConfirmation,
		/// <summary> User will be invited soon. </summary>
				View_List_Assign_Created,
		/// <summary> You have denied this entry to the discussion list. </summary>
				View_List_Assign_Denied,
		/// <summary> {0} has bounced. </summary>
				View_List_Assign_Format_EmailBounced,
		/// <summary> Discussion List Assignment </summary>
				View_List_Assign_Heading,
		/// <summary> There are some invitations still processing. Your server is configured to process new subscribers every {0} minutes. Please be patient. </summary>
				View_List_Assign_InvitationsProcessing,
		/// <summary> This user has asked to participate in the discussion list. </summary>
				View_List_Assign_Requested,
		/// <summary> Assign contacts to </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_List_Assign_SubheadingPart1,
		/// <summary> below. </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_List_Assign_SubheadingPart2,
		/// <summary> This user is subscribed to this discussion list. </summary>
				View_List_Assign_Subscribed,
		/// <summary> Discussion List Assignments </summary>
				View_List_Assign_Title,
		/// <summary> This user has unsubscribed from this discussion list. </summary>
				View_List_Assign_Unsubscribed,
		/// <summary> No messages have been sent yet. You can </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_List_Common_NoMessagesPart1,
		/// <summary> contribute to the discussion </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_List_Common_NoMessagesPart2,
		/// <summary> now. </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_List_Common_NoMessagesPart3,
		/// <summary> Sent: </summary>
				View_List_Common_Sent,
		/// <summary> Subject: </summary>
				View_List_Common_Subject,
		/// <summary> Create Discussion List </summary>
				View_List_Edit_CreateDiscussionList,
		/// <summary> Discussion List Details </summary>
				View_List_Edit_DiscussionListDetails,
		/// <summary> Edit Discussion List </summary>
				View_List_Edit_Heading,
		/// <summary> New Discussion List </summary>
				View_List_Edit_HeadingNew,
		/// <summary> Incoming Mail Server Port </summary>
				View_List_Edit_IncomingMailPort,
		/// <summary> Incoming Mail Server </summary>
				View_List_Edit_IncomingMailServer,
		/// <summary> Outgoing Mail Server Port </summary>
				View_List_Edit_OutgoingMailPort,
		/// <summary> Outgoing Mail Server </summary>
				View_List_Edit_OutgoingMailServer,
		/// <summary> Remote Email Configuration </summary>
				View_List_Edit_RemoteEmailConfiguration,
		/// <summary> Create a new discussion list below. </summary>
				View_List_Edit_SubheadingNew,
		/// <summary> Edit the details for </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_List_Edit_SubheadingPart1,
		/// <summary> below. </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_List_Edit_SubheadingPart2,
		/// <summary> Discussion List Editor </summary>
				View_List_Edit_Title,
		/// <summary> Use SSL or TLS for a secure connection to the mail server. </summary>
				View_List_Edit_UseSSL,
		/// <summary> Assign Contacts </summary>
				View_List_Index_AssignContacts,
		/// <summary> Create New Discussion List </summary>
				View_List_Index_CreateNewDiscussionList,
		/// <summary> Discussion Lists </summary>
				View_List_Index_Heading,
		/// <summary> Incoming Mail Server: </summary>
				View_List_Index_IncomingMailServer,
		/// <summary> No discussion lists have been set up yet. You can </summary>
				View_List_Index_NoDiscussionListPart1,
		/// <summary> create a new discussion list </summary>
				View_List_Index_NoDiscussionListPart2,
		/// <summary> now. </summary>
				View_List_Index_NoDiscussionListPart3,
		/// <summary> Not using SSL/TLS </summary>
				View_List_Index_NotUsingSSL,
		/// <summary> Outgoing Mail Server: </summary>
				View_List_Index_OutgoingMailServer,
		/// <summary> View your discussion lists below. </summary>
				View_List_Index_Subheading,
		/// <summary> Send a Test Message </summary>
				View_List_Index_TestMessage,
		/// <summary> Discussion Lists </summary>
				View_List_Index_Title,
		/// <summary> User Name: </summary>
				View_List_Index_UserName,
		/// <summary> Using SSL/TLS </summary>
				View_List_Index_UsingSSL,
		/// <summary> An error occurred while processing this message. </summary>
				View_List_Message_ErrorProcessingMessage,
		/// <summary> Message from {0} </summary>
				View_List_Message_Format_Heading,
		/// <summary> From {0} at {1}: {2} </summary>
				View_List_Message_Format_ReplyLink,
		/// <summary> Message from {0} </summary>
				View_List_Message_Format_Title,
		/// <summary> From: </summary>
				View_List_Message_From,
		/// <summary> Message ID: </summary>
				View_List_Message_MessageID,
		/// <summary> That message cannot be found. </summary>
				View_List_Message_NotFound,
		/// <summary> Replies </summary>
				View_List_Message_Replies,
		/// <summary> Reply </summary>
				View_List_Message_Reply,
		/// <summary> Sent: </summary>
				View_List_Message_Sent,
		/// <summary> View the detailed information for this message below. </summary>
				View_List_Message_Subheading,
		/// <summary> Removing {0} </summary>
				View_List_Remove_Format_Heading,
		/// <summary> Are you sure you want to remove this discussion list? </summary>
				View_List_Remove_Subheading,
		/// <summary> Remove Discussion List </summary>
				View_List_Remove_Title,
		/// <summary> The Remote Origin logged is {0}. </summary>
				View_Shared_ErrorLayout_Format_RemoteOrigin,
		/// <summary> Error </summary>
				View_Shared_ErrorLayout_Heading,
		/// <summary> An error occurred while processing your request. </summary>
				View_Shared_ErrorLayout_Subheading,
		/// <summary> Error </summary>
				View_Shared_ErrorLayout_Title,
		/// <summary> Administration </summary>
				View_Shared_Layout_Administration,
		/// <summary> Contacts </summary>
				View_Shared_Layout_Contacts,
		/// <summary> Discussion Lists </summary>
				View_Shared_Layout_DiscussionLists,
		/// <summary> Find this project to be useful? Please consider </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Shared_Layout_FooterUsefulPart1,
		/// <summary> donating </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Shared_Layout_FooterUsefulPart2,
		/// <summary> ! </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Shared_Layout_FooterUsefulPart3,
		/// <summary> Source code </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Shared_Layout_SourceCodePart1,
		/// <summary> licensed under </summary>
		 /// <remarks> This formatted string is manually split to avoid issues with the HTML view engine. </remarks>
				View_Shared_Layout_SourceCodePart2,
		/// <summary> Version </summary>
				View_Shared_Layout_Version,
	}
}