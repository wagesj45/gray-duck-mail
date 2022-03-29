EmailHelper.SendEmail Method
============================
Sends an email.

  **Namespace:**  [EasyMailDiscussion.Common][1]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static MimeMessage SendEmail(
	DiscussionList discussionList,
	Contact recipient,
	string subject,
	string replyTo,
	Func<MimeEntity> bodyGenerator,
	SmtpClient client,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *discussionList*
Type: [EasyMailDiscussion.Common.Database.DiscussionList][2]  
 The discussion list.

##### *recipient*
Type: [EasyMailDiscussion.Common.Database.Contact][3]  
 The recipient.

##### *subject*
Type: [System.String][4]  
 The subject.

##### *replyTo*
Type: [System.String][4]  

[Missing &lt;param name="replyTo"/> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


##### *bodyGenerator*
Type: [System.Func][5]&lt;MimeEntity>  
 The body generator function.

##### *client*
Type: SmtpClient  
 The SMTP client.

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][6]  
 (Optional) A token that allows processing to be cancelled.

#### Return Value
Type: MimeMessage  

[Missing &lt;returns> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


Remarks
-------
 The *client* will connect to the SMTP server defined in *discussionList* if the client is disconnected. The client will not disconnect at the end of this method. 

See Also
--------

#### Reference
[EmailHelper Class][7]  
[EasyMailDiscussion.Common Namespace][1]  

[1]: ../README.md
[2]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[3]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[4]: https://docs.microsoft.com/dotnet/api/system.string
[5]: https://docs.microsoft.com/dotnet/api/system.func-1
[6]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[7]: README.md