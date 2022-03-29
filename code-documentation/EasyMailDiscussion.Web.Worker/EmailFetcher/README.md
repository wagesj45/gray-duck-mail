EmailFetcher Class
==================

[Missing &lt;summary> documentation for "T:EasyMailDiscussion.Web.Worker.EmailFetcher"]



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

|                                   | Name                                                                                          | Description                                                                                                                                                                       |
| --------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Protected method]               | [ExecuteAsync][5]                                                                             | This method is called when the [IHostedService][6] starts. The implementation should return a task that represents the lifetime of the long running operation(s) being performed. |
| ![Private method]                 | [FilterBouncedMessages][7]                                                                    |                                                                                                                                                                                   |
| ![Private method]                 | [FilterMessages(IEnumerable&lt;IndexedMimeMessage>, Func&lt;IndexedMimeMessage, Boolean>)][8] |                                                                                                                                                                                   |
| ![Private method]                 | [FilterMessages(IEnumerable&lt;IndexedMimeMessage>, String)][9]                               | Filter messages based on the MailboxAddress located in "TO" addresses.                                                                                                            |
| ![Private method]![Static member] | [ProcessBounces][10]                                                                          | Process the bounced messages recieved from a contact.                                                                                                                             |
| ![Private method]![Static member] | [ProcessDiscussionMessages][11]                                                               | Process the non-command messages by relaying them to all subscribed members of the *discussionList*.                                                                              |
| ![Private method]![Static member] | [ProcessRequests][12]                                                                         | Process the requests to join a the *discussionList*.                                                                                                                              |
| ![Private method]![Static member] | [ProcessSubscriptionConfirmations][13]                                                        | Process the subscription confirmations for the *discussionList*.                                                                                                                  |
| ![Private method]![Static member] | [ProcessUnsubscribeConfirmations][14]                                                         | Process the unsubscribe confirmations for the *discussionList*.                                                                                                                   |


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
[9]: FilterMessages_1.md
[10]: ProcessBounces.md
[11]: ProcessDiscussionMessages.md
[12]: ProcessRequests.md
[13]: ProcessSubscriptionConfirmations.md
[14]: ProcessUnsubscribeConfirmations.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Protected method]: ../../icons/protmethod.svg "Protected method"