ListController.Test Method
==========================
Queues a test message in the form of an Owner Requst notification.

  **Namespace:**  [GrayDuckMail.Web.Controllers][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public IActionResult Test(
	int discussionListID
)
```

#### Parameters

##### *discussionListID*
Type: [System.Int32][2]  
 Identifier for the discussion list.

#### Return Value
Type: [IActionResult][3]  
 A response to return to the caller. 

Remarks
-------
 Fulfills the `/List/Test` request. 

See Also
--------

#### Reference
[ListController Class][4]  
[GrayDuckMail.Web.Controllers Namespace][1]  
[EmailDefinitionType.RequestOwnerNotification][5]  
[EmailHelper.SendRequestOwnerNotificationEmail(DiscussionList, Contact, SmtpClient, CancellationToken)][6]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.iactionresult
[4]: README.md
[5]: ../../GrayDuckMail.Common/EmailDefinitionType/README.md
[6]: ../../GrayDuckMail.Common/EmailHelper/SendRequestOwnerNotificationEmail.md