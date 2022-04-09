EmailFetcher.FilterMessages Method (IEnumerable&lt;IndexedMimeMessage>, String)
===============================================================================
Filter messages based on the MailboxAddress located in "TO" addresses.

  **Namespace:**  [GrayDuckMail.Web.Worker][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
private IEnumerable<IndexedMimeMessage> FilterMessages(
	IEnumerable<IndexedMimeMessage> messages,
	string emailToAddress
)
```

#### Parameters

##### *messages*
Type: [System.Collections.Generic.IEnumerable][2]&lt;[IndexedMimeMessage][3]>  
 The messages.

##### *emailToAddress*
Type: [System.String][4]  
 The email to address.

#### Return Value
Type: [IEnumerable][2]&lt;[IndexedMimeMessage][3]>  
 An enumerator that allows foreach to be used to process filter messages in this collection. 

See Also
--------

#### Reference
[EmailFetcher Class][5]  
[GrayDuckMail.Web.Worker Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: ../../GrayDuckMail.Common/IndexedMimeMessage/README.md
[4]: https://docs.microsoft.com/dotnet/api/system.string
[5]: README.md