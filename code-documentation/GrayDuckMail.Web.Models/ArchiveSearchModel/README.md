ArchiveSearchModel Class
========================
A data model for the archive page.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.BasePageModel][2]  
    **GrayDuckMail.Web.Models.ArchiveSearchModel**  

  **Namespace:**  [GrayDuckMail.Web.Models][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class ArchiveSearchModel : BasePageModel
```

The **ArchiveSearchModel** type exposes the following members.


Constructors
------------

|                  | Name                    | Description                                                    |
| ---------------- | ----------------------- | -------------------------------------------------------------- |
| ![Public method] | [ArchiveSearchModel][4] | Initializes a new instance of the **ArchiveSearchModel** class |


Properties
----------

|                    | Name                | Description                                                                         |
| ------------------ | ------------------- | ----------------------------------------------------------------------------------- |
| ![Public property] | [DiscussionList][5] | Gets or sets a discussion list.                                                     |
| ![Public property] | [IsFuzzySearch][6]  | Gets or sets a value indicating whether this search was a fuzzy search.             |
| ![Public property] | [Messages][7]       | Gets or sets the messages to display on the page.                                   |
| ![Public property] | [PageNumber][8]     | Gets or sets the selected page number.                                              |
| ![Public property] | [Theme][9]          | Gets or sets the theme used by [Pico.css][10]. (Inherited from [BasePageModel][2].) |
| ![Public property] | [TotalPages][11]    | Gets or sets the total number of pages.                                             |


See Also
--------

#### Reference
[GrayDuckMail.Web.Models Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BasePageModel/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: DiscussionList.md
[6]: IsFuzzySearch.md
[7]: Messages.md
[8]: PageNumber.md
[9]: ../BasePageModel/Theme.md
[10]: https://picocss.com/docs/themes.html
[11]: TotalPages.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"