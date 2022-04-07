DiscussionListAssignForm Class
==============================
Model for the form input creating or modifying [discussion list assignments][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  [EasyMailDiscussion.Web.Models.Forms.BaseFormInput][3]  
    [EasyMailDiscussion.Web.Models.Forms.BaseFormInput][4]&lt;**DiscussionListAssignForm**>  
      **EasyMailDiscussion.Web.Models.Forms.DiscussionListAssignForm**  

  **Namespace:**  [EasyMailDiscussion.Web.Models.Forms][5]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class DiscussionListAssignForm : BaseFormInput<DiscussionListAssignForm>
```

The **DiscussionListAssignForm** type exposes the following members.


Constructors
------------

|                  | Name                          | Description                                                          |
| ---------------- | ----------------------------- | -------------------------------------------------------------------- |
| ![Public method] | [DiscussionListAssignForm][6] | Initializes a new instance of the **DiscussionListAssignForm** class |


Properties
----------

|                    | Name                  | Description                                                                        |
| ------------------ | --------------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [Assigned][7]         | Gets or sets the assignments connecting [contacts][8] to the [discussion list][9]. |
| ![Public property] | [Assignments][10]     | Gets the assignments connecting [contacts][8] to the [discussion list][9].         |
| ![Public property] | [ContactID][8]        | Gets or sets an array of identifiers of the contacts being assigned or unassigned. |
| ![Public property] | [DiscussionListID][9] | Gets or sets the identifier of the discussion list.                                |


Methods
-------

|                  | Name            | Description                                                                                                                                            |
| ---------------- | --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [IsChecked][11] | Determine if a property of a derived class represents an HTML form value coresponding to a marked checkbox. (Inherited from [BaseFormInput&lt;T>][4].) |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Models.Forms Namespace][5]  

[1]: ../../EasyMailDiscussion.Common.Database/ContactSubscription/README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../BaseFormInput/README.md
[4]: ../BaseFormInput_1/README.md
[5]: ../README.md
[6]: _ctor.md
[7]: Assigned.md
[8]: ContactID.md
[9]: DiscussionListID.md
[10]: Assignments.md
[11]: ../BaseFormInput_1/IsChecked.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"