EmailHelper.ConfigureUnsubscribeLink Method
===========================================
Configures an externally accessible unsubscribe link.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static void ConfigureUnsubscribeLink(
	string baseUrl,
	bool secure,
	string hashSecret
)
```

#### Parameters

##### *baseUrl*
Type: [System.String][2]  
 The base URL.

##### *secure*
Type: [System.Boolean][3]  
 True if using HTTPS, false if not.

##### *hashSecret*
Type: [System.String][2]  
 The secret token used for creating a secure unsubscribe link.


See Also
--------

#### Reference
[EmailHelper Class][4]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: https://docs.microsoft.com/dotnet/api/system.boolean
[4]: README.md