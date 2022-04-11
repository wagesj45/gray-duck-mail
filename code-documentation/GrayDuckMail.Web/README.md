GrayDuckMail.Web Namespace
==========================
The web server and message processing applications that power Gray Duck Mail.


Classes
-------

|                 | Class                           | Description                                                                                                                 |
| --------------- | ------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| ![Public class] | [ApplicationSettings][1]        | Contains globally accessable application settings ready from appsettings.json.                                              |
| ![Public class] | [DockerEnvironmentVariables][2] | A class that defines default values for environment variables passed in from Docker, as well as accessors for those values. |
| ![Public class] | [Program][3]                    | The root program class for the application.                                                                                 |
| ![Public class] | [Startup][4]                    | Manages the start up routine for the application.                                                                           |
| ![Public class] | [ThemeHelper][5]                | A helper class that contains meta-data and helper methods about [Pico.css theming][6].                                      |

[1]: ApplicationSettings/README.md
[2]: DockerEnvironmentVariables/README.md
[3]: Program/README.md
[4]: Startup/README.md
[5]: ThemeHelper/README.md
[6]: https://picocss.com/docs/themes.html
[Public class]: ../icons/pubclass.svg "Public class"