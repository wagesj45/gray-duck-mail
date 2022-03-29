EmailHelper.IsBouncedMessage Method
===================================
Query if a messaged is a bounced message by determining if there is an error action code per [GetBouncedMessageRecipient(IndexedMimeMessage)][1].

  **Namespace:**  [EasyMailDiscussion.Common][2]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static bool IsBouncedMessage(
	IndexedMimeMessage message
)
```

#### Parameters

##### *message*
Type: [EasyMailDiscussion.Common.IndexedMimeMessage][3]  
 The message.

#### Return Value
Type: [Boolean][4]  
 True if the message is bounced, false if not. 

See Also
--------

#### Reference
[EmailHelper Class][5]  
[EasyMailDiscussion.Common Namespace][2]  
[EmailHelper.GetBouncedMessageRecipient(IndexedMimeMessage)][1]  

[1]: GetBouncedMessageRecipient.md
[2]: ../README.md
[3]: ../IndexedMimeMessage/README.md
[4]: https://docs.microsoft.com/dotnet/api/system.boolean
[5]: README.md