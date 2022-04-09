BaseFormInput&lt;T> Class
=========================
A typed base class for shared utilities that provide syntactic sugar when accessing methods in derived classes.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [GrayDuckMail.Web.Models.Forms.BaseFormInput][2]  
    **GrayDuckMail.Web.Models.Forms.BaseFormInput&lt;T>**  
      [GrayDuckMail.Web.Models.Forms.AdminSettingsForm][3]  
      [GrayDuckMail.Web.Models.Forms.ContactForm][4]  
      [GrayDuckMail.Web.Models.Forms.DiscussionListAssignForm][5]  
      [GrayDuckMail.Web.Models.Forms.DiscussionListForm][6]  
      [GrayDuckMail.Web.Models.Forms.ImportDatabaseForm][7]  

  **Namespace:**  [GrayDuckMail.Web.Models.Forms][8]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class BaseFormInput<T> : BaseFormInput
where T : BaseFormInput

```

#### Type Parameters

##### *T*
Generic type parameter.

The **BaseFormInput&lt;T>** type exposes the following members.


Constructors
------------

|                  | Name                     | Description                                                     |
| ---------------- | ------------------------ | --------------------------------------------------------------- |
| ![Public method] | [BaseFormInput&lt;T>][9] | Initializes a new instance of the **BaseFormInput&lt;T>** class |


Methods
-------

|                  | Name            | Description                                                                                                 |
| ---------------- | --------------- | ----------------------------------------------------------------------------------------------------------- |
| ![Public method] | [IsChecked][10] | Determine if a property of a derived class represents an HTML form value coresponding to a marked checkbox. |


Remarks
-------
T must conform to [BaseFormInput][2]. Because a class deriving from **BaseFormInput&lt;T>**, and **BaseFormInput&lt;T>** itself adheres to this convention, casting is available from the [BaseFormInput][2] object to T objects. This makes syntactic sugar possible when creating [Func&lt;T, TResult>][11] parameters accessing the derived type's properties by allowing a cast of `this` to [BaseFormInput][2] to T. 

See Also
--------

#### Reference
[GrayDuckMail.Web.Models.Forms Namespace][8]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../BaseFormInput/README.md
[3]: ../AdminSettingsForm/README.md
[4]: ../ContactForm/README.md
[5]: ../DiscussionListAssignForm/README.md
[6]: ../DiscussionListForm/README.md
[7]: ../ImportDatabaseForm/README.md
[8]: ../README.md
[9]: _ctor.md
[10]: IsChecked.md
[11]: https://docs.microsoft.com/dotnet/api/system.func-2
[Public method]: ../../icons/pubmethod.svg "Public method"