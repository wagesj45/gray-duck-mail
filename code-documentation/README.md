Easy Mail Discussions Code Documentation
========================================
This documentation provides detailed information on the architecture and code powering Gray Duck Mail.


Namespaces
----------

| Namespace                          | Description                                                                                                      |
| ---------------------------------- | ---------------------------------------------------------------------------------------------------------------- |
| [GrayDuckMail.Cli][1]              | A command line interface for interacting with the Gray Duck Mail system.                                         |
| [GrayDuckMail.Common][2]           | A collection of shared classes and structures used across the components that make up the Gray Duck Mail system. |
| [GrayDuckMail.Common.Database][3]  | A collection of objects defining and manipulating the database structure used by the Gray Duck Mail system.      |
| [GrayDuckMail.Web][4]              | The web server and message processing applications that power Gray Duck Mail.                                    |
| [GrayDuckMail.Web.Controllers][5]  | A collection of MVC web controllers that accept and process web requests.                                        |
| [GrayDuckMail.Web.Models][6]       | A collection of MVC model calsses that describe data transactions between MVC controllers and MVC views.         |
| [GrayDuckMail.Web.Models.Forms][7] | A collection of MVC model calsses that represent incoming HTML forms input.                                      |
| [GrayDuckMail.Web.Worker][8]       | A collection of asyncronous worker threads that power the automated features of Gray Duck Mail.                  |

[1]: GrayDuckMail.Cli/README.md
[2]: GrayDuckMail.Common/README.md
[3]: GrayDuckMail.Common.Database/README.md
[4]: GrayDuckMail.Web/README.md
[5]: GrayDuckMail.Web.Controllers/README.md
[6]: GrayDuckMail.Web.Models/README.md
[7]: GrayDuckMail.Web.Models.Forms/README.md
[8]: GrayDuckMail.Web.Worker/README.md