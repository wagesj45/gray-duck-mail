ListController.Create Method
============================
Processes the discussion list creation form submission.

  **Namespace:**  [GrayDuckMail.Web.Controllers][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public IActionResult Create(
	DiscussionListForm formInput
)
```

#### Parameters

##### *formInput*
Type: [GrayDuckMail.Web.Models.Forms.DiscussionListForm][2]  
 The form input.

#### Return Value
Type: [IActionResult][3]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/List/Create` post request. 

See Also
--------

#### Reference
[ListController Class][4]  
[GrayDuckMail.Web.Controllers Namespace][1]  

[1]: ../README.md
[2]: ../../GrayDuckMail.Web.Models.Forms/DiscussionListForm/README.md
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[4]: README.md