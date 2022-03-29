DiscussionList Class
====================
A database table that stores information describing an email discussion and distribution list.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **EasyMailDiscussion.Common.Database.DiscussionList**  

  **Namespace:**  [EasyMailDiscussion.Common.Database][2]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public class DiscussionList
```

The **DiscussionList** type exposes the following members.


Constructors
------------

|                  | Name                | Description                                                |
| ---------------- | ------------------- | ---------------------------------------------------------- |
| ![Public method] | [DiscussionList][3] | Initializes a new instance of the **DiscussionList** class |


Properties
----------

|                    | Name                     | Description                                                                                                                                              |
| ------------------ | ------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public property] | [BaseEmailAddress][4]    | Gets or sets the base email address. This is the primary address used by the application to relay messages to other [members of the discussion list][5]. |
| ![Public property] | [Description][6]         | Gets or sets the description of the discussion list and its purpose.                                                                                     |
| ![Public property] | [ID][7]                  | Gets or sets the identifier.                                                                                                                             |
| ![Public property] | [IncomingMailPort][8]    | Gets or sets the port number of incoming mail server.                                                                                                    |
| ![Public property] | [IncomingMailServer][9]  | Gets or sets the web address of the incoming mail server.                                                                                                |
| ![Public property] | [Messages][10]           | Gets or sets the messages that people associated with this list have sent.                                                                               |
| ![Public property] | [Name][11]               | Gets or sets the name of the discussion list.                                                                                                            |
| ![Public property] | [OutgoingMailPort][12]   | Gets or sets the port number of the outgoing SMTP server.                                                                                                |
| ![Public property] | [OutgoingMailServer][13] | Gets or sets the web address of the outgoing SMTP server.                                                                                                |
| ![Public property] | [Password][14]           | Gets or sets the password used when connecting to the remote [IncomingMailServer][9] and the [OutgoingMailServer][13].                                   |
| ![Public property] | [Subscriptions][15]      | Gets or sets the subscriptions to various discussion lists..                                                                                             |
| ![Public property] | [UserName][16]           | Gets or sets the user name used when connecting to the remote [IncomingMailServer][9] and the [OutgoingMailServer][13].                                  |
| ![Public property] | [UseSSL][17]             | Gets or sets a value indicating whether the [IncomingMailServer][9] and [OutgoingMailServer][13] connection connect with SSL encryption.                 |


See Also
--------

#### Reference
[EasyMailDiscussion.Common.Database Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _ctor.md
[4]: BaseEmailAddress.md
[5]: ../Contact/README.md
[6]: Description.md
[7]: ID.md
[8]: IncomingMailPort.md
[9]: IncomingMailServer.md
[10]: Messages.md
[11]: Name.md
[12]: OutgoingMailPort.md
[13]: OutgoingMailServer.md
[14]: Password.md
[15]: Subscriptions.md
[16]: UserName.md
[17]: UseSSL.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"