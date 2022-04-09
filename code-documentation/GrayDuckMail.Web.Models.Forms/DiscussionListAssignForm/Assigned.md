DiscussionListAssignForm.Assigned Property
==========================================
Gets or sets the assignments connecting [contacts][1] to the [discussion list][2].

  **Namespace:**  [GrayDuckMail.Web.Models.Forms][3]  
  **Assembly:** gray-duck-mail-web.exe

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
[GrayDuckMail.Web.Models.Forms Namespace][3]  
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
[6]: ../../GrayDuckMail.Common.Database/Contact/ContactSubscriptions.md
[7]: ../../GrayDuckMail.Common/EmailHelper/ContactAuthorizedStatuses.md
[8]: ../../GrayDuckMail.Common/EmailHelper/ContactUnassignableStatuses.md
[9]: ../../GrayDuckMail.Common/EmailHelper/IsAssignable.md
[10]: ../../GrayDuckMail.Common/EmailHelper/IsAuthorizedForMailDistribution.md