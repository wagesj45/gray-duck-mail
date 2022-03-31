EmailFetcher.ProcessRequests Method
===================================
Process the requests to join a the *discussionList*.

  **Namespace:**  [EasyMailDiscussion.Web.Worker][1]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
private static void ProcessRequests(
	DiscussionList discussionList,
	SqliteDatabase database,
	Pop3Client pop3Client,
	IndexedMimeMessage request,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *discussionList*
Type: [EasyMailDiscussion.Common.Database.DiscussionList][2]  
 Discussion List database object.

##### *database*
Type: [EasyMailDiscussion.Common.Database.SqliteDatabase][3]  
 The database.

##### *pop3Client*
Type: Pop3Client  
 The POP3 client.

##### *request*
Type: [EasyMailDiscussion.Common.IndexedMimeMessage][4]  
 The request message.

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][5]  
 (Optional) A token that allows processing to be cancelled.


See Also
--------

#### Reference
[EmailFetcher Class][6]  
[EasyMailDiscussion.Web.Worker Namespace][1]  

[1]: ../README.md
[2]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[3]: ../../EasyMailDiscussion.Common.Database/SqliteDatabase/README.md
[4]: ../../EasyMailDiscussion.Common/IndexedMimeMessage/README.md
[5]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: README.md