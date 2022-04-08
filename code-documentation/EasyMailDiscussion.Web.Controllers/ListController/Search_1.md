ListController.Search Method (String, Int32)
============================================
Searches for the [messages][1] with a matching [subject][2], [body text][3], [body HTML][4], or [contact][5].

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][6]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public IActionResult Search(
	string searchTerm,
	int discussionListID
)
```

#### Parameters

##### *searchTerm*
Type: [System.String][7]  
 The search term.

##### *discussionListID*
Type: [System.Int32][8]  
 Identifier for the discussion list.

#### Return Value
Type: [IActionResult][9]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/List/Search` post request. 

See Also
--------

#### Reference
[ListController Class][10]  
[EasyMailDiscussion.Web.Controllers Namespace][6]  
[ContactController.Search(String)][11]  

[1]: Message.md
[2]: ../../EasyMailDiscussion.Common.Database/Message/Subject.md
[3]: ../../EasyMailDiscussion.Common.Database/Message/BodyText.md
[4]: ../../EasyMailDiscussion.Common.Database/Message/BodyHTML.md
[5]: ../../EasyMailDiscussion.Common.Database/Message/OriginatorContact.md
[6]: ../README.md
[7]: https://docs.microsoft.com/dotnet/api/system.string
[8]: https://docs.microsoft.com/dotnet/api/system.int32
[9]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[10]: README.md
[11]: ../ContactController/Search.md