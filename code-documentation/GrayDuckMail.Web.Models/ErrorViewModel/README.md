ErrorViewModel Class
====================
A data model for the error page.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.BasePageModel][2]  
    **GrayDuckMail.Web.Models.ErrorViewModel**  

  **Namespace:**  [GrayDuckMail.Web.Models][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class ErrorViewModel : BasePageModel
```

The **ErrorViewModel** type exposes the following members.


Constructors
------------

|                  | Name                | Description                                                |
| ---------------- | ------------------- | ---------------------------------------------------------- |
| ![Public method] | [ErrorViewModel][4] | Initializes a new instance of the **ErrorViewModel** class |


Properties
----------

|                    | Name               | Description                                                                        |
| ------------------ | ------------------ | ---------------------------------------------------------------------------------- |
| ![Public property] | [RequestId][5]     | Gets or sets the identifier of the request.                                        |
| ![Public property] | [ShowRequestId][6] | Gets a value indicating whether the request identifier is shown.                   |
| ![Public property] | [Theme][7]         | Gets or sets the theme used by [Pico.css][8]. (Inherited from [BasePageModel][2].) |


See Also
--------

#### Reference
[GrayDuckMail.Web.Models Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BasePageModel/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: RequestId.md
[6]: ShowRequestId.md
[7]: ../BasePageModel/Theme.md
[8]: https://picocss.com/docs/themes.html
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"