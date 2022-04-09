ListController.Message Method
=============================
Gets the message request.

  **Namespace:**  [GrayDuckMail.Web.Controllers][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public IActionResult Message(
	int messageID,
	int pageNumber = 1
)
```

#### Parameters

##### *messageID*
Type: [System.Int32][2]  
 Identifier for the message.

##### *pageNumber* (Optional)
Type: [System.Int32][2]  
 (Optional) The page number.

#### Return Value
Type: [IActionResult][3]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/List/Message` request. 

See Also
--------

#### Reference
[ListController Class][4]  
[GrayDuckMail.Web.Controllers Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[4]: README.md