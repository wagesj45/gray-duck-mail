EmailHelper.SendRequestOwnerNotificationEmail Method
====================================================
Sends a notification to the [owner][1] that a request to join the mailing list has been issued.

  **Namespace:**  [EasyMailDiscussion.Common][2]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static void SendRequestOwnerNotificationEmail(
	DiscussionList discussionList,
	Contact requester,
	SmtpClient client,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *discussionList*
Type: [EasyMailDiscussion.Common.Database.DiscussionList][3]  
 The discussion list.

##### *requester*
Type: [EasyMailDiscussion.Common.Database.Contact][4]  
 The requester.

##### *client*
Type: SmtpClient  
 The SMTP client.

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][5]  
 (Optional) A token that allows processing to be cancelled.


See Also
--------

#### Reference
[EmailHelper Class][6]  
[EasyMailDiscussion.Common Namespace][2]  

[1]: ../EmailAliasHelper/GetOwnerAlias.md
[2]: ../README.md
[3]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[4]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[5]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: README.md