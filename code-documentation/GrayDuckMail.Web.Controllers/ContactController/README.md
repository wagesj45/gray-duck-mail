ContactController Class
=======================
Handles web requests for [Contact][1] manipulation operations.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][2]  
  [GrayDuckMail.Web.Controllers.BaseController][3]  
    **GrayDuckMail.Web.Controllers.ContactController**  

  **Namespace:**  [GrayDuckMail.Web.Controllers][4]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class ContactController : BaseController
```

The **ContactController** type exposes the following members.


Constructors
------------

|                                   | Name                   | Description  |
| --------------------------------- | ---------------------- | ------------ |
| ![Private method]![Static member] | [ContactController][5] |              |
| ![Public method]                  | [ContactController][6] | Constructor. |


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

|                  | Name                        | Description                                                                       |
| ---------------- | --------------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [ConfirmRemove][12]         | Processes the contact removal request.                                            |
| ![Public method] | [Create][13]                | Processes the contact creation form submission.                                   |
| ![Public method] | [Edit(ContactForm)][14]     | Processes the contact editing form submission.                                    |
| ![Public method] | [Edit(Int32)][15]           | Gets the edit contact form request.                                               |
| ![Public method] | [Index][16]                 | Gets the index or default request.                                                |
| ![Public method] | [New][17]                   | Gets the new contact creation form request.                                       |
| ![Public method] | [OnActionExecuting][18]     | Called before the action method is invoked. (Inherited from [BaseController][3].) |
| ![Public method] | [Remove][19]                | Gets the contact removal form request.                                            |
| ![Public method] | [Search(String)][20]        | Searches for the [contacts][1] with a matching [name][21] or [email address][22]. |
| ![Public method] | [Search(String, Int32)][23] | Searches for the [contacts][1] with a matching [name][21] or [email address][22]. |


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
[12]: ConfirmRemove.md
[13]: Create.md
[14]: Edit.md
[15]: Edit_1.md
[16]: Index.md
[17]: New.md
[18]: ../BaseController/OnActionExecuting.md
[19]: Remove.md
[20]: Search.md
[21]: ../../GrayDuckMail.Common.Database/Contact/Name.md
[22]: ../../GrayDuckMail.Common.Database/Contact/Email.md
[23]: Search_1.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"