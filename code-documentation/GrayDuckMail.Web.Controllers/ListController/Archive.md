ListController.Archive Method
=============================
Gets the message archive request.

  **Namespace:**  [GrayDuckMail.Web.Controllers][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public IActionResult Archive(
	int discussionListID,
	int pageNumber = 1
)
```

#### Parameters

##### *discussionListID*
Type: [System.Int32][2]  
 Identifier for the discussion list.

##### *pageNumber* (Optional)
Type: [System.Int32][2]  
 (Optional) The page number.

#### Return Value
Type: [IActionResult][3]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/List/Archive` request. 

See Also
--------

#### Reference
[ListController Class][4]  
[GrayDuckMail.Web.Controllers Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[4]: README.md