DockerEnvironmentVariables.WebOnly Property
===========================================
Gets a value that if set, only the web interface will be initialized. [Background worker threads][1] will not be initialized.

  **Namespace:**  [GrayDuckMail.Web][2]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public static bool WebOnly { get; }
```

#### Property Value
Type: [Boolean][3]  
 True if only the web interface will be initialized, false if [background service threads][1] will also be initialized. 

Remarks
-------
 The default value is false. 

See Also
--------

#### Reference
[DockerEnvironmentVariables Class][4]  
[GrayDuckMail.Web Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.backgroundservice
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.boolean
[4]: README.md