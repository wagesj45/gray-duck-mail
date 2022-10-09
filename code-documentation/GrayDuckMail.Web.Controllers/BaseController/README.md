BaseController Class
====================
A controller used as a base class in the [GrayDuckMail.Web][1] project.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][2]  
  **GrayDuckMail.Web.Controllers.BaseController**  
    [GrayDuckMail.Web.Controllers.AdminController][3]  
    [GrayDuckMail.Web.Controllers.ContactController][4]  
    [GrayDuckMail.Web.Controllers.ExternalController][5]  
    [GrayDuckMail.Web.Controllers.HomeController][6]  
    [GrayDuckMail.Web.Controllers.ListController][7]  

  **Namespace:**  [GrayDuckMail.Web.Controllers][8]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public abstract class BaseController : Controller
```

The **BaseController** type exposes the following members.


Constructors
------------

|                                   | Name                 | Description  |
| --------------------------------- | -------------------- | ------------ |
| ![Private method]![Static member] | [BaseController][9]  |              |
| ![Public method]                  | [BaseController][10] | Constructor. |


Properties
----------

|                    | Name                          | Description                                                                                          |
| ------------------ | ----------------------------- | ---------------------------------------------------------------------------------------------------- |
| ![Public property] | [PageSize][11]                | Gets or sets the number of items to display on a page.                                               |
| ![Public property] | [RequestFromExternalPort][12] | Gets or sets a value indicating whether the current request comes from the designated external port. |
| ![Public property] | [SqliteDatabase][13]          | Gets the SQLite database context.                                                                    |
| ![Public property] | [Theme][14]                   | Gets or sets the theme used by [Pico.css][15].                                                       |
| ![Public property] | [UseFuzzySearch][16]          | Gets or sets a value indicating whether search functions will employ fuzzy search.                   |


Methods
-------

|                  | Name                    | Description                                 |
| ---------------- | ----------------------- | ------------------------------------------- |
| ![Public method] | [OnActionExecuting][17] | Called before the action method is invoked. |


See Also
--------

#### Reference
[GrayDuckMail.Web.Controllers Namespace][8]  

[1]: ../../GrayDuckMail.Web/README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[3]: ../AdminController/README.md
[4]: ../ContactController/README.md
[5]: ../ExternalController/README.md
[6]: ../HomeController/README.md
[7]: ../ListController/README.md
[8]: ../README.md
[9]: _cctor.md
[10]: _ctor.md
[11]: PageSize.md
[12]: RequestFromExternalPort.md
[13]: SqliteDatabase.md
[14]: Theme.md
[15]: https://picocss.com/docs/themes.html
[16]: UseFuzzySearch.md
[17]: OnActionExecuting.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"