EmailHelper.SendEmail Method
============================

[Missing &lt;summary> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


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

[Missing &lt;param name="discussionList"/> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


##### *recipient*
Type: [EasyMailDiscussion.Common.Database.Contact][3]  

[Missing &lt;param name="recipient"/> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


##### *subject*
Type: [System.String][4]  

[Missing &lt;param name="subject"/> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


##### *replyTo*
Type: [System.String][4]  

[Missing &lt;param name="replyTo"/> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


##### *bodyGenerator*
Type: [System.Func][5]&lt;MimeEntity>  

[Missing &lt;param name="bodyGenerator"/> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


##### *client*
Type: SmtpClient  

[Missing &lt;param name="client"/> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][6]  

[Missing &lt;param name="cancellationToken"/> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


#### Return Value
Type: MimeMessage  

[Missing &lt;returns> documentation for "M:EasyMailDiscussion.Common.EmailHelper.SendEmail(EasyMailDiscussion.Common.Database.DiscussionList,EasyMailDiscussion.Common.Database.Contact,System.String,System.String,System.Func{MimeKit.MimeEntity},MailKit.Net.Smtp.SmtpClient,System.Threading.CancellationToken)"]


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