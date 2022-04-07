ContactController.Search Method (String)
========================================
Searches for the [contacts][1] with a matching [name][2] or [email address][3].

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][4]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public IActionResult Search(
	string searchTerm
)
```

#### Parameters

##### *searchTerm*
Type: [System.String][5]  
 The search term.

#### Return Value
Type: [IActionResult][6]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/Contact/Search` post request. 

See Also
--------

#### Reference
[ContactController Class][7]  
[EasyMailDiscussion.Web.Controllers Namespace][4]  

[1]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[2]: ../../EasyMailDiscussion.Common.Database/Contact/Name.md
[3]: ../../EasyMailDiscussion.Common.Database/Contact/Email.md
[4]: ../README.md
[5]: https://docs.microsoft.com/dotnet/api/system.string
[6]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[7]: README.md