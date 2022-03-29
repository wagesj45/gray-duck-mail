EmailFetcher.FilterMessages Method (IEnumerable&lt;IndexedMimeMessage>, Func&lt;IndexedMimeMessage, Boolean>)
=============================================================================================================
Filter messages based on the a user provided [function][1].

  **Namespace:**  [EasyMailDiscussion.Web.Worker][2]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
private IEnumerable<IndexedMimeMessage> FilterMessages(
	IEnumerable<IndexedMimeMessage> messages,
	Func<IndexedMimeMessage, bool> filter
)
```

#### Parameters

##### *messages*
Type: [System.Collections.Generic.IEnumerable][3]&lt;[IndexedMimeMessage][4]>  
 The messages.

##### *filter*
Type: [System.Func][1]&lt;[IndexedMimeMessage][4], [Boolean][5]>  
 Specifies the filtering function.

#### Return Value
Type: [IEnumerable][3]&lt;[IndexedMimeMessage][4]>  
 An enumerator that allows foreach to be used to process filter messages in this collection. 

See Also
--------

#### Reference
[EmailFetcher Class][6]  
[EasyMailDiscussion.Web.Worker Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.func-2
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: ../../EasyMailDiscussion.Common/IndexedMimeMessage/README.md
[5]: https://docs.microsoft.com/dotnet/api/system.boolean
[6]: README.md