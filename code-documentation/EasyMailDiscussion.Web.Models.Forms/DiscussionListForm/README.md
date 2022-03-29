DiscussionListForm Class
========================
Model for the form input creating or modifying [DiscussionList][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **EasyMailDiscussion.Web.Models.Forms.DiscussionListForm**  

  **Namespace:**  [EasyMailDiscussion.Web.Models.Forms][3]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class DiscussionListForm
```

The **DiscussionListForm** type exposes the following members.


Constructors
------------

|                  | Name                    | Description                                                    |
| ---------------- | ----------------------- | -------------------------------------------------------------- |
| ![Public method] | [DiscussionListForm][4] | Initializes a new instance of the **DiscussionListForm** class |


Properties
----------

|                    | Name                     | Description                                                                                                                                |
| ------------------ | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public property] | [BaseEmailAddress][5]    | Gets or sets the base email address of the discussion list.                                                                                |
| ![Public property] | [Description][6]         | Gets or sets the description of the discussion list.                                                                                       |
| ![Public property] | [ID][7]                  | Gets or sets the identifier.                                                                                                               |
| ![Public property] | [IncomingMailPort][8]    | Gets or sets the incoming mail server port.                                                                                                |
| ![Public property] | [IncomingMailServer][9]  | Gets or sets the incoming mail server address.                                                                                             |
| ![Public property] | [Name][10]               | Gets or sets the name of the discussion list.                                                                                              |
| ![Public property] | [OutgoingMailPort][11]   | Gets or sets the outgoing mail server port.                                                                                                |
| ![Public property] | [OutgoingMailServer][12] | Gets or sets the outgoing mail server address.                                                                                             |
| ![Public property] | [Password][13]           | Gets or sets the password used to connect to the remote mail server.                                                                       |
| ![Public property] | [UserName][14]           | Gets or sets the username used to connect to the remote mail server.                                                                       |
| ![Public property] | [UseSSL][15]             | Gets or sets a value describing if the connection to the [IncomingMailServer][9] and [OutgoingMailServer][12] use an encrypted connection. |
| ![Public property] | [UseSSLChecked][16]      | Gets a value describing if the connection to the [IncomingMailServer][9] and [OutgoingMailServer][12] use an encrypted connection.         |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Models.Forms Namespace][3]  

[1]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../README.md
[4]: _ctor.md
[5]: BaseEmailAddress.md
[6]: Description.md
[7]: ID.md
[8]: IncomingMailPort.md
[9]: IncomingMailServer.md
[10]: Name.md
[11]: OutgoingMailPort.md
[12]: OutgoingMailServer.md
[13]: Password.md
[14]: UserName.md
[15]: UseSSL.md
[16]: UseSSLChecked.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"