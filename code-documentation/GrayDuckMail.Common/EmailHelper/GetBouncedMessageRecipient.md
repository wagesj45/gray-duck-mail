EmailHelper.GetBouncedMessageRecipient Method
=============================================
Gets bounced message recipient from the message, if it exists.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static string GetBouncedMessageRecipient(
	IndexedMimeMessage message
)
```

#### Parameters

##### *message*
Type: [GrayDuckMail.Common.IndexedMimeMessage][2]  
 The message.

#### Return Value
Type: [String][3]  
 The bounced message recipient. 

Exceptions
----------

| Exception                  | Condition                                            |
| -------------------------- | ---------------------------------------------------- |
| [ArgumentNullException][4] | Thrown when one or more required arguments are null. |


See Also
--------

#### Reference
[EmailHelper Class][5]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: ../IndexedMimeMessage/README.md
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: https://docs.microsoft.com/dotnet/api/system.argumentnullexception
[5]: README.md