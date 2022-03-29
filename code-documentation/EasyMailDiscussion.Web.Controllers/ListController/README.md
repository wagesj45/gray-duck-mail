ListController Class
====================

[Missing &lt;summary> documentation for "T:EasyMailDiscussion.Web.Controllers.ListController"]



Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Controller][1]  
  [EasyMailDiscussion.Web.Controllers.BaseController][2]  
    **EasyMailDiscussion.Web.Controllers.ListController**  

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][3]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class ListController : BaseController
```

The **ListController** type exposes the following members.


Constructors
------------

|                  | Name                | Description                                                |
| ---------------- | ------------------- | ---------------------------------------------------------- |
| ![Public method] | [ListController][4] | Initializes a new instance of the **ListController** class |


Properties
----------

|                    | Name                | Description                                                             |
| ------------------ | ------------------- | ----------------------------------------------------------------------- |
| ![Public property] | [SqliteDatabase][5] | Gets the SQLite database context. (Inherited from [BaseController][2].) |


Methods
-------

|                  | Name                                  | Description                                                                       |
| ---------------- | ------------------------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [Archive][6]                          |                                                                                   |
| ![Public method] | [Assign(DiscussionListAssignForm)][7] |                                                                                   |
| ![Public method] | [Assign(Int32)][8]                    |                                                                                   |
| ![Public method] | [ConfirmRemove][9]                    |                                                                                   |
| ![Public method] | [Create][10]                          |                                                                                   |
| ![Public method] | [Edit(DiscussionListForm)][11]        |                                                                                   |
| ![Public method] | [Edit(Int32)][12]                     |                                                                                   |
| ![Public method] | [Index][13]                           |                                                                                   |
| ![Public method] | [Message][14]                         |                                                                                   |
| ![Public method] | [New][15]                             |                                                                                   |
| ![Public method] | [OnActionExecuting][16]               | Called before the action method is invoked. (Inherited from [BaseController][2].) |
| ![Public method] | [Remove][17]                          |                                                                                   |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Controllers Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[2]: ../BaseController/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: ../BaseController/SqliteDatabase.md
[6]: Archive.md
[7]: Assign.md
[8]: Assign_1.md
[9]: ConfirmRemove.md
[10]: Create.md
[11]: Edit.md
[12]: Edit_1.md
[13]: Index.md
[14]: Message.md
[15]: New.md
[16]: ../BaseController/OnActionExecuting.md
[17]: Remove.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"