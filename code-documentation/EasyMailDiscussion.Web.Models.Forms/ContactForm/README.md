ContactForm Class
=================
Model for the form input creating or modifying a [Contact][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  [EasyMailDiscussion.Web.Models.Forms.BaseFormInput][3]  
    [EasyMailDiscussion.Web.Models.Forms.BaseFormInput][4]&lt;**ContactForm**>  
      **EasyMailDiscussion.Web.Models.Forms.ContactForm**  

  **Namespace:**  [EasyMailDiscussion.Web.Models.Forms][5]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class ContactForm : BaseFormInput<ContactForm>
```

The **ContactForm** type exposes the following members.


Constructors
------------

|                  | Name             | Description                                             |
| ---------------- | ---------------- | ------------------------------------------------------- |
| ![Public method] | [ContactForm][6] | Initializes a new instance of the **ContactForm** class |


Properties
----------

|                    | Name           | Description                                                                        |
| ------------------ | -------------- | ---------------------------------------------------------------------------------- |
| ![Public property] | [Activated][7] | Gets or sets a value indicating if the contact's email address has been confirmed. |
| ![Public property] | [Email][8]     | Gets or sets the email address of the contact.                                     |
| ![Public property] | [ID][9]        | Gets or sets the identifier.                                                       |
| ![Public property] | [Name][10]     | Gets or sets the name of the contact.                                              |


Methods
-------

|                  | Name            | Description                                                                                                                                            |
| ---------------- | --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [IsChecked][11] | Determine if a property of a derived class represents an HTML form value coresponding to a marked checkbox. (Inherited from [BaseFormInput&lt;T>][4].) |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Models.Forms Namespace][5]  

[1]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../BaseFormInput/README.md
[4]: ../BaseFormInput_1/README.md
[5]: ../README.md
[6]: _ctor.md
[7]: Activated.md
[8]: Email.md
[9]: ID.md
[10]: Name.md
[11]: ../BaseFormInput_1/IsChecked.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"