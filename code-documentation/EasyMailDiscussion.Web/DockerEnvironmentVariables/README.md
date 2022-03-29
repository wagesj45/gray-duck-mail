DockerEnvironmentVariables Class
================================
A class that defines default values for environment variables passed in from Docker, as well as accessors for those values.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **EasyMailDiscussion.Web.DockerEnvironmentVariables**  

  **Namespace:**  [EasyMailDiscussion.Web][2]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public static class DockerEnvironmentVariables
```

The **DockerEnvironmentVariables** type exposes the following members.


Constructors
------------

|                                   | Name                            | Description |
| --------------------------------- | ------------------------------- | ----------- |
| ![Private method]![Static member] | [DockerEnvironmentVariables][3] |             |


Properties
----------

|                                    | Name           | Description                                                    |
| ---------------------------------- | -------------- | -------------------------------------------------------------- |
| ![Public property]![Static member] | [FetchTime][4] | Gets the time between fetching email from the remote server.   |
| ![Public property]![Static member] | [LogLevel][5]  | Gets the verbosity level with which to log application events. |
| ![Public property]![Static member] | [PageSize][6]  | Gets the page size to use when paginating results.             |


See Also
--------

#### Reference
[EasyMailDiscussion.Web Namespace][2]  

#### Other Resources
[https://docs.docker.com/compose/environment-variables/][7]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: FetchTime.md
[5]: LogLevel.md
[6]: PageSize.md
[7]: https://docs.docker.com/compose/environment-variables/
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public property]: ../../icons/pubproperty.svg "Public property"