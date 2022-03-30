BaseController Class
====================
A controller used as a base class in the [EasyMailDiscussion.Web][1] project.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][2]  
  **EasyMailDiscussion.Web.Controllers.BaseController**  
    [EasyMailDiscussion.Web.Controllers.AdminController][3]  
    [EasyMailDiscussion.Web.Controllers.ContactController][4]  
    [EasyMailDiscussion.Web.Controllers.HomeController][5]  
    [EasyMailDiscussion.Web.Controllers.ListController][6]  

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][7]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public abstract class BaseController : Controller
```

The **BaseController** type exposes the following members.


Constructors
------------

|                                   | Name                | Description  |
| --------------------------------- | ------------------- | ------------ |
| ![Private method]![Static member] | [BaseController][8] |              |
| ![Public method]                  | [BaseController][9] | Constructor. |


Properties
----------

|                    | Name                 | Description                       |
| ------------------ | -------------------- | --------------------------------- |
| ![Public property] | [SqliteDatabase][10] | Gets the SQLite database context. |


Methods
-------

|                  | Name                    | Description                                 |
| ---------------- | ----------------------- | ------------------------------------------- |
| ![Public method] | [OnActionExecuting][11] | Called before the action method is invoked. |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Controllers Namespace][7]  

[1]: ../../EasyMailDiscussion.Web/README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[3]: ../AdminController/README.md
[4]: ../ContactController/README.md
[5]: ../HomeController/README.md
[6]: ../ListController/README.md
[7]: ../README.md
[8]: _cctor.md
[9]: _ctor.md
[10]: SqliteDatabase.md
[11]: OnActionExecuting.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"