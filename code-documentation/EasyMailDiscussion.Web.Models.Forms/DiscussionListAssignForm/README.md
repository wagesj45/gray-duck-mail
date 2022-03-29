DiscussionListAssignForm Class
==============================
Model for the form input creating or modifying [discussion list assignments][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **EasyMailDiscussion.Web.Models.Forms.DiscussionListAssignForm**  

  **Namespace:**  [EasyMailDiscussion.Web.Models.Forms][3]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class DiscussionListAssignForm
```

The **DiscussionListAssignForm** type exposes the following members.


Constructors
------------

|                  | Name                          | Description                                                          |
| ---------------- | ----------------------------- | -------------------------------------------------------------------- |
| ![Public method] | [DiscussionListAssignForm][4] | Initializes a new instance of the **DiscussionListAssignForm** class |


Properties
----------

|                    | Name                  | Description                                                                        |
| ------------------ | --------------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [Assigned][5]         | Gets or sets the assignments connecting [contacts][6] to the [discussion list][7]. |
| ![Public property] | [Assignments][8]      | Gets the assignments connecting [contacts][6] to the [discussion list][7].         |
| ![Public property] | [ContactID][6]        | Gets or sets an array of identifiers of the contacts being assigned or unassigned. |
| ![Public property] | [DiscussionListID][7] | Gets or sets the identifier of the discussion list.                                |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Models.Forms Namespace][3]  

[1]: ../../EasyMailDiscussion.Common.Database/ContactSubscription/README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../README.md
[4]: _ctor.md
[5]: Assigned.md
[6]: ContactID.md
[7]: DiscussionListID.md
[8]: Assignments.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"