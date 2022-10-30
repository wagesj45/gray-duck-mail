EmailProtocol Enumeration
=========================
Values that represent email protocols for the [EmailClientWrapper][1].

  **Namespace:**  [GrayDuckMail.Common][2]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public enum EmailProtocol
```


Members
-------

| Member name | Value | Description                                                              |
| ----------- | ----- | ------------------------------------------------------------------------ |
| **Unknown** | 0     | The default email type. If this is chosen, an error has likely occurred. |
| **POP3**    | 1     | An email client that connects using the [POP3][3] protocol.              |
| **IMAP**    | 2     | An email client that connects using the [IMAP][4] protocol.              |


See Also
--------

#### Reference
[GrayDuckMail.Common Namespace][2]  
[GrayDuckMail.Common.EmailClientWrapper][1]  

[1]: ../EmailClientWrapper/README.md
[2]: ../README.md
[3]: https://en.wikipedia.org/wiki/Post_Office_Protocol
[4]: https://en.wikipedia.org/wiki/Internet_Message_Access_Protocol