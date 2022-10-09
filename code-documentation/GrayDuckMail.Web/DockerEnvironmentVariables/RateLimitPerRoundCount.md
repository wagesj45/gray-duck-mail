DockerEnvironmentVariables.RateLimitPerRoundCount Property
==========================================================
Gets the of queued emails that can be sent in one round.

  **Namespace:**  [GrayDuckMail.Web][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public static int RateLimitPerRoundCount { get; }
```

#### Property Value
Type: [Int32][2]  
 The number of emails to be sent per round. 

Remarks
-------
 The default value is `20`. 

See Also
--------

#### Reference
[DockerEnvironmentVariables Class][3]  
[GrayDuckMail.Web Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: README.md