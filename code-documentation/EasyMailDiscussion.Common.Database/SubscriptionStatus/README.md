SubscriptionStatus Enumeration
==============================
Values that represent subscription status of a contact in a discussion list.

  **Namespace:**  [EasyMailDiscussion.Common.Database][1]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public enum SubscriptionStatus
```


Members
-------

| Member name              | Value | Description                                                                                  |
| ------------------------ | ----- | -------------------------------------------------------------------------------------------- |
| **Unknown**              | 0     | No assignment can be determined.                                                             |
| **Created**              | 1     | The contact has been assigned to a list, but has not yet been sent a confirmation message.   |
| **AwaitingConfirmation** | 2     | The contact has been added to the discussion list, but has not confirmed their subscription. |
| **Subscribed**           | 3     | The contact has confirmed their subscription to the discussion list.                         |
| **Unsubscribed**         | 4     | The contact has requested to be unsubscripted from the discussion list.                      |
| **Requested**            | 5     | The contact has requested access to a discussion list.                                       |
| **Denied**               | 6     | The contact has been denied access to the discussion list by the owner.                      |
| **Bounced**              | 7     | The contact's email address bounced for this discussion list.                                |


Remarks
-------
 These 

See Also
--------

#### Reference
[EasyMailDiscussion.Common.Database Namespace][1]  

[1]: ../README.md