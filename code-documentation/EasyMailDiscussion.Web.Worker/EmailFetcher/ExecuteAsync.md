EmailFetcher.ExecuteAsync Method
================================
This method is called when the [IHostedService][1] starts. The implementation should return a task that represents the lifetime of the long running operation(s) being performed.

  **Namespace:**  [EasyMailDiscussion.Web.Worker][2]  
  **Assembly:** easy-mail-discussion-web.exe

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
[EmailFetcher Class][6]  
[EasyMailDiscussion.Web.Worker Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice.stopasync#microsoft-extensions-hosting-ihostedservice-stopasync(system-threading-cancellationtoken)
[5]: https://docs.microsoft.com/dotnet/api/system.threading.tasks.task
[6]: README.md