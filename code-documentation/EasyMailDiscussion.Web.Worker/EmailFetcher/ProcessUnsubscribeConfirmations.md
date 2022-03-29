EmailFetcher.ProcessUnsubscribeConfirmations Method
===================================================
Process the unsubscribe confirmations for the *discussionList*.

  **Namespace:**  [EasyMailDiscussion.Web.Worker][1]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
private static void ProcessUnsubscribeConfirmations(
	DiscussionList discussionList,
	SqliteDatabase database,
	Pop3Client pop3Client,
	IndexedMimeMessage unsubscribeConfirmation
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

##### *unsubscribeConfirmation*
Type: [EasyMailDiscussion.Common.IndexedMimeMessage][4]  
 The unsubscribe confirmation.


See Also
--------

#### Reference
[EmailFetcher Class][5]  
[EasyMailDiscussion.Web.Worker Namespace][1]  

[1]: ../README.md
[2]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[3]: ../../EasyMailDiscussion.Common.Database/SqliteDatabase/README.md
[4]: ../../EasyMailDiscussion.Common/IndexedMimeMessage/README.md
[5]: README.md