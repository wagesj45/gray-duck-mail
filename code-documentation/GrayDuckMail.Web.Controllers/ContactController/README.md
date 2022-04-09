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

|                    | Name                | Description                                                                                                              |
| ------------------ | ------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| ![Public property] | [PageSize][7]       | Gets or sets the number of items to display on a page. (Inherited from [BaseController][3].)                             |
| ![Public property] | [SqliteDatabase][8] | Gets the SQLite database context. (Inherited from [BaseController][3].)                                                  |
| ![Public property] | [UseFuzzySearch][9] | Gets or sets a value indicating whether search functions will employ fuzzy search. (Inherited from [BaseController][3].) |


Methods
-------

|                  | Name                        | Description                                                                       |
| ---------------- | --------------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [ConfirmRemove][10]         | Processes the contact removal request.                                            |
| ![Public method] | [Create][11]                | Processes the contact creation form submission.                                   |
| ![Public method] | [Edit(ContactForm)][12]     | Processes the contact editing form submission.                                    |
| ![Public method] | [Edit(Int32)][13]           | Gets the edit contact form request.                                               |
| ![Public method] | [Index][14]                 | Gets the index or default request.                                                |
| ![Public method] | [New][15]                   | Gets the new contact creation form request.                                       |
| ![Public method] | [OnActionExecuting][16]     | Called before the action method is invoked. (Inherited from [BaseController][3].) |
| ![Public method] | [Remove][17]                | Gets the contact removal form request.                                            |
| ![Public method] | [Search(String)][18]        | Searches for the [contacts][1] with a matching [name][19] or [email address][20]. |
| ![Public method] | [Search(String, Int32)][21] | Searches for the [contacts][1] with a matching [name][19] or [email address][20]. |


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
[9]: ../BaseController/UseFuzzySearch.md
[10]: ConfirmRemove.md
[11]: Create.md
[12]: Edit.md
[13]: Edit_1.md
[14]: Index.md
[15]: New.md
[16]: ../BaseController/OnActionExecuting.md
[17]: Remove.md
[18]: Search.md
[19]: ../../GrayDuckMail.Common.Database/Contact/Name.md
[20]: ../../GrayDuckMail.Common.Database/Contact/Email.md
[21]: Search_1.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"