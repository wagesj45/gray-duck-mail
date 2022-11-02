EmailClientWrapper.PerformClientMethod&lt;T> Method (Func&lt;Pop3Client, T>, Func&lt;ImapClient, IMailFolder, T>)
=================================================================================================================
Performs the client method [Func&lt;T, TResult>][1].

  **Namespace:**  [GrayDuckMail.Common][2]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
private T PerformClientMethod<T>(
	Func<Pop3Client, T> pop3Method,
	Func<ImapClient, IMailFolder, T> imapMethod
)

```

#### Parameters

##### *pop3Method*
Type: [System.Func][1]&lt;Pop3Client, **T**>  
 The pop 3 method.

##### *imapMethod*
Type: [System.Func][3]&lt;ImapClient, IMailFolder, **T**>  
 The IMAP method.

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: **T**  
 A T object. 

See Also
--------

#### Reference
[EmailClientWrapper Class][4]  
[GrayDuckMail.Common Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.func-2
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.func-3
[4]: README.md