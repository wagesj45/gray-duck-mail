Tree&lt;T> Constructor
======================
Constructor.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public Tree(
	T value,
	Func<T, IEnumerable<T>> branchPopulator
)
```

#### Parameters

##### *value*
Type: [T][2]  
 The value.

##### *branchPopulator*
Type: [System.Func][3]&lt;[T][2], [IEnumerable][4]&lt;[T][2]>>  
 The recursive branch populator function.


See Also
--------

#### Reference
[Tree&lt;T> Class][2]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: https://docs.microsoft.com/dotnet/api/system.func-2
[4]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1