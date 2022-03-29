EmailFetcher Class
==================
An asyncronous background service that retrieves email messages and processes them.


Inheritance Hierarchy
---------------------
[Microsoft.Extensions.Hosting.BackgroundService][1]  
  **EasyMailDiscussion.Web.Worker.EmailFetcher**  

  **Namespace:**  [EasyMailDiscussion.Web.Worker][2]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public class EmailFetcher : BackgroundService
```

The **EmailFetcher** type exposes the following members.


Constructors
------------

|                                   | Name              | Description                                              |
| --------------------------------- | ----------------- | -------------------------------------------------------- |
| ![Private method]![Static member] | [EmailFetcher][3] |                                                          |
| ![Public method]                  | [EmailFetcher][4] | Initializes a new instance of the **EmailFetcher** class |


Methods
-------

|                                   | Name                                                                                          | Description                                                                                                   |
| --------------------------------- | --------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| ![Protected method]               | [ExecuteAsync][5]                                                                             | This method is called when the [IHostedService][6] starts. This is the main processing thread of the service. |
| ![Private method]                 | [FilterBouncedMessages][7]                                                                    | Filters messages based on their delivery status.                                                              |
| ![Private method]                 | [FilterMessages(IEnumerable&lt;IndexedMimeMessage>, Func&lt;IndexedMimeMessage, Boolean>)][8] | Filter messages based on the a user provided [function][9].                                                   |
| ![Private method]                 | [FilterMessages(IEnumerable&lt;IndexedMimeMessage>, String)][10]                              | Filter messages based on the MailboxAddress located in "TO" addresses.                                        |
| ![Private method]![Static member] | [ProcessBounces][11]                                                                          | Process the bounced messages recieved from a contact.                                                         |
| ![Private method]![Static member] | [ProcessDiscussionMessages][12]                                                               | Process the non-command messages by relaying them to all subscribed members of the *discussionList*.          |
| ![Private method]![Static member] | [ProcessRequests][13]                                                                         | Process the requests to join a the *discussionList*.                                                          |
| ![Private method]![Static member] | [ProcessSubscriptionConfirmations][14]                                                        | Process the subscription confirmations for the *discussionList*.                                              |
| ![Private method]![Static member] | [ProcessUnsubscribeConfirmations][15]                                                         | Process the unsubscribe confirmations for the *discussionList*.                                               |


See Also
--------

#### Reference
[EasyMailDiscussion.Web.Worker Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.backgroundservice
[2]: ../README.md
[3]: _cctor.md
[4]: _ctor.md
[5]: ExecuteAsync.md
[6]: https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice
[7]: FilterBouncedMessages.md
[8]: FilterMessages.md
[9]: https://docs.microsoft.com/dotnet/api/system.func-2
[10]: FilterMessages_1.md
[11]: ProcessBounces.md
[12]: ProcessDiscussionMessages.md
[13]: ProcessRequests.md
[14]: ProcessSubscriptionConfirmations.md
[15]: ProcessUnsubscribeConfirmations.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Protected method]: ../../icons/protmethod.svg "Protected method"