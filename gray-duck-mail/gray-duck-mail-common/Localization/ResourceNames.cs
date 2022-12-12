
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
		/// <summary> Creating email wrapper object. </summary>
				Logger_CreatingEmailWrapper,
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
		/// <summary> Authenticating with {0}:{1}. </summary>
				Logger_Format_AuthenticatingWith,
		/// <summary> Connecting to {0}:{1}. </summary>
				Logger_Format_ConnectingTo,
		/// <summary> Creating db file at {0}. </summary>
				Logger_Format_CreatingDB,
		/// <summary> Database file created at {0}. </summary>
				Logger_Format_DBCreated,
		/// <summary> Could not create database file at {0}. </summary>
				Logger_Format_DBNotCreated,
		/// <summary> Deleting message {0}. </summary>
				Logger_Format_DeletingMessage,
		/// <summary> Loading assembly {0}. </summary>
				Logger_Format_LoadingAssembly,
		/// <summary> Sending onboarding email to {0} ({1}). </summary>
				Logger_Format_SendingOnboardingEmail,
		/// <summary> Email template processed: {0}. </summary>
				Logger_Format_TemplateProcessed,
		/// <summary> Found the following resource names in the assembly manifest: </summary>
				Logger_FoundResources,
		/// <summary> -- {0} </summary>
				Logger_FoundResourcesLine,
		/// <summary> Getting messages. </summary>
				Logger_GettingMessages,
		/// <summary> Loading main HTML email template. </summary>
				Logger_LoadingHTMLTemplate,
		/// <summary> Mesasge body determined to contain HTML. </summary>
				Logger_MessageContainsHTML,
		/// <summary> Message body determined to contain plain text. </summary>
				Logger_MessageContainsPlainText,
		/// <summary> Relaying message to {0} ({1}) </summary>
				Logger_RelayingMessage,
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
		/// <summary>  </summary>
				Mail_Format_OnboardingBody,
		/// <summary>  </summary>
				Mail_Format_OnboardingSubheading,
		/// <summary> Subscribe to {0} </summary>
				Mail_Format_OnboardingSubject,
		/// <summary> {0} - Message from {1} </summary>
				Mail_Format_Subject,
		/// <summary> - Message from {0} </summary>
		 /// <remarks> It is important that this message mirrors Mail_Format_Subject with all characters after {0}, including the first space. </remarks>
				Mail_Format_SubjectReplace,
		/// <summary> This message is part of the '{0}' discussion list. You can unsubscribe by sending any message to {1}. </summary>
				Mail_Format_TextUnsubscribeEmailMessage,
		/// <summary> This message is part of the '{0}' discussion list. You can unsubscribe by clicking here: {1} </summary>
				Mail_Format_TextUnsubscribeLinkMessage,
		/// <summary>  </summary>
				Mail_OnboardingHeading,
	}
}