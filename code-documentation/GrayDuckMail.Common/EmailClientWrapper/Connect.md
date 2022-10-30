EmailClientWrapper.Connect Method
=================================
Establish a connection to the specified mail server.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public void Connect(
	string host,
	int port,
	bool useSSL,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *host*
Type: [System.String][2]  
 The host.

##### *port*
Type: [System.Int32][3]  
 The port.

##### *useSSL*
Type: [System.Boolean][4]  
 True to use ssl.

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][5]  
 (Optional) A token that allows processing to be cancelled.


See Also
--------

#### Reference
[EmailClientWrapper Class][6]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: https://docs.microsoft.com/dotnet/api/system.int32
[4]: https://docs.microsoft.com/dotnet/api/system.boolean
[5]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: README.md