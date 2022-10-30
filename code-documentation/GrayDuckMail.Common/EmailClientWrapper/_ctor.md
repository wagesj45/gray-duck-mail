EmailClientWrapper Constructor
==============================
Constructor.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public EmailClientWrapper(
	EmailProtocol emailClientType,
	string imapFolderName = null
)
```

#### Parameters

##### *emailClientType*
Type: [GrayDuckMail.Common.EmailProtocol][2]  
 Type of the email client the wrapper represents.

##### *imapFolderName* (Optional)
Type: [System.String][3]  
 (Optional) Pathname of the IMAP folder if the *emailClientType* is set to [IMAP][2].


See Also
--------

#### Reference
[EmailClientWrapper Class][4]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: ../EmailProtocol/README.md
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: README.md