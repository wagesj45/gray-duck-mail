EmailFetcher.ProcessUnsubscribeConfirmations Method
===================================================
Process the unsubscribe confirmations for the *discussionList*.

  **Namespace:**  [GrayDuckMail.Web.Worker][1]  
  **Assembly:** gray-duck-mail-web.exe

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
Type: [GrayDuckMail.Common.Database.DiscussionList][2]  
 Discussion List database object.

##### *database*
Type: [GrayDuckMail.Common.Database.SqliteDatabase][3]  
 The database.

##### *pop3Client*
Type: Pop3Client  
 The POP3 client.

##### *unsubscribeConfirmation*
Type: [GrayDuckMail.Common.IndexedMimeMessage][4]  
 The unsubscribe confirmation.


See Also
--------

#### Reference
[EmailFetcher Class][5]  
[GrayDuckMail.Web.Worker Namespace][1]  

[1]: ../README.md
[2]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[3]: ../../GrayDuckMail.Common.Database/SqliteDatabase/README.md
[4]: ../../GrayDuckMail.Common/IndexedMimeMessage/README.md
[5]: README.md