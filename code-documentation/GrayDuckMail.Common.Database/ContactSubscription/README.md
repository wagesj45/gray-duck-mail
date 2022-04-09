ContactSubscription Class
=========================
A database table that stores subscription information linking a [Contact][1] to a [DiscussionList][2].


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **GrayDuckMail.Common.Database.ContactSubscription**  

  **Namespace:**  [GrayDuckMail.Common.Database][4]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public class ContactSubscription
```

The **ContactSubscription** type exposes the following members.


Constructors
------------

|                  | Name                     | Description                                                     |
| ---------------- | ------------------------ | --------------------------------------------------------------- |
| ![Public method] | [ContactSubscription][5] | Initializes a new instance of the **ContactSubscription** class |


Properties
----------

|                    | Name                  | Description                                                                                  |
| ------------------ | --------------------- | -------------------------------------------------------------------------------------------- |
| ![Public property] | [Contact][1]          | Gets or sets the [Contact][1] that the [DiscussionList][2] is assigned to.                   |
| ![Public property] | [ContactID][6]        | Gets or sets the identifier of the [Contact][1] that the [DiscussionList][2] is assigned to. |
| ![Public property] | [DiscussionList][2]   | Gets or sets a [DiscussionList][2] that the [Contact][1] is assigned to.                     |
| ![Public property] | [DiscussionListID][7] | Gets or sets the identifier of the [DiscussionList][2] that the [Contact][1] is assigned to. |
| ![Public property] | [ID][8]               | Gets or sets the identifier.                                                                 |
| ![Public property] | [Status][9]           | Gets or sets the subscription status of the [Contact][1] for the given [DiscussionList][2].  |


See Also
--------

#### Reference
[GrayDuckMail.Common.Database Namespace][4]  

[1]: Contact.md
[2]: DiscussionList.md
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: ../README.md
[5]: _ctor.md
[6]: ContactID.md
[7]: DiscussionListID.md
[8]: ID.md
[9]: Status.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"