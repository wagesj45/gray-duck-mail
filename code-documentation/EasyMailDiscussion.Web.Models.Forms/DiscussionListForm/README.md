DiscussionListForm Class
========================
Model for the form input creating or modifying [DiscussionList][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  [EasyMailDiscussion.Web.Models.Forms.BaseFormInput][3]  
    [EasyMailDiscussion.Web.Models.Forms.BaseFormInput][4]&lt;**DiscussionListForm**>  
      **EasyMailDiscussion.Web.Models.Forms.DiscussionListForm**  

  **Namespace:**  [EasyMailDiscussion.Web.Models.Forms][5]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class DiscussionListForm : BaseFormInput<DiscussionListForm>
```

The **DiscussionListForm** type exposes the following members.


Constructors
------------

|                  | Name                    | Description                                                    |
| ---------------- | ----------------------- | -------------------------------------------------------------- |
| ![Public method] | [DiscussionListForm][6] | Initializes a new instance of the **DiscussionListForm** class |


Properties
----------

|                    | Name                     | Description                                                                                                                                 |
| ------------------ | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public property] | [BaseEmailAddress][7]    | Gets or sets the base email address of the discussion list.                                                                                 |
| ![Public property] | [Description][8]         | Gets or sets the description of the discussion list.                                                                                        |
| ![Public property] | [ID][9]                  | Gets or sets the identifier.                                                                                                                |
| ![Public property] | [IncomingMailPort][10]   | Gets or sets the incoming mail server port.                                                                                                 |
| ![Public property] | [IncomingMailServer][11] | Gets or sets the incoming mail server address.                                                                                              |
| ![Public property] | [Name][12]               | Gets or sets the name of the discussion list.                                                                                               |
| ![Public property] | [OutgoingMailPort][13]   | Gets or sets the outgoing mail server port.                                                                                                 |
| ![Public property] | [OutgoingMailServer][14] | Gets or sets the outgoing mail server address.                                                                                              |
| ![Public property] | [Password][15]           | Gets or sets the password used to connect to the remote mail server.                                                                        |
| ![Public property] | [UserName][16]           | Gets or sets the username used to connect to the remote mail server.                                                                        |
| ![Public property] | [UseSSL][17]             | Gets or sets a value describing if the connection to the [IncomingMailServer][11] and [OutgoingMailServer][14] use an encrypted connection. |


Methods
-------

|                  | Name            | Description                                                                                                                                            |
| ---------------- | --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [IsChecked][18] | Determine if a property of a derived class represents an HTML form value coresponding to a marked checkbox. (Inherited from [BaseFormInput&lt;T>][4].) |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Models.Forms Namespace][5]  

[1]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../BaseFormInput/README.md
[4]: ../BaseFormInput_1/README.md
[5]: ../README.md
[6]: _ctor.md
[7]: BaseEmailAddress.md
[8]: Description.md
[9]: ID.md
[10]: IncomingMailPort.md
[11]: IncomingMailServer.md
[12]: Name.md
[13]: OutgoingMailPort.md
[14]: OutgoingMailServer.md
[15]: Password.md
[16]: UserName.md
[17]: UseSSL.md
[18]: ../BaseFormInput_1/IsChecked.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"