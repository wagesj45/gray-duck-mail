Startup.ConfigureNLog Method
============================
Configures NLog for this application.

  **Namespace:**  [GrayDuckMail.Web][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
private static void ConfigureNLog(
	IConfigurationSection sectionDatabase,
	IConfigurationSection sectionLog
)
```

#### Parameters

##### *sectionDatabase*
Type: [Microsoft.Extensions.Configuration.IConfigurationSection][2]  
 The database section of the `appsettings.json` file.

##### *sectionLog*
Type: [Microsoft.Extensions.Configuration.IConfigurationSection][2]  
 The log section of the `appsettings.json` file.


See Also
--------

#### Reference
[Startup Class][3]  
[GrayDuckMail.Web Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.configuration.iconfigurationsection
[3]: README.md