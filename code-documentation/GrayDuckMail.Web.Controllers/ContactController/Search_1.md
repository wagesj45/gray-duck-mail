ContactController.Search Method (String, Int32)
===============================================
Searches for the [contacts][1] with a matching [name][2] or [email address][3].

  **Namespace:**  [GrayDuckMail.Web.Controllers][4]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public IActionResult Search(
	string searchTerm,
	int pageNumber = 1
)
```

#### Parameters

##### *searchTerm*
Type: [System.String][5]  
 The search term.

##### *pageNumber* (Optional)
Type: [System.Int32][6]  
 (Optional) The page number.

#### Return Value
Type: [IActionResult][7]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/Contact/Search` request. 

See Also
--------

#### Reference
[ContactController Class][8]  
[GrayDuckMail.Web.Controllers Namespace][4]  

[1]: ../../GrayDuckMail.Common.Database/Contact/README.md
[2]: ../../GrayDuckMail.Common.Database/Contact/Name.md
[3]: ../../GrayDuckMail.Common.Database/Contact/Email.md
[4]: ../README.md
[5]: https://docs.microsoft.com/dotnet/api/system.string
[6]: https://docs.microsoft.com/dotnet/api/system.int32
[7]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[8]: README.md