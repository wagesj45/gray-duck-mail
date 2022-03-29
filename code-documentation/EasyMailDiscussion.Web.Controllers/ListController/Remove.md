ListController.Remove Method
============================
Processes the discussion list removal form request.

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][1]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public IActionResult Remove(
	int discussionListID
)
```

#### Parameters

##### *discussionListID*
Type: [System.Int32][2]  
 Identifier for the discussion list.

#### Return Value
Type: [IActionResult][3]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/List/Remove` request. 

See Also
--------

#### Reference
[ListController Class][4]  
[EasyMailDiscussion.Web.Controllers Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[4]: README.md