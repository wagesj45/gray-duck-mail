ArchiveModel Class
==================
A data model for the archive page.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.BasePageModel][2]  
    **GrayDuckMail.Web.Models.ArchiveModel**  

  **Namespace:**  [GrayDuckMail.Web.Models][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class ArchiveModel : BasePageModel
```

The **ArchiveModel** type exposes the following members.


Constructors
------------

|                  | Name              | Description                                              |
| ---------------- | ----------------- | -------------------------------------------------------- |
| ![Public method] | [ArchiveModel][4] | Initializes a new instance of the **ArchiveModel** class |


Properties
----------

|                    | Name                | Description                                                                        |
| ------------------ | ------------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [DiscussionList][5] | Gets or sets a discussion list.                                                    |
| ![Public property] | [Messages][6]       | Gets or sets the top level messages to display on the page.                        |
| ![Public property] | [PageNumber][7]     | Gets or sets the selected page number.                                             |
| ![Public property] | [Theme][8]          | Gets or sets the theme used by [Pico.css][9]. (Inherited from [BasePageModel][2].) |
| ![Public property] | [TotalPages][10]    | Gets or sets the total number of pages.                                            |


See Also
--------

#### Reference
[GrayDuckMail.Web.Models Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BasePageModel/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: DiscussionList.md
[6]: Messages.md
[7]: PageNumber.md
[8]: ../BasePageModel/Theme.md
[9]: https://picocss.com/docs/themes.html
[10]: TotalPages.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"