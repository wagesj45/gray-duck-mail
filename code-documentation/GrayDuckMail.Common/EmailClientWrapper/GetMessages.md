EmailClientWrapper.GetMessages Method
=====================================
Gets all messages.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public IList<MimeMessage> GetMessages(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][2]  
 (Optional) A token that allows processing to be cancelled.

#### Return Value
Type: [IList][3]&lt;MimeMessage>  
 The messages. 

See Also
--------

#### Reference
[EmailClientWrapper Class][4]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[3]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1
[4]: README.md