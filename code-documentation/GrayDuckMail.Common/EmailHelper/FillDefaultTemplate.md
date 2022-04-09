EmailHelper.FillDefaultTemplate Method
======================================
Fill the default HTML email template with values.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

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
Type: [GrayDuckMail.Common.Database.DiscussionList][3]  
 The discussion list.

#### Return Value
Type: [String][2]  
 A string with a processed main email template. 

See Also
--------

#### Reference
[EmailHelper Class][4]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[4]: README.md