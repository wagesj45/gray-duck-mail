ListController Class
====================
Handles web requests for [DiscussionList][1] manipulation operations.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][2]  
  [EasyMailDiscussion.Web.Controllers.BaseController][3]  
    **EasyMailDiscussion.Web.Controllers.ListController**  

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][4]  
  **Assembly:** easy-mail-discussion-web.exe

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

|                    | Name                | Description                                                             |
| ------------------ | ------------------- | ----------------------------------------------------------------------- |
| ![Public property] | [SqliteDatabase][7] | Gets the SQLite database context. (Inherited from [BaseController][3].) |


Methods
-------

|                  | Name                                  | Description                                                                       |
| ---------------- | ------------------------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [Archive][8]                          | Gets the message archive request.                                                 |
| ![Public method] | [Assign(DiscussionListAssignForm)][9] | Processes the discussion list contact assignment form submission.                 |
| ![Public method] | [Assign(Int32)][10]                   | Gets the discussion list contact assignment form request.                         |
| ![Public method] | [ConfirmRemove][11]                   | Processes the discussion list removal request.                                    |
| ![Public method] | [Create][12]                          | Processes the discussion list creation form submission.                           |
| ![Public method] | [Edit(DiscussionListForm)][13]        | Processes the discussion list editing form submission.                            |
| ![Public method] | [Edit(Int32)][14]                     | Gets the edit list form request.                                                  |
| ![Public method] | [Index][15]                           | Gets the index or default request.                                                |
| ![Public method] | [Message][16]                         | Gets the message request.                                                         |
| ![Public method] | [New][17]                             | Gets the new discussion list creation form request.                               |
| ![Public method] | [OnActionExecuting][18]               | Called before the action method is invoked. (Inherited from [BaseController][3].) |
| ![Public method] | [Remove][19]                          | Processes the discussion list removal form request.                               |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Controllers Namespace][4]  

[1]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[3]: ../BaseController/README.md
[4]: ../README.md
[5]: _cctor.md
[6]: _ctor.md
[7]: ../BaseController/SqliteDatabase.md
[8]: Archive.md
[9]: Assign.md
[10]: Assign_1.md
[11]: ConfirmRemove.md
[12]: Create.md
[13]: Edit.md
[14]: Edit_1.md
[15]: Index.md
[16]: Message.md
[17]: New.md
[18]: ../BaseController/OnActionExecuting.md
[19]: Remove.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"