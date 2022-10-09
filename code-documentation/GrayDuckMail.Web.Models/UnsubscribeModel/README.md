UnsubscribeModel Class
======================
A data model for the external unsubscription page.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.BasePageModel][2]  
    **GrayDuckMail.Web.Models.UnsubscribeModel**  

  **Namespace:**  [GrayDuckMail.Web.Models][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class UnsubscribeModel : BasePageModel
```

The **UnsubscribeModel** type exposes the following members.


Constructors
------------

|                  | Name                  | Description                                                  |
| ---------------- | --------------------- | ------------------------------------------------------------ |
| ![Public method] | [UnsubscribeModel][4] | Initializes a new instance of the **UnsubscribeModel** class |


Properties
----------

|                    | Name                | Description                                                                        |
| ------------------ | ------------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [DiscussionList][5] | Gets or sets the discussion list being unsubscribed from.                          |
| ![Public property] | [Successful][6]     | Gets or sets a value indicating whether the action was successful.                 |
| ![Public property] | [Theme][7]          | Gets or sets the theme used by [Pico.css][8]. (Inherited from [BasePageModel][2].) |
| ![Public property] | [UserEmail][9]      | Gets or sets the email address for which the action was taken.                     |


See Also
--------

#### Reference
[GrayDuckMail.Web.Models Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BasePageModel/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: DiscussionList.md
[6]: Successful.md
[7]: ../BasePageModel/Theme.md
[8]: https://picocss.com/docs/themes.html
[9]: UserEmail.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"