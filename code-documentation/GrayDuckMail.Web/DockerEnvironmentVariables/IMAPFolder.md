DockerEnvironmentVariables.IMAPFolder Property
==============================================
Gets the pathname of the IMAP folder used by the [EmailClientWrapper][1] when [EmailProtocol][2] is [IMAP][3].

  **Namespace:**  [GrayDuckMail.Web][4]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public static string IMAPFolder { get; }
```

#### Property Value
Type: [String][5]  
 The pathname of the IMAP folder. 

Remarks
-------
 The default value is `INBOX`. 

See Also
--------

#### Reference
[DockerEnvironmentVariables Class][6]  
[GrayDuckMail.Web Namespace][4]  

[1]: ../../GrayDuckMail.Common/EmailClientWrapper/README.md
[2]: EmailProtocol.md
[3]: ../../GrayDuckMail.Common/EmailProtocol/README.md
[4]: ../README.md
[5]: https://docs.microsoft.com/dotnet/api/system.string
[6]: README.md