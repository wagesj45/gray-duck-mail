RelayIdentifier Class
=====================
A database storing information on the [EmailID][1] of messages that were relayed to members of a [DiscussionList][2].


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **EasyMailDiscussion.Common.Database.RelayIdentifier**  

  **Namespace:**  [EasyMailDiscussion.Common.Database][4]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public class RelayIdentifier
```

The **RelayIdentifier** type exposes the following members.


Constructors
------------

|                  | Name                 | Description                                                 |
| ---------------- | -------------------- | ----------------------------------------------------------- |
| ![Public method] | [RelayIdentifier][5] | Initializes a new instance of the **RelayIdentifier** class |


Properties
----------

|                    | Name              | Description                                                                       |
| ------------------ | ----------------- | --------------------------------------------------------------------------------- |
| ![Public property] | [ID][6]           | Gets or sets the identifier.                                                      |
| ![Public property] | [Message][7]      | Gets or sets the message that was relayed to a [DiscussionList][2].               |
| ![Public property] | [MessageID][8]    | Gets or sets the identifier of the [Message][7] relayed to a [DiscussionList][2]. |
| ![Public property] | [RelayEmailID][9] | Gets or sets the [EmailID][1] of the relay email.                                 |


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

[1]: ../Message/EmailID.md
[2]: ../DiscussionList/README.md
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: ../README.md
[5]: _ctor.md
[6]: ID.md
[7]: Message.md
[8]: MessageID.md
[9]: RelayEmailID.md
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