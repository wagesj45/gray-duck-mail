Message Class
=============
A database table that .


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **EasyMailDiscussion.Common.Database.Message**  

  **Namespace:**  [EasyMailDiscussion.Common.Database][2]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public class Message
```

The **Message** type exposes the following members.


Constructors
------------

|                  | Name         | Description                                         |
| ---------------- | ------------ | --------------------------------------------------- |
| ![Public method] | [Message][3] | Initializes a new instance of the **Message** class |


Properties
----------

|                    | Name                      | Description                                                                                                                                   |
| ------------------ | ------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public property] | [BodyHTML][4]             | Gets or sets the HTML code, if present, in the original email as provided by HtmlBody.                                                        |
| ![Public property] | [BodyRaw][5]              | Gets or sets the raw contents of the original email body as provided by Body.                                                                 |
| ![Public property] | [BodyText][6]             | Gets or sets the plain text, if present, in the original email as provided by TextBody.                                                       |
| ![Public property] | [Children][7]             | Gets or sets the messages sent in response to this message, if any exist.                                                                     |
| ![Public property] | [DiscussionList][8]       | Gets or sets the discussion list this **Message** was sent to.                                                                                |
| ![Public property] | [DiscussionListID][9]     | Gets or sets the identifier of the [DiscussionList][8] this message was relayed to.                                                           |
| ![Public property] | [EmailID][10]             | Gets or sets the identifier of the email as provided by MessageId.                                                                            |
| ![Public property] | [ID][11]                  | Gets or sets the identifier.                                                                                                                  |
| ![Public property] | [OriginatorContact][12]   | Gets or sets the [Contact][13] that sent this message to the [DiscussionList][8].                                                             |
| ![Public property] | [OriginatorContactID][14] | Gets or sets the identifier of the [Contact][13] that sent the message to the discussion list.                                                |
| ![Public property] | [Parent][15]              | Gets or sets the message that this message was a response to, if it exists. If this is the first message in a chain, the parent will be null. |
| ![Public property] | [ParentID][16]            | Gets or sets the identifier of the parent message if this message was sent as a reply.                                                        |
| ![Public property] | [Raw][17]                 | Gets or sets the raw MIME text content of the original MimeMessage.                                                                           |
| ![Public property] | [Recieved][18]            | Gets or sets the [date and time][19] the message was recieved and processed by the system.                                                    |
| ![Public property] | [RelayIdentifiers][20]    | Gets or sets a list of identifiers of the [relay identifiers][21].                                                                            |
| ![Public property] | [Subject][22]             | Gets or sets the subject of the original Subject.                                                                                             |


Methods
-------

|                     | Name                  | Description                                                                                                                                                |
| ------------------- | --------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]    | [Equals][23]          | Determines whether the specified object is equal to the current object. (Inherited from [Object][1].)                                                      |
| ![Protected method] | [Finalize][24]        | Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection. (Inherited from [Object][1].) |
| ![Public method]    | [GetHashCode][25]     | Serves as the default hash function. (Inherited from [Object][1].)                                                                                         |
| ![Public method]    | [GetType][26]         | Gets the [Type][27] of the current instance. (Inherited from [Object][1].)                                                                                 |
| ![Protected method] | [MemberwiseClone][28] | Creates a shallow copy of the current [Object][1]. (Inherited from [Object][1].)                                                                           |
| ![Public method]    | [ToString][29]        | Returns a string that represents the current object. (Inherited from [Object][1].)                                                                         |


See Also
--------

#### Reference
[EasyMailDiscussion.Common.Database Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _ctor.md
[4]: BodyHTML.md
[5]: BodyRaw.md
[6]: BodyText.md
[7]: Children.md
[8]: DiscussionList.md
[9]: DiscussionListID.md
[10]: EmailID.md
[11]: ID.md
[12]: OriginatorContact.md
[13]: ../Contact/README.md
[14]: OriginatorContactID.md
[15]: Parent.md
[16]: ParentID.md
[17]: Raw.md
[18]: Recieved.md
[19]: https://docs.microsoft.com/dotnet/api/system.datetime
[20]: RelayIdentifiers.md
[21]: ../RelayIdentifier/README.md
[22]: Subject.md
[23]: https://docs.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object)
[24]: https://docs.microsoft.com/dotnet/api/system.object.finalize#system-object-finalize
[25]: https://docs.microsoft.com/dotnet/api/system.object.gethashcode#system-object-gethashcode
[26]: https://docs.microsoft.com/dotnet/api/system.object.gettype#system-object-gettype
[27]: https://docs.microsoft.com/dotnet/api/system.type
[28]: https://docs.microsoft.com/dotnet/api/system.object.memberwiseclone#system-object-memberwiseclone
[29]: https://docs.microsoft.com/dotnet/api/system.object.tostring#System_Object_ToString
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Protected method]: ../../icons/protmethod.svg "Protected method"