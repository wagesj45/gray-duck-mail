ContactSubscription Class
=========================
A database table that stores subscription information linking a [Contact][1] to a [DiscussionList][2].


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **EasyMailDiscussion.Common.Database.ContactSubscription**  

  **Namespace:**  [EasyMailDiscussion.Common.Database][4]  
  **Assembly:** easy-mail-discussion-common.dll

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


Methods
-------

|                     | Name                  | Description                                                                                                                                                |
| ------------------- | --------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]    | [Equals][10]          | Determines whether the specified object is equal to the current object. (Inherited from [Object][3].)                                                      |
| ![Protected method] | [Finalize][11]        | Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection. (Inherited from [Object][3].) |
| ![Public method]    | [GetHashCode][12]     | Serves as the default hash function. (Inherited from [Object][3].)                                                                                         |
| ![Public method]    | [GetType][13]         | Gets the [Type][14] of the current instance. (Inherited from [Object][3].)                                                                                 |
| ![Protected method] | [MemberwiseClone][15] | Creates a shallow copy of the current [Object][3]. (Inherited from [Object][3].)                                                                           |
| ![Public method]    | [ToString][16]        | Returns a string that represents the current object. (Inherited from [Object][3].)                                                                         |


See Also
--------

#### Reference
[EasyMailDiscussion.Common.Database Namespace][4]  

[1]: Contact.md
[2]: DiscussionList.md
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: ../README.md
[5]: _ctor.md
[6]: ContactID.md
[7]: DiscussionListID.md
[8]: ID.md
[9]: Status.md
[10]: https://docs.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object)
[11]: https://docs.microsoft.com/dotnet/api/system.object.finalize#system-object-finalize
[12]: https://docs.microsoft.com/dotnet/api/system.object.gethashcode#system-object-gethashcode
[13]: https://docs.microsoft.com/dotnet/api/system.object.gettype#system-object-gettype
[14]: https://docs.microsoft.com/dotnet/api/system.type
[15]: https://docs.microsoft.com/dotnet/api/system.object.memberwiseclone#system-object-memberwiseclone
[16]: https://docs.microsoft.com/dotnet/api/system.object.tostring#System_Object_ToString
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Protected method]: ../../icons/protmethod.svg "Protected method"