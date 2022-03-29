EmailHelper Class
=================

[Missing &lt;summary> documentation for "T:EasyMailDiscussion.Common.EmailHelper"]



Inheritance Hierarchy
---------------------
[System.Object][1]  
  **EasyMailDiscussion.Common.EmailHelper**  

  **Namespace:**  [EasyMailDiscussion.Common][2]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static class EmailHelper
```

The **EmailHelper** type exposes the following members.


Properties
----------

|                                    | Name                                | Description |
| ---------------------------------- | ----------------------------------- | ----------- |
| ![Public property]![Static member] | [BouncedEmailStatusGroupActions][3] |             |
| ![Public property]![Static member] | [ContactAssociatedStatuses][4]      |             |
| ![Public property]![Static member] | [ContactAuthorizedStatuses][5]      |             |
| ![Public property]![Static member] | [ContactUnassignableStatuses][6]    |             |
| ![Public property]![Static member] | [MailEmailTemplate][7]              |             |


Methods
-------

|                                  | Name                                      | Description |
| -------------------------------- | ----------------------------------------- | ----------- |
| ![Public method]![Static member] | [FillMainTemplate][8]                     |             |
| ![Public method]![Static member] | [GetBouncedMessageRecipient][9]           |             |
| ![Public method]![Static member] | [IsAssignable][10]                        |             |
| ![Public method]![Static member] | [IsAuthorizedForMailDistribution][11]     |             |
| ![Public method]![Static member] | [IsBouncedMessage][12]                    |             |
| ![Public method]![Static member] | [RelayEmail][13]                          |             |
| ![Public method]![Static member] | [SendEmail][14]                           |             |
| ![Public method]![Static member] | [SendOnboardingEmail][15]                 |             |
| ![Public method]![Static member] | [SendSubscriptionConfirmationEmail][16]   |             |
| ![Public method]![Static member] | [SendUnsubscriptionConfirmationEmail][17] |             |


Fields
------

|                                 | Name                              | Description |
| ------------------------------- | --------------------------------- | ----------- |
| ![Public field]![Static member] | [STATUS_GROUP_ACTION_DELAYED][18] |             |
| ![Public field]![Static member] | [STATUS_GROUP_ACTION_FAILED][19]  |             |


See Also
--------

#### Reference
[EasyMailDiscussion.Common Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: BouncedEmailStatusGroupActions.md
[4]: ContactAssociatedStatuses.md
[5]: ContactAuthorizedStatuses.md
[6]: ContactUnassignableStatuses.md
[7]: MailEmailTemplate.md
[8]: FillMainTemplate.md
[9]: GetBouncedMessageRecipient.md
[10]: IsAssignable.md
[11]: IsAuthorizedForMailDistribution.md
[12]: IsBouncedMessage.md
[13]: RelayEmail.md
[14]: SendEmail.md
[15]: SendOnboardingEmail.md
[16]: SendSubscriptionConfirmationEmail.md
[17]: SendUnsubscriptionConfirmationEmail.md
[18]: STATUS_GROUP_ACTION_DELAYED.md
[19]: STATUS_GROUP_ACTION_FAILED.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public field]: ../../icons/pubfield.svg "Public field"