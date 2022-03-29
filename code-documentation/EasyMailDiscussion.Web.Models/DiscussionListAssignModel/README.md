DiscussionListAssignModel Class
===============================
A data model for the discussion list assignment page.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **EasyMailDiscussion.Web.Models.DiscussionListAssignModel**  

  **Namespace:**  [EasyMailDiscussion.Web.Models][2]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class DiscussionListAssignModel
```

The **DiscussionListAssignModel** type exposes the following members.


Constructors
------------

|                  | Name                           | Description                                                           |
| ---------------- | ------------------------------ | --------------------------------------------------------------------- |
| ![Public method] | [DiscussionListAssignModel][3] | Initializes a new instance of the **DiscussionListAssignModel** class |


Properties
----------

|                    | Name                | Description                                                    |
| ------------------ | ------------------- | -------------------------------------------------------------- |
| ![Public property] | [Contacts][4]       | Gets or sets the contacts to display on the page.              |
| ![Public property] | [DiscussionList][5] | Gets or sets a discussion list .                               |
| ![Public property] | [Subscriptions][6]  | Gets or sets the subscription statuses to display on the page. |


Methods
-------

|                  | Name                 | Description                                                     |
| ---------------- | -------------------- | --------------------------------------------------------------- |
| ![Public method] | [GetSubscription][7] | Gets a subscription status for a [Contact][8].                  |
| ![Public method] | [HasSubscription][9] | Query if a [Contact][8] has an established subscription status. |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Models Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _ctor.md
[4]: Contacts.md
[5]: DiscussionList.md
[6]: Subscriptions.md
[7]: GetSubscription.md
[8]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[9]: HasSubscription.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"