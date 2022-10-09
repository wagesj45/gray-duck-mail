EmailSender Class
=================
An asyncronous background service that sends email queued in theemailQueue.


Inheritance Hierarchy
---------------------
[Microsoft.Extensions.Hosting.BackgroundService][1]  
  **GrayDuckMail.Web.Worker.EmailSender**  

  **Namespace:**  [GrayDuckMail.Web.Worker][2]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class EmailSender : BackgroundService
```

The **EmailSender** type exposes the following members.


Constructors
------------

|                                   | Name             | Description                                             |
| --------------------------------- | ---------------- | ------------------------------------------------------- |
| ![Private method]![Static member] | [EmailSender][3] |                                                         |
| ![Public method]                  | [EmailSender][4] | Initializes a new instance of the **EmailSender** class |


Methods
-------

|                     | Name              | Description                                                                                                   |
| ------------------- | ----------------- | ------------------------------------------------------------------------------------------------------------- |
| ![Protected method] | [ExecuteAsync][5] | This method is called when the [IHostedService][6] starts. This is the main processing thread of the service. |


See Also
--------

#### Reference
[GrayDuckMail.Web.Worker Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.backgroundservice
[2]: ../README.md
[3]: _cctor.md
[4]: _ctor.md
[5]: ExecuteAsync.md
[6]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Protected method]: ../../icons/protmethod.svg "Protected method"