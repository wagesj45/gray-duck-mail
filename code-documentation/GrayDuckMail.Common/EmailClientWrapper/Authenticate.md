EmailClientWrapper.Authenticate Method
======================================
Authenticate using the specified SASL method.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public void Authenticate(
	string userName,
	string password,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *userName*
Type: [System.String][2]  
 Name of the user.

##### *password*
Type: [System.String][2]  
 The password.

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][3]  
 (Optional) A token that allows processing to be cancelled.


See Also
--------

#### Reference
[EmailClientWrapper Class][4]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: README.md