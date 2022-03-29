EmailHelper.FillDefaultTemplate Method
======================================
Fill the default HTML email template with values.

  **Namespace:**  [EasyMailDiscussion.Common][1]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static string FillDefaultTemplate(
	string heading,
	string subheading,
	string body,
	string footer,
	DiscussionList discussionList
)
```

#### Parameters

##### *heading*
Type: [System.String][2]  
 The heading.

##### *subheading*
Type: [System.String][2]  
 The subheading.

##### *body*
Type: [System.String][2]  
 The body.

##### *footer*
Type: [System.String][2]  
 The footer.

##### *discussionList*
Type: [EasyMailDiscussion.Common.Database.DiscussionList][3]  
 The discussion list.

#### Return Value
Type: [String][2]  
 A string with a processed main email template. 

See Also
--------

#### Reference
[EmailHelper Class][4]  
[EasyMailDiscussion.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[4]: README.md