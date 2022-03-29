EmailHelper Class
=================
A helper class that contains data and methods for manipulating and processing email data.


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

|                                    | Name                                | Description                                                                                                                                 |
| ---------------------------------- | ----------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public property]![Static member] | [BouncedEmailStatusGroupActions][3] | Gets the MIME values indicating a bounced email.                                                                                            |
| ![Public property]![Static member] | [ContactAssociatedStatuses][4]      | Gets the [SubscriptionStatus][5] values that indicate that a [Contact][6] is [assigned][7] to a [discussion list][8].                       |
| ![Public property]![Static member] | [ContactAuthorizedStatuses][9]      | Gets the [SubscriptionStatus][5] values that indicate a [Contact][6] is authorized to send [messages][10] through the [discussion list][8]. |
| ![Public property]![Static member] | [ContactUnassignableStatuses][11]   | Gets the [SubscriptionStatus][5] values that indicate that a [Contact][6] cannot be [assigned][7] to a [discussion list][8].                |
| ![Public property]![Static member] | [DefaultEmailTemplate][12]          | Gets the default HTML email template.                                                                                                       |


Methods
-------

|                                  | Name                                      | Description                                                                                                                                        |
| -------------------------------- | ----------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | [FillDefaultTemplate][13]                 | Fill the default HTML email template with values.                                                                                                  |
| ![Public method]![Static member] | [GetBouncedMessageRecipient][14]          | Gets bounced message recipient from the message, if it exists.                                                                                     |
| ![Public method]![Static member] | [IsAssignable][15]                        | Query if a given user can be assigned to a discussion list.                                                                                        |
| ![Public method]![Static member] | [IsAuthorizedForMailDistribution][16]     | Query if a given user is authorized for mail distribution on a given discussion list.                                                              |
| ![Public method]![Static member] | [IsBouncedMessage][17]                    | Query if a messaged is a bounced message by determining if there is an error action code per [GetBouncedMessageRecipient(IndexedMimeMessage)][14]. |
| ![Public method]![Static member] | [RelayEmail][18]                          | Relay an email to the [contacts][6][assigned][7] to a [discussion list][8].                                                                        |
| ![Public method]![Static member] | [SendEmail][19]                           | Sends an email.                                                                                                                                    |
| ![Public method]![Static member] | [SendOnboardingEmail][20]                 | Sends an onboarding email asking a [contact][6] to subscribe to a [discussion list][8].                                                            |
| ![Public method]![Static member] | [SendSubscriptionConfirmationEmail][21]   | Sends a subscription confirmation email to a [contact][6] that has subscribed to a [discussion list][8].                                           |
| ![Public method]![Static member] | [SendUnsubscriptionConfirmationEmail][22] | Sends a confirmation email to a [contact][6] that has unsubscribed from a [discussion list][8].                                                    |


Fields
------

|                                 | Name                              | Description                                                                  |
| ------------------------------- | --------------------------------- | ---------------------------------------------------------------------------- |
| ![Public field]![Static member] | [STATUS_GROUP_ACTION_DELAYED][23] | (Immutable) The string denoting the MIME status for a delayed email message. |
| ![Public field]![Static member] | [STATUS_GROUP_ACTION_FAILED][24]  | (Immutable) The string denoting the MIME status for a failed email message.  |


See Also
--------

#### Reference
[EasyMailDiscussion.Common Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: BouncedEmailStatusGroupActions.md
[4]: ContactAssociatedStatuses.md
[5]: ../../EasyMailDiscussion.Common.Database/SubscriptionStatus/README.md
[6]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[7]: ../../EasyMailDiscussion.Common.Database/ContactSubscription/README.md
[8]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[9]: ContactAuthorizedStatuses.md
[10]: ../../EasyMailDiscussion.Common.Database/Message/README.md
[11]: ContactUnassignableStatuses.md
[12]: DefaultEmailTemplate.md
[13]: FillDefaultTemplate.md
[14]: GetBouncedMessageRecipient.md
[15]: IsAssignable.md
[16]: IsAuthorizedForMailDistribution.md
[17]: IsBouncedMessage.md
[18]: RelayEmail.md
[19]: SendEmail.md
[20]: SendOnboardingEmail.md
[21]: SendSubscriptionConfirmationEmail.md
[22]: SendUnsubscriptionConfirmationEmail.md
[23]: STATUS_GROUP_ACTION_DELAYED.md
[24]: STATUS_GROUP_ACTION_FAILED.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public field]: ../../icons/pubfield.svg "Public field"