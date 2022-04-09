ContactController.Remove Method
===============================
Gets the contact removal form request.

  **Namespace:**  [GrayDuckMail.Web.Controllers][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public IActionResult Remove(
	int contactID
)
```

#### Parameters

##### *contactID*
Type: [System.Int32][2]  
 Identifier for the contact.

#### Return Value
Type: [IActionResult][3]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/Contact/Remove` request. 

See Also
--------

#### Reference
[ContactController Class][4]  
[GrayDuckMail.Web.Controllers Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[4]: README.md