NLogConfiguration Class
=======================
A static class that contains the NLog configuration.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **EasyMailDiscussion.Common.NLogConfiguration**  

  **Namespace:**  [EasyMailDiscussion.Common][2]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static class NLogConfiguration
```

The **NLogConfiguration** type exposes the following members.


Methods
-------

|                                   | Name                  | Description                                                                       |
| --------------------------------- | --------------------- | --------------------------------------------------------------------------------- |
| ![Public method]![Static member]  | [GetConfiguration][3] | Gets the NLog configuration configured to the given *logLevel* and *logFilePath*. |
| ![Private method]![Static member] | [ParseLogLevel][4]    | Parses a string representation of a LogLevel.                                     |


See Also
--------

#### Reference
[EasyMailDiscussion.Common Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: GetConfiguration.md
[4]: ParseLogLevel.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/static.gif "Static member"
[Private method]: ../../icons/privmethod.gif "Private method"