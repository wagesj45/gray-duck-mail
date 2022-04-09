Onboarder.ExecuteAsync Method
=============================
This method is called when the [IHostedService][1] starts. This is the main processing thread of the service.

  **Namespace:**  [GrayDuckMail.Web.Worker][2]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
protected virtual Task ExecuteAsync(
	CancellationToken stoppingToken
)
```

#### Parameters

##### *stoppingToken*
Type: [System.Threading.CancellationToken][3]  
 Triggered when [StopAsync(CancellationToken)][4] is called.

#### Return Value
Type: [Task][5]  
 A [Task][5] that represents the long running operations. 

See Also
--------

#### Reference
[Onboarder Class][6]  
[GrayDuckMail.Web.Worker Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice.stopasync#microsoft-extensions-hosting-ihostedservice-stopasync(system-threading-cancellationtoken)
[5]: https://docs.microsoft.com/dotnet/api/system.threading.tasks.task
[6]: README.md