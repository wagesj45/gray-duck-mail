HomeController Class
====================
Handles web requests for the default landing pages.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][1]  
  [GrayDuckMail.Web.Controllers.BaseController][2]  
    **GrayDuckMail.Web.Controllers.HomeController**  

  **Namespace:**  [GrayDuckMail.Web.Controllers][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class HomeController : BaseController
```

The **HomeController** type exposes the following members.


Constructors
------------

|                                   | Name                | Description  |
| --------------------------------- | ------------------- | ------------ |
| ![Private method]![Static member] | [HomeController][4] |              |
| ![Public method]                  | [HomeController][5] | Constructor. |


Properties
----------

|                    | Name                 | Description                                                                                                              |
| ------------------ | -------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| ![Public property] | [PageSize][6]        | Gets or sets the number of items to display on a page. (Inherited from [BaseController][2].)                             |
| ![Public property] | [SqliteDatabase][7]  | Gets the SQLite database context. (Inherited from [BaseController][2].)                                                  |
| ![Public property] | [Theme][8]           | Gets or sets the theme used by [Pico.css][9]. (Inherited from [BaseController][2].)                                      |
| ![Public property] | [UseFuzzySearch][10] | Gets or sets a value indicating whether search functions will employ fuzzy search. (Inherited from [BaseController][2].) |


Methods
-------

|                  | Name                    | Description                                                                       |
| ---------------- | ----------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [Error][11]             | Gets the error page.                                                              |
| ![Public method] | [Index][12]             | Gets the index or default request.                                                |
| ![Public method] | [OnActionExecuting][13] | Called before the action method is invoked. (Inherited from [BaseController][2].) |


See Also
--------

#### Reference
[GrayDuckMail.Web.Controllers Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[2]: ../BaseController/README.md
[3]: ../README.md
[4]: _cctor.md
[5]: _ctor.md
[6]: ../BaseController/PageSize.md
[7]: ../BaseController/SqliteDatabase.md
[8]: ../BaseController/Theme.md
[9]: https://picocss.com/docs/themes.html
[10]: ../BaseController/UseFuzzySearch.md
[11]: Error.md
[12]: Index.md
[13]: ../BaseController/OnActionExecuting.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"