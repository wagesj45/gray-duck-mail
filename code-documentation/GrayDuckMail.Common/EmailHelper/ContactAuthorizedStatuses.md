EmailHelper.ContactAuthorizedStatuses Property
==============================================
Gets the [SubscriptionStatus][1] values that indicate a [Contact][2] is authorized to send [messages][3] through the [discussion list][4].

  **Namespace:**  [GrayDuckMail.Common][5]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static IEnumerable<SubscriptionStatus> ContactAuthorizedStatuses { get; }
```

#### Property Value
Type: [IEnumerable][6]&lt;[SubscriptionStatus][1]>  
 The authorized statuses. 

See Also
--------

#### Reference
[EmailHelper Class][7]  
[GrayDuckMail.Common Namespace][5]  

[1]: ../../GrayDuckMail.Common.Database/SubscriptionStatus/README.md
[2]: ../../GrayDuckMail.Common.Database/Contact/README.md
[3]: ../../GrayDuckMail.Common.Database/Message/README.md
[4]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[5]: ../README.md
[6]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[7]: README.md