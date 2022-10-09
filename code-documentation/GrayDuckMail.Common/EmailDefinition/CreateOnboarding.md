EmailDefinition.CreateOnboarding Method
=======================================
Creates an onboarding message definition.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static EmailDefinition CreateOnboarding(
	DiscussionList discussionList,
	Contact contact
)
```

#### Parameters

##### *discussionList*
Type: [GrayDuckMail.Common.Database.DiscussionList][2]  
 The discussion list to which the contact belongs.

##### *contact*
Type: [GrayDuckMail.Common.Database.Contact][3]  
 The contact being mailed.

#### Return Value
Type: [EmailDefinition][4]  
 The new definition of an onboarding message. 

See Also
--------

#### Reference
[EmailDefinition Class][4]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[3]: ../../GrayDuckMail.Common.Database/Contact/README.md
[4]: README.md