EmailClientWrapper.PerformClientMethod Method (Action&lt;Pop3Client>, Action&lt;ImapClient, IMailFolder>)
=========================================================================================================
Performs the client method [Action][1].

  **Namespace:**  [GrayDuckMail.Common][2]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
private void PerformClientMethod(
	Action<Pop3Client> pop3Method,
	Action<ImapClient, IMailFolder> imapMethod
)
```

#### Parameters

##### *pop3Method*
Type: [System.Action][3]&lt;Pop3Client>  
 The pop 3 method.

##### *imapMethod*
Type: [System.Action][4]&lt;ImapClient, IMailFolder>  
 The IMAP method.


See Also
--------

#### Reference
[EmailClientWrapper Class][5]  
[GrayDuckMail.Common Namespace][2]  
[System.Action][1]  

[1]: https://learn.microsoft.com/dotnet/api/system.action
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.action-1
[4]: https://learn.microsoft.com/dotnet/api/system.action-2
[5]: README.md