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


Constructors
------------

|                                   | Name             | Description |
| --------------------------------- | ---------------- | ----------- |
| ![Private method]![Static member] | [EmailHelper][3] |             |


Properties
----------

|                                    | Name                                | Description                                                                                                                                 |
| ---------------------------------- | ----------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public property]![Static member] | [BouncedEmailStatusGroupActions][4] | Gets the MIME values indicating a bounced email.                                                                                            |
| ![Public property]![Static member] | [ContactAssociatedStatuses][5]      | Gets the [SubscriptionStatus][6] values that indicate that a [Contact][7] is [assigned][8] to a [discussion list][9].                       |
| ![Public property]![Static member] | [ContactAuthorizedStatuses][10]     | Gets the [SubscriptionStatus][6] values that indicate a [Contact][7] is authorized to send [messages][11] through the [discussion list][9]. |
| ![Public property]![Static member] | [ContactUnassignableStatuses][12]   | Gets the [SubscriptionStatus][6] values that indicate that a [Contact][7] cannot be [assigned][8] to a [discussion list][9].                |
| ![Public property]![Static member] | [DefaultEmailTemplate][13]          | Gets the default HTML email template.                                                                                                       |


Methods
-------

|                                  | Name                                      | Description                                                                                                                                        |
| -------------------------------- | ----------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | [FillDefaultTemplate][14]                 | Fill the default HTML email template with values.                                                                                                  |
| ![Public method]![Static member] | [GetBouncedMessageRecipient][15]          | Gets bounced message recipient from the message, if it exists.                                                                                     |
| ![Public method]![Static member] | [IsAssignable][16]                        | Query if a given user can be assigned to a discussion list.                                                                                        |
| ![Public method]![Static member] | [IsAuthorizedForMailDistribution][17]     | Query if a given user is authorized for mail distribution on a given discussion list.                                                              |
| ![Public method]![Static member] | [IsBouncedMessage][18]                    | Query if a messaged is a bounced message by determining if there is an error action code per [GetBouncedMessageRecipient(IndexedMimeMessage)][15]. |
| ![Public method]![Static member] | [RelayEmail][19]                          | Relay an email to the [contacts][7][assigned][8] to a [discussion list][9].                                                                        |
| ![Public method]![Static member] | [SendEmail][20]                           | Sends an email.                                                                                                                                    |
| ![Public method]![Static member] | [SendOnboardingEmail][21]                 | Sends an onboarding email asking a [contact][7] to subscribe to a [discussion list][9].                                                            |
| ![Public method]![Static member] | [SendSubscriptionConfirmationEmail][22]   | Sends a subscription confirmation email to a [contact][7] that has subscribed to a [discussion list][9].                                           |
| ![Public method]![Static member] | [SendUnsubscriptionConfirmationEmail][23] | Sends a confirmation email to a [contact][7] that has unsubscribed from a [discussion list][9].                                                    |


Fields
------

|                                 | Name                              | Description                                                                  |
| ------------------------------- | --------------------------------- | ---------------------------------------------------------------------------- |
| ![Public field]![Static member] | [STATUS_GROUP_ACTION_DELAYED][24] | (Immutable) The string denoting the MIME status for a delayed email message. |
| ![Public field]![Static member] | [STATUS_GROUP_ACTION_FAILED][25]  | (Immutable) The string denoting the MIME status for a failed email message.  |


See Also
--------

#### Reference
[EasyMailDiscussion.Common Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: BouncedEmailStatusGroupActions.md
[5]: ContactAssociatedStatuses.md
[6]: ../../EasyMailDiscussion.Common.Database/SubscriptionStatus/README.md
[7]: ../../EasyMailDiscussion.Common.Database/Contact/README.md
[8]: ../../EasyMailDiscussion.Common.Database/ContactSubscription/README.md
[9]: ../../EasyMailDiscussion.Common.Database/DiscussionList/README.md
[10]: ContactAuthorizedStatuses.md
[11]: ../../EasyMailDiscussion.Common.Database/Message/README.md
[12]: ContactUnassignableStatuses.md
[13]: DefaultEmailTemplate.md
[14]: FillDefaultTemplate.md
[15]: GetBouncedMessageRecipient.md
[16]: IsAssignable.md
[17]: IsAuthorizedForMailDistribution.md
[18]: IsBouncedMessage.md
[19]: RelayEmail.md
[20]: SendEmail.md
[21]: SendOnboardingEmail.md
[22]: SendSubscriptionConfirmationEmail.md
[23]: SendUnsubscriptionConfirmationEmail.md
[24]: STATUS_GROUP_ACTION_DELAYED.md
[25]: STATUS_GROUP_ACTION_FAILED.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public field]: ../../icons/pubfield.svg "Public field"