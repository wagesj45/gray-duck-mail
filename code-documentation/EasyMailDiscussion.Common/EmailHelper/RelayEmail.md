EmailHelper.RelayEmail Method
=============================
Relay an email to the [contacts][1][assigned][2] to a [discussion list][3].

  **Namespace:**  [EasyMailDiscussion.Common][4]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static void RelayEmail(
	DiscussionList discussionList,
	Contact recipient,
	Message message,
	SqliteDatabase database,
	SmtpClient client,
	CancellationToken stoppingToken = default
)
```

#### Parameters

##### *discussionList*
Type: [EasyMailDiscussion.Common.Database.DiscussionList][3]  
 The discussion list.

##### *recipient*
Type: [EasyMailDiscussion.Common.Database.Contact][1]  
 The recipient.

##### *message*
Type: [EasyMailDiscussion.Common.Database.Message][5]  
 The message.

##### *database*
Type: [EasyMailDiscussion.Common.Database.SqliteDatabase][6]  
 The database.

##### *client*
Type: SmtpClient  
 The SMTP client.

##### *stoppingToken* (Optional)
Type: [System.Threading.CancellationToken][7]  
 (Optional) A token that allows processing to be cancelled.


Exceptions
----------

| Exception            | Condition                                        |
| -------------------- | ------------------------------------------------ |
| [FormatException][8] | Thrown when the format of an input is incorrect. |


See Also
--------

#### Reference
[EmailHelper Class][9]  
[EasyMailDiscussion.Common Namespace][4]  
[EmailHelper.SendEmail(DiscussionList, Contact, String, String, Func&lt;MimeEntity>, SmtpClient, CancellationToken)][10]  

[1]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[2]: ../../EasyMailDiscussion.Common.Database/ContactSubscription/README.md
[3]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[4]: ../README.md
[5]: ../../EasyMailDiscussion.Common.Database/Message/README.md
[6]: ../../EasyMailDiscussion.Common.Database/SqliteDatabase/README.md
[7]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[8]: https://docs.microsoft.com/dotnet/api/system.formatexception
[9]: README.md
[10]: SendEmail.md