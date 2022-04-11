ContactsModel Class
===================
A data model for the contacts page.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.BasePageModel][2]  
    **GrayDuckMail.Web.Models.ContactsModel**  

  **Namespace:**  [GrayDuckMail.Web.Models][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class ContactsModel : BasePageModel
```

The **ContactsModel** type exposes the following members.


Constructors
------------

|                  | Name               | Description                                               |
| ---------------- | ------------------ | --------------------------------------------------------- |
| ![Public method] | [ContactsModel][4] | Initializes a new instance of the **ContactsModel** class |


Properties
----------

|                    | Name            | Description                                                                        |
| ------------------ | --------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [Contacts][5]   | Gets or sets the contacts to display on the page.                                  |
| ![Public property] | [PageNumber][6] | Gets or sets the page number.                                                      |
| ![Public property] | [Theme][7]      | Gets or sets the theme used by [Pico.css][8]. (Inherited from [BasePageModel][2].) |
| ![Public property] | [TotalPages][9] | Gets or sets the total number of pages.                                            |


See Also
--------

#### Reference
[GrayDuckMail.Web.Models Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BasePageModel/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: Contacts.md
[6]: PageNumber.md
[7]: ../BasePageModel/Theme.md
[8]: https://picocss.com/docs/themes.html
[9]: TotalPages.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"