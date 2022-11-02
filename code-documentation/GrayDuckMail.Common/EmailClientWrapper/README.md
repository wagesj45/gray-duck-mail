EmailClientWrapper Class
========================
A wrapper that allows for configurable use of either a MailKitPop3Client or an ImapClient.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Common.EmailClientWrapper**  

  **Namespace:**  [GrayDuckMail.Common][2]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public class EmailClientWrapper : IDisposable
```

The **EmailClientWrapper** type exposes the following members.


Constructors
------------

|                                   | Name                    | Description  |
| --------------------------------- | ----------------------- | ------------ |
| ![Private method]![Static member] | [EmailClientWrapper][3] |              |
| ![Public method]                  | [EmailClientWrapper][4] | Constructor. |


Properties
----------

|                     | Name                 | Description                                               |
| ------------------- | -------------------- | --------------------------------------------------------- |
| ![Public property]  | [EmailClientType][5] | Gets the type of the email client the wrapper represents. |
| ![Private property] | [IMAPClient][6]      | Gets the IMAP client.                                     |
| ![Private property] | [POP3Client][7]      | Gets the POP3 client.                                     |


Methods
-------

|                   | Name                                                                                         | Description                                                                                              |
| ----------------- | -------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| ![Public method]  | [Authenticate][8]                                                                            | Authenticate using the specified SASL method.                                                            |
| ![Public method]  | [Connect][9]                                                                                 | Establish a connection to the specified mail server.                                                     |
| ![Public method]  | [DeleteMessage][10]                                                                          | Marks the specified message for deletion.                                                                |
| ![Public method]  | [Disconnect][11]                                                                             | Disconnects the service.                                                                                 |
| ![Public method]  | [Dispose][12]                                                                                | Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. |
| ![Public method]  | [GetMessages][13]                                                                            | Gets all messages.                                                                                       |
| ![Private method] | [PerformClientMethod(Action&lt;Pop3Client>, Action&lt;ImapClient, IMailFolder>)][14]         | Performs the client method [Action][15].                                                                 |
| ![Private method] | [PerformClientMethod&lt;T>(Func&lt;Pop3Client, T>, Func&lt;ImapClient, IMailFolder, T>)][16] | Performs the client method [Func&lt;T, TResult>][17].                                                    |


See Also
--------

#### Reference
[GrayDuckMail.Common Namespace][2]  
Pop3Client  
ImapClient  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: _ctor.md
[5]: EmailClientType.md
[6]: IMAPClient.md
[7]: POP3Client.md
[8]: Authenticate.md
[9]: Connect.md
[10]: DeleteMessage.md
[11]: Disconnect.md
[12]: Dispose.md
[13]: GetMessages.md
[14]: PerformClientMethod.md
[15]: https://learn.microsoft.com/dotnet/api/system.action
[16]: PerformClientMethod__1.md
[17]: https://docs.microsoft.com/dotnet/api/system.func-2
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Private property]: ../../icons/privproperty.gif "Private property"