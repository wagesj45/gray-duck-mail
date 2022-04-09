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

|                    | Name                | Description                                                                                                              |
| ------------------ | ------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| ![Public property] | [PageSize][7]       | Gets or sets the number of items to display on a page. (Inherited from [BaseController][3].)                             |
| ![Public property] | [SqliteDatabase][8] | Gets the SQLite database context. (Inherited from [BaseController][3].)                                                  |
| ![Public property] | [UseFuzzySearch][9] | Gets or sets a value indicating whether search functions will employ fuzzy search. (Inherited from [BaseController][3].) |


Methods
-------

|                  | Name                                   | Description                                                                                                        |
| ---------------- | -------------------------------------- | ------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [Archive][10]                          | Gets the message archive request.                                                                                  |
| ![Public method] | [Assign(DiscussionListAssignForm)][11] | Processes the discussion list contact assignment form submission.                                                  |
| ![Public method] | [Assign(Int32)][12]                    | Gets the discussion list contact assignment form request.                                                          |
| ![Public method] | [ConfirmRemove][13]                    | Processes the discussion list removal request.                                                                     |
| ![Public method] | [Create][14]                           | Processes the discussion list creation form submission.                                                            |
| ![Public method] | [Edit(DiscussionListForm)][15]         | Processes the discussion list editing form submission.                                                             |
| ![Public method] | [Edit(Int32)][16]                      | Gets the edit list form request.                                                                                   |
| ![Public method] | [Index][17]                            | Gets the index or default request.                                                                                 |
| ![Public method] | [Message][18]                          | Gets the message request.                                                                                          |
| ![Public method] | [New][19]                              | Gets the new discussion list creation form request.                                                                |
| ![Public method] | [OnActionExecuting][20]                | Called before the action method is invoked. (Inherited from [BaseController][3].)                                  |
| ![Public method] | [Remove][21]                           | Processes the discussion list removal form request.                                                                |
| ![Public method] | [Search(String, Int32)][22]            | Searches for the [messages][18] with a matching [subject][23], [body text][24], [body HTML][25], or [contact][26]. |
| ![Public method] | [Search(Int32, String, Int32)][27]     | Searches for the [messages][18] with a matching [subject][23], [body text][24], [body HTML][25], or [contact][26]. |


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
[9]: ../BaseController/UseFuzzySearch.md
[10]: Archive.md
[11]: Assign.md
[12]: Assign_1.md
[13]: ConfirmRemove.md
[14]: Create.md
[15]: Edit.md
[16]: Edit_1.md
[17]: Index.md
[18]: Message.md
[19]: New.md
[20]: ../BaseController/OnActionExecuting.md
[21]: Remove.md
[22]: Search_1.md
[23]: ../../GrayDuckMail.Common.Database/Message/Subject.md
[24]: ../../GrayDuckMail.Common.Database/Message/BodyText.md
[25]: ../../GrayDuckMail.Common.Database/Message/BodyHTML.md
[26]: ../../GrayDuckMail.Common.Database/Message/OriginatorContact.md
[27]: Search.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"