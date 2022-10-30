EmailFetcher.ProcessBounces Method
==================================
Process the bounced messages recieved from a contact.

  **Namespace:**  [GrayDuckMail.Web.Worker][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
private static void ProcessBounces(
	DiscussionList discussionList,
	SqliteDatabase database,
	EmailClientWrapper client,
	IndexedMimeMessage bounce
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

##### *bounce*
Type: [GrayDuckMail.Common.IndexedMimeMessage][5]  
 The bounced message.


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