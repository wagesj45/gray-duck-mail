ImportDatabaseForm Class
========================
Model for the form input importing a SQLite database file.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.Forms.BaseFormInput][2]  
    [GrayDuckMail.Web.Models.Forms.BaseFormInput][3]&lt;**ImportDatabaseForm**>  
      **GrayDuckMail.Web.Models.Forms.ImportDatabaseForm**  

  **Namespace:**  [GrayDuckMail.Web.Models.Forms][4]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class ImportDatabaseForm : BaseFormInput<ImportDatabaseForm>
```

The **ImportDatabaseForm** type exposes the following members.


Constructors
------------

|                  | Name                    | Description                                                    |
| ---------------- | ----------------------- | -------------------------------------------------------------- |
| ![Public method] | [ImportDatabaseForm][5] | Initializes a new instance of the **ImportDatabaseForm** class |


Properties
----------

|                    | Name              | Description                     |
| ------------------ | ----------------- | ------------------------------- |
| ![Public property] | [DatabaseFile][6] | Gets or sets the database file. |


Methods
-------

|                  | Name           | Description                                                                                                                                            |
| ---------------- | -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [IsChecked][7] | Determine if a property of a derived class represents an HTML form value coresponding to a marked checkbox. (Inherited from [BaseFormInput&lt;T>][3].) |


See Also
--------

#### Reference
[GrayDuckMail.Web.Models.Forms Namespace][4]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BaseFormInput/README.md
[3]: ../BaseFormInput_1/README.md
[4]: ../README.md
[5]: _ctor.md
[6]: DatabaseFile.md
[7]: ../BaseFormInput_1/IsChecked.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"