EmailFetcher.ProcessSubscriptionConfirmations Method
====================================================
Process the subscription confirmations for the *discussionList*.

  **Namespace:**  [EasyMailDiscussion.Web.Worker][1]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
private static void ProcessSubscriptionConfirmations(
	DiscussionList discussionList,
	SqliteDatabase database,
	Pop3Client pop3Client,
	IndexedMimeMessage subscriptionConfirmation,
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

##### *subscriptionConfirmation*
Type: [EasyMailDiscussion.Common.IndexedMimeMessage][4]  
 The subscription confirmation.

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