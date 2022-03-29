EmailHelper.IsAssignable Method
===============================
Query if a given user can be assigned to a discussion list.

  **Namespace:**  [EasyMailDiscussion.Common][1]  
  **Assembly:** easy-mail-discussion-common.dll

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
Type: [EasyMailDiscussion.Common.Database.DiscussionList][2]  
 The discussion list.

##### *contact*
Type: [EasyMailDiscussion.Common.Database.Contact][3]  
 The contact.

#### Return Value
Type: [Boolean][4]  
 True if assignable, false if not. 

See Also
--------

#### Reference
[EmailHelper Class][5]  
[EasyMailDiscussion.Common Namespace][1]  

[1]: ../README.md
[2]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[3]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[4]: https://docs.microsoft.com/dotnet/api/system.boolean
[5]: README.md