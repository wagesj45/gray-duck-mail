ExternalController Class
========================
Handles web requests from external sources.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][1]  
  [GrayDuckMail.Web.Controllers.BaseController][2]  
    **GrayDuckMail.Web.Controllers.ExternalController**  

  **Namespace:**  [GrayDuckMail.Web.Controllers][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class ExternalController : BaseController
```

The **ExternalController** type exposes the following members.


Constructors
------------

|                                   | Name                    | Description  |
| --------------------------------- | ----------------------- | ------------ |
| ![Private method]![Static member] | [ExternalController][4] |              |
| ![Public method]                  | [ExternalController][5] | Constructor. |


Properties
----------

|                    | Name                         | Description                                                                                                                                |
| ------------------ | ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public property] | [PageSize][6]                | Gets or sets the number of items to display on a page. (Inherited from [BaseController][2].)                                               |
| ![Public property] | [RequestFromExternalPort][7] | Gets or sets a value indicating whether the current request comes from the designated external port. (Inherited from [BaseController][2].) |
| ![Public property] | [SqliteDatabase][8]          | Gets the SQLite database context. (Inherited from [BaseController][2].)                                                                    |
| ![Public property] | [Theme][9]                   | Gets or sets the theme used by [Pico.css][10]. (Inherited from [BaseController][2].)                                                       |
| ![Public property] | [UseFuzzySearch][11]         | Gets or sets a value indicating whether search functions will employ fuzzy search. (Inherited from [BaseController][2].)                   |


Methods
-------

|                  | Name                    | Description                                                                       |
| ---------------- | ----------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [OnActionExecuting][12] | Called before the action method is invoked. (Inherited from [BaseController][2].) |
| ![Public method] | [Unsubscribe][13]       | Gets the index or default request.                                                |


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
[7]: ../BaseController/RequestFromExternalPort.md
[8]: ../BaseController/SqliteDatabase.md
[9]: ../BaseController/Theme.md
[10]: https://picocss.com/docs/themes.html
[11]: ../BaseController/UseFuzzySearch.md
[12]: ../BaseController/OnActionExecuting.md
[13]: Unsubscribe.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"