EmailFetcher Class
==================

[Missing &lt;summary> documentation for "T:EasyMailDiscussion.Web.Worker.EmailFetcher"]



Inheritance Hierarchy
---------------------
[Microsoft.Extensions.Hosting.BackgroundService][1]  
  **EasyMailDiscussion.Web.Worker.EmailFetcher**  

  **Namespace:**  [EasyMailDiscussion.Web.Worker][2]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class EmailFetcher : BackgroundService
```

The **EmailFetcher** type exposes the following members.


Constructors
------------

|                  | Name              | Description                                              |
| ---------------- | ----------------- | -------------------------------------------------------- |
| ![Public method] | [EmailFetcher][3] | Initializes a new instance of the **EmailFetcher** class |


Methods
-------

|                     | Name              | Description                                                                                                                                                                       |
| ------------------- | ----------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Protected method] | [ExecuteAsync][4] | This method is called when the [IHostedService][5] starts. The implementation should return a task that represents the lifetime of the long running operation(s) being performed. |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Worker Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.backgroundservice
[2]: ../README.md
[3]: _ctor.md
[4]: ExecuteAsync.md
[5]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice
[Public method]: ../../icons/pubmethod.svg "Public method"
[Protected method]: ../../icons/protmethod.svg "Protected method"