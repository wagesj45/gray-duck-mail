ContactController Class
=======================
Handles web requests for [Contact][1] manipulation operations.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][2]  
  [EasyMailDiscussion.Web.Controllers.BaseController][3]  
    **EasyMailDiscussion.Web.Controllers.ContactController**  

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][4]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class ContactController : BaseController
```

The **ContactController** type exposes the following members.


Constructors
------------

|                                   | Name                   | Description                                                   |
| --------------------------------- | ---------------------- | ------------------------------------------------------------- |
| ![Private method]![Static member] | [ContactController][5] |                                                               |
| ![Public method]                  | [ContactController][6] | Initializes a new instance of the **ContactController** class |


Properties
----------

|                    | Name                | Description                                                             |
| ------------------ | ------------------- | ----------------------------------------------------------------------- |
| ![Public property] | [SqliteDatabase][7] | Gets the SQLite database context. (Inherited from [BaseController][3].) |


Methods
-------

|                  | Name                    | Description                                                                       |
| ---------------- | ----------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [ConfirmRemove][8]      | Processes the contact removal request.                                            |
| ![Public method] | [Create][9]             | Processes the contact creation form submission.                                   |
| ![Public method] | [Edit(ContactForm)][10] | Processes the contact editing form submission.                                    |
| ![Public method] | [Edit(Int32)][11]       | Gets the edit contact form request.                                               |
| ![Public method] | [Index][12]             | Gets the index or default request.                                                |
| ![Public method] | [New][13]               | Gets the new contact creation form request.                                       |
| ![Public method] | [OnActionExecuting][14] | Called before the action method is invoked. (Inherited from [BaseController][3].) |
| ![Public method] | [Remove][15]            | Gets the contact removal form request.                                            |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Controllers Namespace][4]  

[1]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[3]: ../BaseController/README.md
[4]: ../README.md
[5]: _cctor.md
[6]: _ctor.md
[7]: ../BaseController/SqliteDatabase.md
[8]: ConfirmRemove.md
[9]: Create.md
[10]: Edit.md
[11]: Edit_1.md
[12]: Index.md
[13]: New.md
[14]: ../BaseController/OnActionExecuting.md
[15]: Remove.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"