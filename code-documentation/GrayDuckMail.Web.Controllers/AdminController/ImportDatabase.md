AdminController.ImportDatabase Method
=====================================
Imports a SQLite database file and replaces the existing database file.

  **Namespace:**  [GrayDuckMail.Web.Controllers][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public IActionResult ImportDatabase(
	ImportDatabaseForm formInput
)
```

#### Parameters

##### *formInput*
Type: [GrayDuckMail.Web.Models.Forms.ImportDatabaseForm][2]  
 The form input.

#### Return Value
Type: [IActionResult][3]  
 A response to return to the caller. 

Exceptions
----------

| Exception            | Condition                                        |
| -------------------- | ------------------------------------------------ |
| [FormatException][4] | Thrown when the format of an input is incorrect. |


Remarks
-------

Fulfills the `/Admin/ImportDatabase` post request.

This method will initiate an application shut down. This is necessary because multiple service worker threads access the database file and we can never be sure that it is not being accessed except at application [start up][5].


See Also
--------

#### Reference
[AdminController Class][6]  
[GrayDuckMail.Web.Controllers Namespace][1]  
[Program.Main(String[])][7]  
[Startup.Startup(IConfiguration)][5]  
[Startup.Configure(IApplicationBuilder, IWebHostEnvironment, IHostApplicationLifetime)][8]  
[Startup.ConfigureServices(IServiceCollection)][9]  

[1]: ../README.md
[2]: ../../GrayDuckMail.Web.Models.Forms/ImportDatabaseForm/README.md
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[4]: https://docs.microsoft.com/dotnet/api/system.formatexception
[5]: ../../GrayDuckMail.Web/Startup/_ctor.md
[6]: README.md
[7]: ../../GrayDuckMail.Web/Program/Main.md
[8]: ../../GrayDuckMail.Web/Startup/Configure.md
[9]: ../../GrayDuckMail.Web/Startup/ConfigureServices.md