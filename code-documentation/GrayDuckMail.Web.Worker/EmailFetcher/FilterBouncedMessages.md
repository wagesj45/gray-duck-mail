EmailFetcher.FilterBouncedMessages Method
=========================================
Filters messages based on their delivery status.

  **Namespace:**  [GrayDuckMail.Web.Worker][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
private IEnumerable<IndexedMimeMessage> FilterBouncedMessages(
	IEnumerable<IndexedMimeMessage> messages
)
```

#### Parameters

##### *messages*
Type: [System.Collections.Generic.IEnumerable][2]&lt;[IndexedMimeMessage][3]>  
 The messages.

#### Return Value
Type: [IEnumerable][2]&lt;[IndexedMimeMessage][3]>  
 An enumerator that allows foreach to be used to process filter bounced messages in this collection. 

See Also
--------

#### Reference
[EmailFetcher Class][4]  
[GrayDuckMail.Web.Worker Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: ../../GrayDuckMail.Common/IndexedMimeMessage/README.md
[4]: README.md