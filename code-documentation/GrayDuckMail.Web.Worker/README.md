GrayDuckMail.Web.Worker Namespace
=================================
A collection of asyncronous worker threads that power the automated features of Gray Duck Mail.


Classes
-------

|                 | Class             | Description                                                                               |
| --------------- | ----------------- | ----------------------------------------------------------------------------------------- |
| ![Public class] | [EmailFetcher][1] | An asyncronous background service that retrieves email messages and processes them.       |
| ![Public class] | [EmailSender][2]  | An asyncronous background service that sends email queued in theemailQueue.               |
| ![Public class] | [Onboarder][3]    | An asyncronous background service that initiates the onboarding process for new contacts. |

[1]: EmailFetcher/README.md
[2]: EmailSender/README.md
[3]: Onboarder/README.md
[Public class]: ../icons/pubclass.svg "Public class"