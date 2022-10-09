EmailDefinition.CreateRelay Method
==================================
Creates a relayed message definition.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static EmailDefinition CreateRelay(
	DiscussionList discussionList,
	Contact contact,
	Message message
)
```

#### Parameters

##### *discussionList*
Type: [GrayDuckMail.Common.Database.DiscussionList][2]  
 The discussion list to which the message belongs.

##### *contact*
Type: [GrayDuckMail.Common.Database.Contact][3]  
 The contact sending the message.

##### *message*
Type: [GrayDuckMail.Common.Database.Message][4]  
 The email message.

#### Return Value
Type: [EmailDefinition][5]  
 The new definition of a relayed message. 

See Also
--------

#### Reference
[EmailDefinition Class][5]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[3]: ../../GrayDuckMail.Common.Database/Contact/README.md
[4]: ../../GrayDuckMail.Common.Database/Message/README.md
[5]: README.md