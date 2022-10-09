GrayDuckMail.Web Namespace
==========================
The web server and message processing applications that power Gray Duck Mail.


Classes
-------

|                 | Class                           | Description                                                                                                                 |
| --------------- | ------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| ![Public class] | [ApplicationSettings][1]        | Contains globally accessable application settings ready from appsettings.json.                                              |
| ![Public class] | [DockerEnvironmentVariables][2] | A class that defines default values for environment variables passed in from Docker, as well as accessors for those values. |
| ![Public class] | [ExternalAccessAttribute][3]    | Attribute for declaring a controller route method as accessable externally.                                                 |
| ![Public class] | [Program][4]                    | The root program class for the application.                                                                                 |
| ![Public class] | [SharedMemory][5]               | An object containing shared memory objects. These collections are meant to be shared between threads.                       |
| ![Public class] | [Startup][6]                    | Manages the start up routine for the application.                                                                           |
| ![Public class] | [ThemeHelper][7]                | A helper class that contains meta-data and helper methods about [Pico.css theming][8].                                      |
| ![Public class] | [ViewLayoutAttribute][9]        | Attribute for specifying a custom view layout.                                                                              |

[1]: ApplicationSettings/README.md
[2]: DockerEnvironmentVariables/README.md
[3]: ExternalAccessAttribute/README.md
[4]: Program/README.md
[5]: SharedMemory/README.md
[6]: Startup/README.md
[7]: ThemeHelper/README.md
[8]: https://picocss.com/docs/themes.html
[9]: ViewLayoutAttribute/README.md
[Public class]: ../icons/pubclass.svg "Public class"