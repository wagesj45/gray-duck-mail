BaseController Class
====================
A controller used as a base class in the [EasyMailDiscussion.Web][1] project.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][2]  
  **EasyMailDiscussion.Web.Controllers.BaseController**  
    [EasyMailDiscussion.Web.Controllers.ContactController][3]  
    [EasyMailDiscussion.Web.Controllers.HomeController][4]  
    [EasyMailDiscussion.Web.Controllers.ListController][5]  

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][6]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class BaseController : Controller
```

The **BaseController** type exposes the following members.


Constructors
------------

|                  | Name                | Description                                                |
| ---------------- | ------------------- | ---------------------------------------------------------- |
| ![Public method] | [BaseController][7] | Initializes a new instance of the **BaseController** class |


Properties
----------

|                    | Name                | Description                       |
| ------------------ | ------------------- | --------------------------------- |
| ![Public property] | [SqliteDatabase][8] | Gets the SQLite database context. |


Methods
-------

|                  | Name                   | Description                                 |
| ---------------- | ---------------------- | ------------------------------------------- |
| ![Public method] | [OnActionExecuting][9] | Called before the action method is invoked. |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Controllers Namespace][6]  

[1]: ../../EasyMailDiscussion.Web/README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[3]: ../ContactController/README.md
[4]: ../HomeController/README.md
[5]: ../ListController/README.md
[6]: ../README.md
[7]: _ctor.md
[8]: SqliteDatabase.md
[9]: OnActionExecuting.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"