ListController.Search Method (Int32, String, Int32)
===================================================
Searches for the [messages][1] with a matching [subject][2], [body text][3], [body HTML][4], or [contact][5].

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][6]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public IActionResult Search(
	int discussionListID,
	string searchTerm,
	int pageNumber = 1
)
```

#### Parameters

##### *discussionListID*
Type: [System.Int32][7]  
 Identifier for the discussion list.

##### *searchTerm*
Type: [System.String][8]  
 The search term.

##### *pageNumber* (Optional)
Type: [System.Int32][7]  
 (Optional) The page number.

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

[1]: Message.md
[2]: ../../EasyMailDiscussion.Common.Database/Message/Subject.md
[3]: ../../EasyMailDiscussion.Common.Database/Message/BodyText.md
[4]: ../../EasyMailDiscussion.Common.Database/Message/BodyHTML.md
[5]: ../../EasyMailDiscussion.Common.Database/Message/OriginatorContact.md
[6]: ../README.md
[7]: https://docs.microsoft.com/dotnet/api/system.int32
[8]: https://docs.microsoft.com/dotnet/api/system.string
[9]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[10]: README.md