DockerEnvironmentVariables Class
================================
A class that defines default values for environment variables passed in from Docker, as well as accessors for those values.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Web.DockerEnvironmentVariables**  

  **Namespace:**  [GrayDuckMail.Web][2]  
  **Assembly:** gray-duck-mail-web.exe

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

|                                    | Name                        | Description                                                                                                                                                                                 |
| ---------------------------------- | --------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public property]![Static member] | [FetchTime][4]              | Gets the time between fetching email from the remote server.                                                                                                                                |
| ![Public property]![Static member] | [LogLevel][5]               | Gets the verbosity level with which to log application events.                                                                                                                              |
| ![Public property]![Static member] | [MinimumSearchScore][6]     | Gets the minimum viable search score.                                                                                                                                                       |
| ![Public property]![Static member] | [RateLimitPerRoundCount][7] | Gets the of queued emails that can be sent in one round.                                                                                                                                    |
| ![Public property]![Static member] | [RateLimitRoundWaitTime][8] | Gets the time between rounds sending email messages.                                                                                                                                        |
| ![Public property]![Static member] | [WebExternalURL][9]         | Gets a URL used when creating an unsubscribe link.                                                                                                                                          |
| ![Public property]![Static member] | [WebOnly][10]               | Gets a value that if set, only the web interface will be initialized. [Background worker threads][11] will not be initialized.                                                              |
| ![Public property]![Static member] | [WebUnsubscribe][12]        | Gets a value indicating whether the an externally accessable unsubscription link is supported. If set to true, messages will replace the unsubscribe link with a link pointing toward [!:]. |
| ![Public property]![Static member] | [WebUseHTTPS][13]           | Gets a value indicating whether the an externally accessable unsubscription link should assume HTTPS transport.                                                                             |


See Also
--------

#### Reference
[GrayDuckMail.Web Namespace][2]  

#### Other Resources
[https://docs.docker.com/compose/environment-variables/][14]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: FetchTime.md
[5]: LogLevel.md
[6]: MinimumSearchScore.md
[7]: RateLimitPerRoundCount.md
[8]: RateLimitRoundWaitTime.md
[9]: WebExternalURL.md
[10]: WebOnly.md
[11]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.backgroundservice
[12]: WebUnsubscribe.md
[13]: WebUseHTTPS.md
[14]: https://docs.docker.com/compose/environment-variables/
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public property]: ../../icons/pubproperty.svg "Public property"