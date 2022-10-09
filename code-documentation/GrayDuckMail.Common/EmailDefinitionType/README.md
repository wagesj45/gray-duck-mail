EmailDefinitionType Enumeration
===============================
Values that represent the types of email sent by the system.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public enum EmailDefinitionType
```


Members
-------

| Member name                    | Value | Description                                                              |
| ------------------------------ | ----- | ------------------------------------------------------------------------ |
| **Unknown**                    | 0     | The default email type. If this is chosen, an error has likely occurred. |
| **Relay**                      | 1     | A relayed email from a discussion list member.                           |
| **Onboarding**                 | 2     | A message sent to newly added list members.                              |
| **RequestOwnerNotification**   | 3     | A message sent to the owner of the discussion list.                      |
| **SubscriptionConfirmation**   | 4     | Confirms that a new user has been subscribed to the discussion list.     |
| **UbsubscriptionConfirmation** | 5     | Confirmation that a user has been removed from a discussion list.        |


See Also
--------

#### Reference
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md