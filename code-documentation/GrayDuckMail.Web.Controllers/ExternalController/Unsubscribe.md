ExternalController.Unsubscribe Method
=====================================
Gets the index or default request.

  **Namespace:**  [GrayDuckMail.Web.Controllers][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public IActionResult Unsubscribe(
	int contactID,
	int discussionListID
)
```

#### Parameters

##### *contactID*
Type: [System.Int32][2]  
 Identifier for the contact.

##### *discussionListID*
Type: [System.Int32][2]  
 Identifier for the discussion list.

#### Return Value
Type: [IActionResult][3]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/Unsubscribe` request. Because this method may be accessed externally, all input must be validated and checked. 

See Also
--------

#### Reference
[ExternalController Class][4]  
[GrayDuckMail.Web.Controllers Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[4]: README.md