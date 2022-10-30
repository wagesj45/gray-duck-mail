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
	EmailClientWrapper client,
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

##### *client*
Type: [GrayDuckMail.Common.EmailClientWrapper][4]  
 The email client.

##### *unsubscribeConfirmation*
Type: [GrayDuckMail.Common.IndexedMimeMessage][5]  
 The unsubscribe confirmation.


See Also
--------

#### Reference
[EmailFetcher Class][6]  
[GrayDuckMail.Web.Worker Namespace][1]  

[1]: ../README.md
[2]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[3]: ../../GrayDuckMail.Common.Database/SqliteDatabase/README.md
[4]: ../../GrayDuckMail.Common/EmailClientWrapper/README.md
[5]: ../../GrayDuckMail.Common/IndexedMimeMessage/README.md
[6]: README.md