BaseController Class
====================
A controller used as a base class in the [GrayDuckMail.Web][1] project.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][2]  
  **GrayDuckMail.Web.Controllers.BaseController**  
    [GrayDuckMail.Web.Controllers.AdminController][3]  
    [GrayDuckMail.Web.Controllers.ContactController][4]  
    [GrayDuckMail.Web.Controllers.HomeController][5]  
    [GrayDuckMail.Web.Controllers.ListController][6]  

  **Namespace:**  [GrayDuckMail.Web.Controllers][7]  
  **Assembly:** gray-duck-mail-web.exe

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

|                    | Name                 | Description                                                                        |
| ------------------ | -------------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [PageSize][10]       | Gets or sets the number of items to display on a page.                             |
| ![Public property] | [SqliteDatabase][11] | Gets the SQLite database context.                                                  |
| ![Public property] | [UseFuzzySearch][12] | Gets or sets a value indicating whether search functions will employ fuzzy search. |


Methods
-------

|                  | Name                    | Description                                 |
| ---------------- | ----------------------- | ------------------------------------------- |
| ![Public method] | [OnActionExecuting][13] | Called before the action method is invoked. |


See Also
--------

#### Reference
[GrayDuckMail.Web.Controllers Namespace][7]  

[1]: ../../GrayDuckMail.Web/README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[3]: ../AdminController/README.md
[4]: ../ContactController/README.md
[5]: ../HomeController/README.md
[6]: ../ListController/README.md
[7]: ../README.md
[8]: _cctor.md
[9]: _ctor.md
[10]: PageSize.md
[11]: SqliteDatabase.md
[12]: UseFuzzySearch.md
[13]: OnActionExecuting.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"