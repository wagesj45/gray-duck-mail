AdminController Class
=====================
Handles web requests for [Contact][1] manipulation operations.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][2]  
  [GrayDuckMail.Web.Controllers.BaseController][3]  
    **GrayDuckMail.Web.Controllers.AdminController**  

  **Namespace:**  [GrayDuckMail.Web.Controllers][4]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class AdminController : BaseController
```

The **AdminController** type exposes the following members.


Constructors
------------

|                                   | Name                 | Description  |
| --------------------------------- | -------------------- | ------------ |
| ![Private method]![Static member] | [AdminController][5] |              |
| ![Public method]                  | [AdminController][6] | Constructor. |


Properties
----------

|                    | Name                 | Description                                                                                                              |
| ------------------ | -------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| ![Public property] | [PageSize][7]        | Gets or sets the number of items to display on a page. (Inherited from [BaseController][3].)                             |
| ![Public property] | [SqliteDatabase][8]  | Gets the SQLite database context. (Inherited from [BaseController][3].)                                                  |
| ![Public property] | [Theme][9]           | Gets or sets the theme used by [Pico.css][10]. (Inherited from [BaseController][3].)                                     |
| ![Public property] | [UseFuzzySearch][11] | Gets or sets a value indicating whether search functions will employ fuzzy search. (Inherited from [BaseController][3].) |


Methods
-------

|                  | Name                    | Description                                                                       |
| ---------------- | ----------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [ExportDatabase][12]    | Exports the database as a downloadable file.                                      |
| ![Public method] | [ImportDatabase][13]    | Imports a SQLite database file and replaces the existing database file.           |
| ![Public method] | [Index][14]             | Gets the index or default request.                                                |
| ![Public method] | [OnActionExecuting][15] | Called before the action method is invoked. (Inherited from [BaseController][3].) |
| ![Public method] | [SaveSettings][16]      | Saves web administration settings.                                                |


See Also
--------

#### Reference
[GrayDuckMail.Web.Controllers Namespace][4]  

[1]: ../../GrayDuckMail.Common.Database/Contact/README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[3]: ../BaseController/README.md
[4]: ../README.md
[5]: _cctor.md
[6]: _ctor.md
[7]: ../BaseController/PageSize.md
[8]: ../BaseController/SqliteDatabase.md
[9]: ../BaseController/Theme.md
[10]: https://picocss.com/docs/themes.html
[11]: ../BaseController/UseFuzzySearch.md
[12]: ExportDatabase.md
[13]: ImportDatabase.md
[14]: Index.md
[15]: ../BaseController/OnActionExecuting.md
[16]: SaveSettings.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"