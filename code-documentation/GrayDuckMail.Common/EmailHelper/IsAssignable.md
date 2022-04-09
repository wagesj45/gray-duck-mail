EmailHelper.IsAssignable Method
===============================
Query if a given user can be assigned to a discussion list.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static bool IsAssignable(
	DiscussionList discussionList,
	Contact contact
)
```

#### Parameters

##### *discussionList*
Type: [GrayDuckMail.Common.Database.DiscussionList][2]  
 The discussion list.

##### *contact*
Type: [GrayDuckMail.Common.Database.Contact][3]  
 The contact.

#### Return Value
Type: [Boolean][4]  
 True if assignable, false if not. 

See Also
--------

#### Reference
[EmailHelper Class][5]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[3]: ../../GrayDuckMail.Common.Database/Contact/README.md
[4]: https://docs.microsoft.com/dotnet/api/system.boolean
[5]: README.md