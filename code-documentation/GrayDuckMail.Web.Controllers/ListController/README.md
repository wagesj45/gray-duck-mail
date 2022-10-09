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

|                    | Name                         | Description                                                                                                                                |
| ------------------ | ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public property] | [PageSize][7]                | Gets or sets the number of items to display on a page. (Inherited from [BaseController][3].)                                               |
| ![Public property] | [RequestFromExternalPort][8] | Gets or sets a value indicating whether the current request comes from the designated external port. (Inherited from [BaseController][3].) |
| ![Public property] | [SqliteDatabase][9]          | Gets the SQLite database context. (Inherited from [BaseController][3].)                                                                    |
| ![Public property] | [Theme][10]                  | Gets or sets the theme used by [Pico.css][11]. (Inherited from [BaseController][3].)                                                       |
| ![Public property] | [UseFuzzySearch][12]         | Gets or sets a value indicating whether search functions will employ fuzzy search. (Inherited from [BaseController][3].)                   |


Methods
-------

|                  | Name                                   | Description                                                                                                        |
| ---------------- | -------------------------------------- | ------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [Archive][13]                          | Gets the message archive request.                                                                                  |
| ![Public method] | [Assign(DiscussionListAssignForm)][14] | Processes the discussion list contact assignment form submission.                                                  |
| ![Public method] | [Assign(Int32)][15]                    | Gets the discussion list contact assignment form request.                                                          |
| ![Public method] | [ConfirmRemove][16]                    | Processes the discussion list removal request.                                                                     |
| ![Public method] | [Create][17]                           | Processes the discussion list creation form submission.                                                            |
| ![Public method] | [Edit(DiscussionListForm)][18]         | Processes the discussion list editing form submission.                                                             |
| ![Public method] | [Edit(Int32)][19]                      | Gets the edit list form request.                                                                                   |
| ![Public method] | [Index][20]                            | Gets the index or default request.                                                                                 |
| ![Public method] | [Message][21]                          | Gets the message request.                                                                                          |
| ![Public method] | [New][22]                              | Gets the new discussion list creation form request.                                                                |
| ![Public method] | [OnActionExecuting][23]                | Called before the action method is invoked. (Inherited from [BaseController][3].)                                  |
| ![Public method] | [Remove][24]                           | Processes the discussion list removal form request.                                                                |
| ![Public method] | [Search(String, Int32)][25]            | Searches for the [messages][21] with a matching [subject][26], [body text][27], [body HTML][28], or [contact][29]. |
| ![Public method] | [Search(Int32, String, Int32)][30]     | Searches for the [messages][21] with a matching [subject][26], [body text][27], [body HTML][28], or [contact][29]. |
| ![Public method] | [Test][31]                             | Queues a test message in the form of an Owner Requst notification.                                                 |


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
[8]: ../BaseController/RequestFromExternalPort.md
[9]: ../BaseController/SqliteDatabase.md
[10]: ../BaseController/Theme.md
[11]: https://picocss.com/docs/themes.html
[12]: ../BaseController/UseFuzzySearch.md
[13]: Archive.md
[14]: Assign.md
[15]: Assign_1.md
[16]: ConfirmRemove.md
[17]: Create.md
[18]: Edit.md
[19]: Edit_1.md
[20]: Index.md
[21]: Message.md
[22]: New.md
[23]: ../BaseController/OnActionExecuting.md
[24]: Remove.md
[25]: Search_1.md
[26]: ../../GrayDuckMail.Common.Database/Message/Subject.md
[27]: ../../GrayDuckMail.Common.Database/Message/BodyText.md
[28]: ../../GrayDuckMail.Common.Database/Message/BodyHTML.md
[29]: ../../GrayDuckMail.Common.Database/Message/OriginatorContact.md
[30]: Search.md
[31]: Test.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"