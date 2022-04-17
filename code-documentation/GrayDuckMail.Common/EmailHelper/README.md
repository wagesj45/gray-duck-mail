EmailHelper Class
=================
A helper class that contains data and methods for manipulating and processing email data.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Common.EmailHelper**  

  **Namespace:**  [GrayDuckMail.Common][2]  
  **Assembly:** gray-duck-mail-common.dll

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

|                                   | Name                                      | Description                                                                                                                                        |
| --------------------------------- | ----------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member]  | [FillDefaultTemplate][14]                 | Fill the default HTML email template with values.                                                                                                  |
| ![Public method]![Static member]  | [GetBouncedMessageRecipient][15]          | Gets bounced message recipient from the message, if it exists.                                                                                     |
| ![Public method]![Static member]  | [GetRelayFooter][16]                      | Gets the message attached as a footer to relayed messages.                                                                                         |
| ![Public method]![Static member]  | [IsAssignable][17]                        | Query if a given user can be assigned to a discussion list.                                                                                        |
| ![Public method]![Static member]  | [IsAuthorizedForMailDistribution][18]     | Query if a given user is authorized for mail distribution on a given discussion list.                                                              |
| ![Public method]![Static member]  | [IsBouncedMessage][19]                    | Query if a messaged is a bounced message by determining if there is an error action code per [GetBouncedMessageRecipient(IndexedMimeMessage)][15]. |
| ![Private method]![Static member] | [ProcessHTMLRelay][20]                    | Process the HTML body of a relayed message.                                                                                                        |
| ![Private method]![Static member] | [ProcessTextRelay][21]                    | Process the text body of a relayed message.                                                                                                        |
| ![Public method]![Static member]  | [RelayEmail][22]                          | Relay an email to the [contacts][7][assigned][8] to a [discussion list][9].                                                                        |
| ![Public method]![Static member]  | [RemoveTextFooter][23]                    | Removes the footer message if present in the given text.                                                                                           |
| ![Public method]![Static member]  | [SendEmail][24]                           | Sends an email.                                                                                                                                    |
| ![Public method]![Static member]  | [SendOnboardingEmail][25]                 | Sends an onboarding email asking a [contact][7] to subscribe to a [discussion list][9].                                                            |
| ![Public method]![Static member]  | [SendRequestOwnerNotificationEmail][26]   | Sends a notification to the [owner][27] that a request to join the mailing list has been issued.                                                   |
| ![Public method]![Static member]  | [SendSubscriptionConfirmationEmail][28]   | Sends a subscription confirmation email to a [contact][7] that has subscribed to a [discussion list][9].                                           |
| ![Public method]![Static member]  | [SendUnsubscriptionConfirmationEmail][29] | Sends a confirmation email to a [contact][7] that has unsubscribed from a [discussion list][9].                                                    |


Fields
------

|                                 | Name                              | Description                                                                  |
| ------------------------------- | --------------------------------- | ---------------------------------------------------------------------------- |
| ![Public field]![Static member] | [FOOTER_FORMAT][30]               | (Immutable) The relay footer message format.                                 |
| ![Public field]![Static member] | [FOOTER_GUID_ID][31]              | (Immutable) A unique identifier for the footer of relayed messages.          |
| ![Public field]![Static member] | [FOOTER_REGEX][32]                | (Immutable) A regex string matching [FOOTER_FORMAT][30].                     |
| ![Public field]![Static member] | [FOOTER_XPATH][33]                | (Immutable) The XPath search value for the footer div element.               |
| ![Public field]![Static member] | [STATUS_GROUP_ACTION_DELAYED][34] | (Immutable) The string denoting the MIME status for a delayed email message. |
| ![Public field]![Static member] | [STATUS_GROUP_ACTION_FAILED][35]  | (Immutable) The string denoting the MIME status for a failed email message.  |


See Also
--------

#### Reference
[GrayDuckMail.Common Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: BouncedEmailStatusGroupActions.md
[5]: ContactAssociatedStatuses.md
[6]: ../../GrayDuckMail.Common.Database/SubscriptionStatus/README.md
[7]: ../../GrayDuckMail.Common.Database/Contact/README.md
[8]: ../../GrayDuckMail.Common.Database/ContactSubscription/README.md
[9]: ../../GrayDuckMail.Common.Database/DiscussionList/README.md
[10]: ContactAuthorizedStatuses.md
[11]: ../../GrayDuckMail.Common.Database/Message/README.md
[12]: ContactUnassignableStatuses.md
[13]: DefaultEmailTemplate.md
[14]: FillDefaultTemplate.md
[15]: GetBouncedMessageRecipient.md
[16]: GetRelayFooter.md
[17]: IsAssignable.md
[18]: IsAuthorizedForMailDistribution.md
[19]: IsBouncedMessage.md
[20]: ProcessHTMLRelay.md
[21]: ProcessTextRelay.md
[22]: RelayEmail.md
[23]: RemoveTextFooter.md
[24]: SendEmail.md
[25]: SendOnboardingEmail.md
[26]: SendRequestOwnerNotificationEmail.md
[27]: ../EmailAliasHelper/GetOwnerAlias.md
[28]: SendSubscriptionConfirmationEmail.md
[29]: SendUnsubscriptionConfirmationEmail.md
[30]: FOOTER_FORMAT.md
[31]: FOOTER_GUID_ID.md
[32]: FOOTER_REGEX.md
[33]: FOOTER_XPATH.md
[34]: STATUS_GROUP_ACTION_DELAYED.md
[35]: STATUS_GROUP_ACTION_FAILED.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public field]: ../../icons/pubfield.svg "Public field"