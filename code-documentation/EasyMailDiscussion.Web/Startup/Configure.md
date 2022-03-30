Startup.Configure Method
========================
This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

  **Namespace:**  [EasyMailDiscussion.Web][1]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public void Configure(
	IApplicationBuilder app,
	IWebHostEnvironment env,
	IHostApplicationLifetime lifetime
)
```

#### Parameters

##### *app*
Type: [Microsoft.AspNetCore.Builder.IApplicationBuilder][2]  
 The application builder interface.

##### *env*
Type: [Microsoft.AspNetCore.Hosting.IWebHostEnvironment][3]  
 The web host environment interface.

##### *lifetime*
Type: [Microsoft.Extensions.Hosting.IHostApplicationLifetime][4]  
 The application lifetime management interface.


See Also
--------

#### Reference
[Startup Class][5]  
[EasyMailDiscussion.Web Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.hosting.iwebhostenvironment
[4]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostapplicationlifetime
[5]: README.md