EmailHelper.ProcessHTMLRelay Method
===================================
Process the HTML body of a relayed message.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
private static MimeEntity ProcessHTMLRelay(
	DiscussionList discussionList,
	Message message,
	Contact sender
)
```

#### Parameters

##### *discussionList*
Type: [GrayDuckMail.Common.Database.DiscussionList][2]  
 The discussion list.

##### *message*
Type: [GrayDuckMail.Common.Database.Message][3]  
 The message.

##### *sender*
Type: [GrayDuckMail.Common.Database.Contact][4]  
 The sender.

#### Return Value
Type: MimeEntity  
 A MimeEntity. 

See Also
--------

#### Reference
[EmailHelper Class][5]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[3]: ../../GrayDuckMail.Common.Database/Message/README.md
[4]: ../../GrayDuckMail.Common.Database/Contact/README.md
[5]: README.md