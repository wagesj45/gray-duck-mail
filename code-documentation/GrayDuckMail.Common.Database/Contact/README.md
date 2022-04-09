Contact Class
=============
A database table that stores information on individual people that can be assigned to a [DiscussionList][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GrayDuckMail.Common.Database.Contact**  

  **Namespace:**  [GrayDuckMail.Common.Database][3]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public class Contact
```

The **Contact** type exposes the following members.


Constructors
------------

|                  | Name         | Description                                         |
| ---------------- | ------------ | --------------------------------------------------- |
| ![Public method] | [Contact][4] | Initializes a new instance of the **Contact** class |


Properties
----------

|                    | Name                      | Description                                                                                                                                                         |
| ------------------ | ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public property] | [Activated][5]            | Gets or sets a value indicating whether the contact is activated in the system. Deactivated users can no longer recieve mailings, but remain for archival purposes. |
| ![Public property] | [ContactSubscriptions][6] | Gets or sets the subscriptions to various discussion lists.                                                                                                         |
| ![Public property] | [Email][7]                | Gets or sets the email address of the person.                                                                                                                       |
| ![Public property] | [ID][8]                   | Gets or sets the identifier.                                                                                                                                        |
| ![Public property] | [Messages][9]             | Gets or sets the messages this person has sent to various discussion lists.                                                                                         |
| ![Public property] | [Name][10]                | Gets or sets the name of the person.                                                                                                                                |


See Also
--------

#### Reference
[GrayDuckMail.Common.Database Namespace][3]  

[1]: ../DiscussionList/README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../README.md
[4]: _ctor.md
[5]: Activated.md
[6]: ContactSubscriptions.md
[7]: Email.md
[8]: ID.md
[9]: Messages.md
[10]: Name.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"