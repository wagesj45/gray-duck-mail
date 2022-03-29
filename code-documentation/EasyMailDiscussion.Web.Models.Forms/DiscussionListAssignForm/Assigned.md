DiscussionListAssignForm.Assigned Property
==========================================
Gets or sets the assignments connecting [contacts][1] to the [discussion list][2].

  **Namespace:**  [EasyMailDiscussion.Web.Models.Forms][3]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public int[] Assigned { get; set; }
```

#### Property Value
Type: [Int32][4][]  
 The assigned. 

See Also
--------

#### Reference
[DiscussionListAssignForm Class][5]  
[EasyMailDiscussion.Web.Models.Forms Namespace][3]  
[Contact.ContactSubscriptions][6]  
[EmailHelper.ContactAuthorizedStatuses][7]  
[EmailHelper.ContactUnassignableStatuses][8]  
[EmailHelper.IsAssignable(DiscussionList, Contact)][9]  
[EmailHelper.IsAuthorizedForMailDistribution(DiscussionList, Contact)][10]  

[1]: ContactID.md
[2]: DiscussionListID.md
[3]: ../README.md
[4]: https://docs.microsoft.com/dotnet/api/system.int32
[5]: README.md
[6]: ../../EasyMailDiscussion.Common.Database/Contact/ContactSubscriptions.md
[7]: ../../EasyMailDiscussion.Common/EmailHelper/ContactAuthorizedStatuses.md
[8]: ../../EasyMailDiscussion.Common/EmailHelper/ContactUnassignableStatuses.md
[9]: ../../EasyMailDiscussion.Common/EmailHelper/IsAssignable.md
[10]: ../../EasyMailDiscussion.Common/EmailHelper/IsAuthorizedForMailDistribution.md