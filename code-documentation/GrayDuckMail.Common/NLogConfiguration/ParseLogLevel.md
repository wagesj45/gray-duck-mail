NLogConfiguration.ParseLogLevel Method
======================================
Parses a string representation of a LogLevel.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
private static LogLevel ParseLogLevel(
	string logLevel
)
```

#### Parameters

##### *logLevel*
Type: [System.String][2]  
 The string representation of log level.

#### Return Value
Type: LogLevel  
 The log level. 

Remarks
-------
 If parsing fails, or an invalid value is given, a default value of Info is returned. 

See Also
--------

#### Reference
[NLogConfiguration Class][3]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: README.md