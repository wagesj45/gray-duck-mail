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


Properties
----------

|                                    | Name           | Description                                                    |
| ---------------------------------- | -------------- | -------------------------------------------------------------- |
| ![Public property]![Static member] | [FetchTime][3] | Gets the time between fetching email from the remote server.   |
| ![Public property]![Static member] | [LogLevel][4]  | Gets the verbosity level with which to log application events. |
| ![Public property]![Static member] | [PageSize][5]  | Gets the page size to use when paginating results.             |


See Also
--------

#### Reference
[EasyMailDiscussion.Web Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: FetchTime.md
[4]: LogLevel.md
[5]: PageSize.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Static member]: ../../icons/static.gif "Static member"