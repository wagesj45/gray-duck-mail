ContactController.Create Method
===============================
Processes the contact creation form submission.

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][1]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public IActionResult Create(
	ContactForm formInput
)
```

#### Parameters

##### *formInput*
Type: [EasyMailDiscussion.Web.Models.Forms.ContactForm][2]  
 The form input.

#### Return Value
Type: [IActionResult][3]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/Contact/Create` post request. 

See Also
--------

#### Reference
[ContactController Class][4]  
[EasyMailDiscussion.Web.Controllers Namespace][1]  

[1]: ../README.md
[2]: ../../EasyMailDiscussion.Web.Models.Forms/ContactForm/README.md
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[4]: README.md