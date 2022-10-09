ListController Class
====================
Handles web requests for [DiscussionList][1] manipulation operations.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][2]  
  [GrayDuckMail.Web.Controllers.BaseController][3]  
    **GrayDuckMail.Web.Controllers.ListController**  

  **Namespace:**  [GrayDuckMail.Web.Controllers][4]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class ListController : BaseController
```

The **ListController** type exposes the following members.


Constructors
------------

|                                   | Name                | Description  |
| --------------------------------- | ------------------- | ------------ |
| ![Private method]![Static member] | [ListController][5] |              |
| ![Public method]                  | [ListController][6] | Constructor. |


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

|                  | Name                                   | Description                                                                                                        |
| ---------------- | -------------------------------------- | ------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [Archive][12]                          | Gets the message archive request.                                                                                  |
| ![Public method] | [Assign(DiscussionListAssignForm)][13] | Processes the discussion list contact assignment form submission.                                                  |
| ![Public method] | [Assign(Int32)][14]                    | Gets the discussion list contact assignment form request.                                                          |
| ![Public method] | [ConfirmRemove][15]                    | Processes the discussion list removal request.                                                                     |
| ![Public method] | [Create][16]                           | Processes the discussion list creation form submission.                                                            |
| ![Public method] | [Edit(DiscussionListForm)][17]         | Processes the discussion list editing form submission.                                                             |
| ![Public method] | [Edit(Int32)][18]                      | Gets the edit list form request.                                                                                   |
| ![Public method] | [Index][19]                            | Gets the index or default request.                                                                                 |
| ![Public method] | [Message][20]                          | Gets the message request.                                                                                          |
| ![Public method] | [New][21]                              | Gets the new discussion list creation form request.                                                                |
| ![Public method] | [OnActionExecuting][22]                | Called before the action method is invoked. (Inherited from [BaseController][3].)                                  |
| ![Public method] | [Remove][23]                           | Processes the discussion list removal form request.                                                                |
| ![Public method] | [Search(String, Int32)][24]            | Searches for the [messages][20] with a matching [subject][25], [body text][26], [body HTML][27], or [contact][28]. |
| ![Public method] | [Search(Int32, String, Int32)][29]     | Searches for the [messages][20] with a matching [subject][25], [body text][26], [body HTML][27], or [contact][28]. |


See Also
--------

#### Reference
[GrayDuckMail.Web.Controllers Namespace][4]  

[1]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
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
[12]: Archive.md
[13]: Assign.md
[14]: Assign_1.md
[15]: ConfirmRemove.md
[16]: Create.md
[17]: Edit.md
[18]: Edit_1.md
[19]: Index.md
[20]: Message.md
[21]: New.md
[22]: ../BaseController/OnActionExecuting.md
[23]: Remove.md
[24]: Search_1.md
[25]: ../../GrayDuckMail.Common.Database/Message/Subject.md
[26]: ../../GrayDuckMail.Common.Database/Message/BodyText.md
[27]: ../../GrayDuckMail.Common.Database/Message/BodyHTML.md
[28]: ../../GrayDuckMail.Common.Database/Message/OriginatorContact.md
[29]: Search.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"