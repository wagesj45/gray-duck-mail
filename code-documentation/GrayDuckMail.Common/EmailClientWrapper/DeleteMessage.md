EmailClientWrapper.DeleteMessage Method
=======================================
Marks the specified message for deletion.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public void DeleteMessage(
	int index,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *index*
Type: [System.Int32][2]  
 Zero-based index of the message.

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][3]  
 (Optional) A token that allows processing to be cancelled.


See Also
--------

#### Reference
[EmailClientWrapper Class][4]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: https://docs.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: README.md