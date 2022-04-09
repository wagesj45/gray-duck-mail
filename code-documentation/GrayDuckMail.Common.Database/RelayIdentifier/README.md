RelayIdentifier Class
=====================
A database storing information on the [EmailID][1] of messages that were relayed to members of a [DiscussionList][2].


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **GrayDuckMail.Common.Database.RelayIdentifier**  

  **Namespace:**  [GrayDuckMail.Common.Database][4]  
  **Assembly:** gray-duck-mail-common.dll

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


See Also
--------

#### Reference
[GrayDuckMail.Common.Database Namespace][4]  

[1]: ../Message/EmailID.md
[2]: ../DiscussionList/README.md
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: ../README.md
[5]: _ctor.md
[6]: ID.md
[7]: Message.md
[8]: MessageID.md
[9]: RelayEmailID.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"