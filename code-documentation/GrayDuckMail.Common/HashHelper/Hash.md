HashHelper.Hash Method
======================
Hashes a given contact ID, discussion list ID, and a secret token.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static string Hash(
	int contactID,
	int discussionListID,
	string secret
)
```

#### Parameters

##### *contactID*
Type: [System.Int32][2]  
 Identifier for the contact.

##### *discussionListID*
Type: [System.Int32][2]  
 Identifier for the discussion list.

##### *secret*
Type: [System.String][3]  
 The secret token.

#### Return Value
Type: [String][3]  
 A string that represents a SHA256 hash. 

See Also
--------

#### Reference
[HashHelper Class][4]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: README.md