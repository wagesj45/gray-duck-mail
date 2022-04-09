EmailHelper.RelayEmail Method
=============================
Relay an email to the [contacts][1][assigned][2] to a [discussion list][3].

  **Namespace:**  [GrayDuckMail.Common][4]  
  **Assembly:** gray-duck-mail-common.dll

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
Type: [GrayDuckMail.Common.Database.DiscussionList][3]  
 The discussion list.

##### *recipient*
Type: [GrayDuckMail.Common.Database.Contact][1]  
 The recipient.

##### *message*
Type: [GrayDuckMail.Common.Database.Message][5]  
 The message.

##### *database*
Type: [GrayDuckMail.Common.Database.SqliteDatabase][6]  
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
[GrayDuckMail.Common Namespace][4]  
[EmailHelper.SendEmail(DiscussionList, Contact, String, String, Func&lt;MimeEntity>, SmtpClient, CancellationToken)][10]  

[1]: ../../GrayDuckMail.Common.Database/Contact/README.md
[2]: ../../GrayDuckMail.Common.Database/ContactSubscription/README.md
[3]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[4]: ../README.md
[5]: ../../GrayDuckMail.Common.Database/Message/README.md
[6]: ../../GrayDuckMail.Common.Database/SqliteDatabase/README.md
[7]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[8]: https://docs.microsoft.com/dotnet/api/system.formatexception
[9]: README.md
[10]: SendEmail.md