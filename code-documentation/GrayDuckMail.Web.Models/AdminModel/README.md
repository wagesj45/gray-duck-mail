AdminModel Class
================
A data model for the administration page.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.BasePageModel][2]  
    **GrayDuckMail.Web.Models.AdminModel**  

  **Namespace:**  [GrayDuckMail.Web.Models][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class AdminModel : BasePageModel
```

The **AdminModel** type exposes the following members.


Constructors
------------

|                  | Name            | Description                                            |
| ---------------- | --------------- | ------------------------------------------------------ |
| ![Public method] | [AdminModel][4] | Initializes a new instance of the **AdminModel** class |


Properties
----------

|                    | Name                | Description                                                                        |
| ------------------ | ------------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [PageSize][5]       | Gets or sets the number of items to display on a page.                             |
| ![Public property] | [Theme][6]          | Gets or sets the theme used by [Pico.css][7]. (Inherited from [BasePageModel][2].) |
| ![Public property] | [UseFuzzySearch][8] | Gets or sets a value indicating whether search functions will employ fuzzy search. |


See Also
--------

#### Reference
[GrayDuckMail.Web.Models Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BasePageModel/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: PageSize.md
[6]: ../BasePageModel/Theme.md
[7]: https://picocss.com/docs/themes.html
[8]: UseFuzzySearch.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"