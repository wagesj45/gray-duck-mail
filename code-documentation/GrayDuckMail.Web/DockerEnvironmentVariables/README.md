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

|                                    | Name                         | Description                                                                                                                                                                                 |
| ---------------------------------- | ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public property]![Static member] | [EmailProtocol][4]           | Gets the email protocol to be used by [EmailClientWrapper][5].                                                                                                                              |
| ![Public property]![Static member] | [FetchTime][6]               | Gets the time between fetching email from the remote server.                                                                                                                                |
| ![Public property]![Static member] | [IMAPFolder][7]              | Gets the pathname of the IMAP folder used by the [EmailClientWrapper][5] when [EmailProtocol][4] is [IMAP][8].                                                                              |
| ![Public property]![Static member] | [LogLevel][9]                | Gets the verbosity level with which to log application events.                                                                                                                              |
| ![Public property]![Static member] | [MinimumSearchScore][10]     | Gets the minimum viable search score.                                                                                                                                                       |
| ![Public property]![Static member] | [RateLimitPerRoundCount][11] | Gets the of queued emails that can be sent in one round.                                                                                                                                    |
| ![Public property]![Static member] | [RateLimitRoundWaitTime][12] | Gets the time between rounds sending email messages.                                                                                                                                        |
| ![Public property]![Static member] | [WebExternalURL][13]         | Gets a URL used when creating an unsubscribe link.                                                                                                                                          |
| ![Public property]![Static member] | [WebOnly][14]                | Gets a value that if set, only the web interface will be initialized. [Background worker threads][15] will not be initialized.                                                              |
| ![Public property]![Static member] | [WebUnsubscribe][16]         | Gets a value indicating whether the an externally accessable unsubscription link is supported. If set to true, messages will replace the unsubscribe link with a link pointing toward [!:]. |
| ![Public property]![Static member] | [WebUseHTTPS][17]            | Gets a value indicating whether the an externally accessable unsubscription link should assume HTTPS transport.                                                                             |


See Also
--------

#### Reference
[GrayDuckMail.Web Namespace][2]  

#### Other Resources
[https://docs.docker.com/compose/environment-variables/][18]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: EmailProtocol.md
[5]: ../../GrayDuckMail.Common/EmailClientWrapper/README.md
[6]: FetchTime.md
[7]: IMAPFolder.md
[8]: ../../GrayDuckMail.Common/EmailProtocol/README.md
[9]: LogLevel.md
[10]: MinimumSearchScore.md
[11]: RateLimitPerRoundCount.md
[12]: RateLimitRoundWaitTime.md
[13]: WebExternalURL.md
[14]: WebOnly.md
[15]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.backgroundservice
[16]: WebUnsubscribe.md
[17]: WebUseHTTPS.md
[18]: https://docs.docker.com/compose/environment-variables/
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public property]: ../../icons/pubproperty.svg "Public property"