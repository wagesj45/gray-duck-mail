NLogConfiguration.GetConfiguration Method
=========================================
Gets the NLog configuration configured to the given *logLevel* and *logFilePath*.

  **Namespace:**  [EasyMailDiscussion.Common][1]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static LoggingConfiguration GetConfiguration(
	string logLevel,
	string logFilePath
)
```

#### Parameters

##### *logLevel*
Type: [System.String][2]  
 The log level.

##### *logFilePath*
Type: [System.String][2]  
 Full pathname of the log file.

#### Return Value
Type: LoggingConfiguration  
 The NLog configuration. 

See Also
--------

#### Reference
[NLogConfiguration Class][3]  
[EasyMailDiscussion.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: README.md