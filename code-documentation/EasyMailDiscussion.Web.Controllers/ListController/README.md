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

|                                   | Name                | Description                                                |
| --------------------------------- | ------------------- | ---------------------------------------------------------- |
| ![Private method]![Static member] | [ListController][4] |                                                            |
| ![Public method]                  | [ListController][5] | Initializes a new instance of the **ListController** class |


Properties
----------

|                    | Name                | Description                                                             |
| ------------------ | ------------------- | ----------------------------------------------------------------------- |
| ![Public property] | [SqliteDatabase][6] | Gets the SQLite database context. (Inherited from [BaseController][2].) |


Methods
-------

|                  | Name                                  | Description                                                                       |
| ---------------- | ------------------------------------- | --------------------------------------------------------------------------------- |
| ![Public method] | [Archive][7]                          |                                                                                   |
| ![Public method] | [Assign(DiscussionListAssignForm)][8] |                                                                                   |
| ![Public method] | [Assign(Int32)][9]                    |                                                                                   |
| ![Public method] | [ConfirmRemove][10]                   |                                                                                   |
| ![Public method] | [Create][11]                          |                                                                                   |
| ![Public method] | [Edit(DiscussionListForm)][12]        |                                                                                   |
| ![Public method] | [Edit(Int32)][13]                     |                                                                                   |
| ![Public method] | [Index][14]                           |                                                                                   |
| ![Public method] | [Message][15]                         |                                                                                   |
| ![Public method] | [New][16]                             |                                                                                   |
| ![Public method] | [OnActionExecuting][17]               | Called before the action method is invoked. (Inherited from [BaseController][2].) |
| ![Public method] | [Remove][18]                          |                                                                                   |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Controllers Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller
[2]: ../BaseController/README.md
[3]: ../README.md
[4]: _cctor.md
[5]: _ctor.md
[6]: ../BaseController/SqliteDatabase.md
[7]: Archive.md
[8]: Assign.md
[9]: Assign_1.md
[10]: ConfirmRemove.md
[11]: Create.md
[12]: Edit.md
[13]: Edit_1.md
[14]: Index.md
[15]: Message.md
[16]: New.md
[17]: ../BaseController/OnActionExecuting.md
[18]: Remove.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"