DockerEnvironmentVariables.WebUnsubscribe Property
==================================================
Gets a value indicating whether the an externally accessable unsubscription link is supported. If set to true, messages will replace the unsubscribe link with a link pointing toward [!:].

  **Namespace:**  [GrayDuckMail.Web][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public static bool WebUnsubscribe { get; }
```

#### Property Value
Type: [Boolean][2]  
 True if an externally accessable port is exposed, false otherwise. 

Remarks
-------
 The default value is true

See Also
--------

#### Reference
[DockerEnvironmentVariables Class][3]  
[GrayDuckMail.Web Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.boolean
[3]: README.md