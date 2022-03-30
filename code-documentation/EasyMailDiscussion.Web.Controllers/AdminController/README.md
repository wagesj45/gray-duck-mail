AdminController Class
=====================
Handles web requests for [Contact][1] manipulation operations.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][2]  
  [EasyMailDiscussion.Web.Controllers.BaseController][3]  
    **EasyMailDiscussion.Web.Controllers.AdminController**  

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][4]  
  **Assembly:** easy-mail-discussion-web.exe

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

|                    | Name                | Description                                                             |
| ------------------ | ------------------- | ----------------------------------------------------------------------- |
| ![Public property] | [SqliteDatabase][7] | Gets the SQLite database context. (Inherited from [BaseController][3].) |


Methods
-------

|                  | Name                    | Description                                                                       |
| ---------------- | ----------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [ExportDatabase][8]     | Exports the database as a downloadable file.                                      |
| ![Public method] | [ImportDatabase][9]     | Imports a SQLite database file and replaces the existing database file.           |
| ![Public method] | [Index][10]             | Gets the index or default request.                                                |
| ![Public method] | [OnActionExecuting][11] | Called before the action method is invoked. (Inherited from [BaseController][3].) |


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
[8]: ExportDatabase.md
[9]: ImportDatabase.md
[10]: Index.md
[11]: ../BaseController/OnActionExecuting.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"