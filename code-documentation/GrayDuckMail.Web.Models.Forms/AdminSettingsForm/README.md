AdminSettingsForm Class
=======================
A model for the input governing the web administration settings.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.Forms.BaseFormInput][2]  
    [GrayDuckMail.Web.Models.Forms.BaseFormInput][3]&lt;**AdminSettingsForm**>  
      **GrayDuckMail.Web.Models.Forms.AdminSettingsForm**  

  **Namespace:**  [GrayDuckMail.Web.Models.Forms][4]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class AdminSettingsForm : BaseFormInput<AdminSettingsForm>
```

The **AdminSettingsForm** type exposes the following members.


Constructors
------------

|                  | Name                   | Description                                                   |
| ---------------- | ---------------------- | ------------------------------------------------------------- |
| ![Public method] | [AdminSettingsForm][5] | Initializes a new instance of the **AdminSettingsForm** class |


Properties
----------

|                    | Name                | Description                                                                        |
| ------------------ | ------------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [PageSize][6]       | Gets or sets the number of items to display on a page.                             |
| ![Public property] | [UseFuzzySearch][7] | Gets or sets a value indicating whether search functions will employ fuzzy search. |


Methods
-------

|                  | Name           | Description                                                                                                                                            |
| ---------------- | -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [IsChecked][8] | Determine if a property of a derived class represents an HTML form value coresponding to a marked checkbox. (Inherited from [BaseFormInput&lt;T>][3].) |


See Also
--------

#### Reference
[GrayDuckMail.Web.Models.Forms Namespace][4]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BaseFormInput/README.md
[3]: ../BaseFormInput_1/README.md
[4]: ../README.md
[5]: _ctor.md
[6]: PageSize.md
[7]: UseFuzzySearch.md
[8]: ../BaseFormInput_1/IsChecked.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"