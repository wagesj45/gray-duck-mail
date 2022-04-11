DiscussionListAssignModel Class
===============================
A data model for the discussion list assignment page.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.BasePageModel][2]  
    **GrayDuckMail.Web.Models.DiscussionListAssignModel**  

  **Namespace:**  [GrayDuckMail.Web.Models][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class DiscussionListAssignModel : BasePageModel
```

The **DiscussionListAssignModel** type exposes the following members.


Constructors
------------

|                  | Name                           | Description                                                           |
| ---------------- | ------------------------------ | --------------------------------------------------------------------- |
| ![Public method] | [DiscussionListAssignModel][4] | Initializes a new instance of the **DiscussionListAssignModel** class |


Properties
----------

|                    | Name                | Description                                                                        |
| ------------------ | ------------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [Contacts][5]       | Gets or sets the contacts to display on the page.                                  |
| ![Public property] | [DiscussionList][6] | Gets or sets a discussion list .                                                   |
| ![Public property] | [Subscriptions][7]  | Gets or sets the subscription statuses to display on the page.                     |
| ![Public property] | [Theme][8]          | Gets or sets the theme used by [Pico.css][9]. (Inherited from [BasePageModel][2].) |


Methods
-------

|                  | Name                  | Description                                                      |
| ---------------- | --------------------- | ---------------------------------------------------------------- |
| ![Public method] | [GetSubscription][10] | Gets a subscription status for a [Contact][11].                  |
| ![Public method] | [HasSubscription][12] | Query if a [Contact][11] has an established subscription status. |


See Also
--------

#### Reference
[GrayDuckMail.Web.Models Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BasePageModel/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: Contacts.md
[6]: DiscussionList.md
[7]: Subscriptions.md
[8]: ../BasePageModel/Theme.md
[9]: https://picocss.com/docs/themes.html
[10]: GetSubscription.md
[11]: ../../GrayDuckMail.Common.Database/Contact/README.md
[12]: HasSubscription.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"