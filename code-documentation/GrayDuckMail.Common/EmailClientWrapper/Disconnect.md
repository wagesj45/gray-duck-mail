EmailClientWrapper.Disconnect Method
====================================
Disconnects the service.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public void Disconnect(
	bool quit,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *quit*
Type: [System.Boolean][2]  
 If true, then a `QUIT` command will be issued in order to disconnect cleanly.

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][3]  
 (Optional) A token that allows processing to be cancelled.


See Also
--------

#### Reference
[EmailClientWrapper Class][4]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.boolean
[3]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: README.md