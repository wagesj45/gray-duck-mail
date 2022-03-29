EmailHelper.SendOnboardingEmail Method
======================================
Sends an onboarding email asking a [contact][1] to subscribe to a [discussion list][2].

  **Namespace:**  [EasyMailDiscussion.Common][3]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static void SendOnboardingEmail(
	DiscussionList discussionList,
	Contact recipient,
	SmtpClient client,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *discussionList*
Type: [EasyMailDiscussion.Common.Database.DiscussionList][2]  
 The discussion list.

##### *recipient*
Type: [EasyMailDiscussion.Common.Database.Contact][1]  
 The recipient.

##### *client*
Type: SmtpClient  
 The SMTP client.

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][4]  
 (Optional) A token that allows processing to be cancelled.


See Also
--------

#### Reference
[EmailHelper Class][5]  
[EasyMailDiscussion.Common Namespace][3]  
[EmailHelper.SendEmail(DiscussionList, Contact, String, String, Func&lt;MimeEntity>, SmtpClient, CancellationToken)][6]  

[1]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[2]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[3]: ../README.md
[4]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: README.md
[6]: SendEmail.md