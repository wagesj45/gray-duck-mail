EmailFetcher.ProcessDiscussionMessages Method
=============================================
Process the non-command messages by relaying them to all subscribed members of the *discussionList*.

  **Namespace:**  [EasyMailDiscussion.Web.Worker][1]  
  **Assembly:** easy-mail-discussion-web.exe

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
Type: [EasyMailDiscussion.Common.Database.DiscussionList][2]  
 Discussion List database object.

##### *discussionMessage*
Type: [EasyMailDiscussion.Common.IndexedMimeMessage][3]  
 Message describing the discussion.

##### *database*
Type: [EasyMailDiscussion.Common.Database.SqliteDatabase][4]  
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
[EasyMailDiscussion.Web.Worker Namespace][1]  

[1]: ../README.md
[2]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[3]: ../../EasyMailDiscussion.Common/IndexedMimeMessage/README.md
[4]: ../../EasyMailDiscussion.Common.Database/SqliteDatabase/README.md
[5]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice.stopasync#microsoft-extensions-hosting-ihostedservice-stopasync(system-threading-cancellationtoken)
[7]: README.md