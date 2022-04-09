EmailFetcher.ProcessDiscussionMessages Method
=============================================
Process the non-command messages by relaying them to all subscribed members of the *discussionList*.

  **Namespace:**  [GrayDuckMail.Web.Worker][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
private static void ProcessDiscussionMessages(
	DiscussionList discussionList,
	IndexedMimeMessage discussionMessage,
	SqliteDatabase database,
	Pop3Client pop3Client,
	CancellationToken stoppingToken
)
```

#### Parameters

##### *discussionList*
Type: [GrayDuckMail.Common.Database.DiscussionList][2]  
 Discussion List database object.

##### *discussionMessage*
Type: [GrayDuckMail.Common.IndexedMimeMessage][3]  
 Message describing the discussion.

##### *database*
Type: [GrayDuckMail.Common.Database.SqliteDatabase][4]  
 The database.

##### *pop3Client*
Type: Pop3Client  
 The POP3 client.

##### *stoppingToken*
Type: [System.Threading.CancellationToken][5]  
 Triggered when [StopAsync(CancellationToken)][6] is called.


See Also
--------

#### Reference
[EmailFetcher Class][7]  
[GrayDuckMail.Web.Worker Namespace][1]  

[1]: ../README.md
[2]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[3]: ../../GrayDuckMail.Common/IndexedMimeMessage/README.md
[4]: ../../GrayDuckMail.Common.Database/SqliteDatabase/README.md
[5]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice.stopasync#microsoft-extensions-hosting-ihostedservice-stopasync(system-threading-cancellationtoken)
[7]: README.md