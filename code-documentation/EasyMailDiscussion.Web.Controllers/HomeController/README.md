HomeController Class
====================
Handles web requests for the default landing pages.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][1]  
  [EasyMailDiscussion.Web.Controllers.BaseController][2]  
    **EasyMailDiscussion.Web.Controllers.HomeController**  

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][3]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class HomeController : BaseController
```

The **HomeController** type exposes the following members.


Constructors
------------

|                                   | Name                | Description                                                |
| --------------------------------- | ------------------- | ---------------------------------------------------------- |
| ![Private method]![Static member] | [HomeController][4] |                                                            |
| ![Public method]                  | [HomeController][5] | Initializes a new instance of the **HomeController** class |


Properties
----------

|                    | Name                | Description                                                             |
| ------------------ | ------------------- | ----------------------------------------------------------------------- |
| ![Public property] | [SqliteDatabase][6] | Gets the SQLite database context. (Inherited from [BaseController][2].) |


Methods
-------

|                  | Name                   | Description                                                                       |
| ---------------- | ---------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [Error][7]             | Gets the error page.                                                              |
| ![Public method] | [Index][8]             | Gets the index or default request.                                                |
| ![Public method] | [OnActionExecuting][9] | Called before the action method is invoked. (Inherited from [BaseController][2].) |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Controllers Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[2]: ../BaseController/README.md
[3]: ../README.md
[4]: _cctor.md
[5]: _ctor.md
[6]: ../BaseController/SqliteDatabase.md
[7]: Error.md
[8]: Index.md
[9]: ../BaseController/OnActionExecuting.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"