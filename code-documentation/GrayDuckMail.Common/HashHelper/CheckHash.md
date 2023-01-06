HashHelper.CheckHash Method
===========================
Check a given hash to confirm that it matches the [Hash(Int32, Int32, String)][1] of the given contact ID, discussion list ID, and secret token.

  **Namespace:**  [GrayDuckMail.Common][2]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static bool CheckHash(
	int contactID,
	int discussionListID,
	string secret,
	string hash
)
```

#### Parameters

##### *contactID*
Type: [System.Int32][3]  
 Identifier for the contact.

##### *discussionListID*
Type: [System.Int32][3]  
 Identifier for the discussion list.

##### *secret*
Type: [System.String][4]  
 The secret token.

##### *hash*
Type: [System.String][4]  
 The provided hash.

#### Return Value
Type: [Boolean][5]  
 True if the hashes match, false if they do not match. 

See Also
--------

#### Reference
[HashHelper Class][6]  
[GrayDuckMail.Common Namespace][2]  

[1]: Hash.md
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.int32
[4]: https://docs.microsoft.com/dotnet/api/system.string
[5]: https://docs.microsoft.com/dotnet/api/system.boolean
[6]: README.md