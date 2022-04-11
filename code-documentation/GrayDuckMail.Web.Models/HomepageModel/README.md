HomepageModel Class
===================
A data model for the landing page.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.BasePageModel][2]  
    **GrayDuckMail.Web.Models.HomepageModel**  

  **Namespace:**  [GrayDuckMail.Web.Models][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class HomepageModel : BasePageModel
```

The **HomepageModel** type exposes the following members.


Constructors
------------

|                  | Name               | Description                                               |
| ---------------- | ------------------ | --------------------------------------------------------- |
| ![Public method] | [HomepageModel][4] | Initializes a new instance of the **HomepageModel** class |


Properties
----------

|                    | Name                         | Description                                                                        |
| ------------------ | ---------------------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [NumberOfContacts][5]        | Gets or sets the total number of contacts.                                         |
| ![Public property] | [NumberOfDiscussionLists][6] | Gets or sets the total number of discussion lists.                                 |
| ![Public property] | [NumberOfMessages][7]        | Gets or sets the total number of messages.                                         |
| ![Public property] | [Theme][8]                   | Gets or sets the theme used by [Pico.css][9]. (Inherited from [BasePageModel][2].) |


See Also
--------

#### Reference
[GrayDuckMail.Web.Models Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BasePageModel/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: NumberOfContacts.md
[6]: NumberOfDiscussionLists.md
[7]: NumberOfMessages.md
[8]: ../BasePageModel/Theme.md
[9]: https://picocss.com/docs/themes.html
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"