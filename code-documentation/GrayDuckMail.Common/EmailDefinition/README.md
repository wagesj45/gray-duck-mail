EmailDefinition Class
=====================
Defines an email to be sent.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Common.EmailDefinition**  

  **Namespace:**  [GrayDuckMail.Common][2]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public class EmailDefinition
```

The **EmailDefinition** type exposes the following members.


Constructors
------------

|                  | Name                 | Description                                                 |
| ---------------- | -------------------- | ----------------------------------------------------------- |
| ![Public method] | [EmailDefinition][3] | Initializes a new instance of the **EmailDefinition** class |


Properties
----------

|                    | Name                | Description                     |
| ------------------ | ------------------- | ------------------------------- |
| ![Public property] | [Body][4]           |                                 |
| ![Public property] | [Contact][5]        |                                 |
| ![Public property] | [DiscussionList][6] |                                 |
| ![Public property] | [Message][7]        |                                 |
| ![Public property] | [Subject][8]        |                                 |
| ![Public property] | [Type][9]           | Gets or sets the type of email. |


Methods
-------

|                                  | Name                                   | Description                                                  |
| -------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| ![Public method]![Static member] | [CreateOnboarding][10]                 | Creates an onboarding message definition.                    |
| ![Public method]![Static member] | [CreateOwnerNotification][11]          | Creates a notification to the owner of the *discussionList*. |
| ![Public method]![Static member] | [CreateRelay][12]                      | Creates a relayed message definition.                        |
| ![Public method]![Static member] | [CreateSubscriptionConfirmation][13]   | Creates a subscription confirmation definition.              |
| ![Public method]![Static member] | [CreateUnsubscriptionConfirmation][14] | Creates an unsubscription confirmation definition.           |


See Also
--------

#### Reference
[GrayDuckMail.Common Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _ctor.md
[4]: Body.md
[5]: Contact.md
[6]: DiscussionList.md
[7]: Message.md
[8]: Subject.md
[9]: Type.md
[10]: CreateOnboarding.md
[11]: CreateOwnerNotification.md
[12]: CreateRelay.md
[13]: CreateSubscriptionConfirmation.md
[14]: CreateUnsubscriptionConfirmation.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Static member]: ../../icons/static.gif "Static member"