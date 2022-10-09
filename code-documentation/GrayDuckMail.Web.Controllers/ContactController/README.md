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

|                    | Name                         | Description                                                                                                                                |
| ------------------ | ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public property] | [PageSize][7]                | Gets or sets the number of items to display on a page. (Inherited from [BaseController][3].)                                               |
| ![Public property] | [RequestFromExternalPort][8] | Gets or sets a value indicating whether the current request comes from the designated external port. (Inherited from [BaseController][3].) |
| ![Public property] | [SqliteDatabase][9]          | Gets the SQLite database context. (Inherited from [BaseController][3].)                                                                    |
| ![Public property] | [Theme][10]                  | Gets or sets the theme used by [Pico.css][11]. (Inherited from [BaseController][3].)                                                       |
| ![Public property] | [UseFuzzySearch][12]         | Gets or sets a value indicating whether search functions will employ fuzzy search. (Inherited from [BaseController][3].)                   |


Methods
-------

|                  | Name                        | Description                                                                       |
| ---------------- | --------------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [ConfirmRemove][13]         | Processes the contact removal request.                                            |
| ![Public method] | [Create][14]                | Processes the contact creation form submission.                                   |
| ![Public method] | [Edit(ContactForm)][15]     | Processes the contact editing form submission.                                    |
| ![Public method] | [Edit(Int32)][16]           | Gets the edit contact form request.                                               |
| ![Public method] | [Index][17]                 | Gets the index or default request.                                                |
| ![Public method] | [New][18]                   | Gets the new contact creation form request.                                       |
| ![Public method] | [OnActionExecuting][19]     | Called before the action method is invoked. (Inherited from [BaseController][3].) |
| ![Public method] | [Remove][20]                | Gets the contact removal form request.                                            |
| ![Public method] | [Search(String)][21]        | Searches for the [contacts][1] with a matching [name][22] or [email address][23]. |
| ![Public method] | [Search(String, Int32)][24] | Searches for the [contacts][1] with a matching [name][22] or [email address][23]. |


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
[8]: ../BaseController/RequestFromExternalPort.md
[9]: ../BaseController/SqliteDatabase.md
[10]: ../BaseController/Theme.md
[11]: https://picocss.com/docs/themes.html
[12]: ../BaseController/UseFuzzySearch.md
[13]: ConfirmRemove.md
[14]: Create.md
[15]: Edit.md
[16]: Edit_1.md
[17]: Index.md
[18]: New.md
[19]: ../BaseController/OnActionExecuting.md
[20]: Remove.md
[21]: Search.md
[22]: ../../GrayDuckMail.Common.Database/Contact/Name.md
[23]: ../../GrayDuckMail.Common.Database/Contact/Email.md
[24]: Search_1.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"