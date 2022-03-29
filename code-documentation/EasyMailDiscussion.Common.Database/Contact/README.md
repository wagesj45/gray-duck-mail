Contact Class
=============
A database table that stores information on individual people that can be assigned to a [DiscussionList][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **EasyMailDiscussion.Common.Database.Contact**  

  **Namespace:**  [EasyMailDiscussion.Common.Database][3]  
  **Assembly:** easy-mail-discussion-common.dll

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


Methods
-------

|                     | Name                  | Description                                                                                                                                                |
| ------------------- | --------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]    | [Equals][11]          | Determines whether the specified object is equal to the current object. (Inherited from [Object][2].)                                                      |
| ![Protected method] | [Finalize][12]        | Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection. (Inherited from [Object][2].) |
| ![Public method]    | [GetHashCode][13]     | Serves as the default hash function. (Inherited from [Object][2].)                                                                                         |
| ![Public method]    | [GetType][14]         | Gets the [Type][15] of the current instance. (Inherited from [Object][2].)                                                                                 |
| ![Protected method] | [MemberwiseClone][16] | Creates a shallow copy of the current [Object][2]. (Inherited from [Object][2].)                                                                           |
| ![Public method]    | [ToString][17]        | Returns a string that represents the current object. (Inherited from [Object][2].)                                                                         |


See Also
--------

#### Reference
[EasyMailDiscussion.Common.Database Namespace][3]  

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
[11]: https://docs.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object)
[12]: https://docs.microsoft.com/dotnet/api/system.object.finalize#system-object-finalize
[13]: https://docs.microsoft.com/dotnet/api/system.object.gethashcode#system-object-gethashcode
[14]: https://docs.microsoft.com/dotnet/api/system.object.gettype#system-object-gettype
[15]: https://docs.microsoft.com/dotnet/api/system.type
[16]: https://docs.microsoft.com/dotnet/api/system.object.memberwiseclone#system-object-memberwiseclone
[17]: https://docs.microsoft.com/dotnet/api/system.object.tostring#System_Object_ToString
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Protected method]: ../../icons/protmethod.svg "Protected method"