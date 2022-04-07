Tree&lt;T> Constructor
======================
Constructor.

  **Namespace:**  [EasyMailDiscussion.Common][1]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public Tree(
	T value,
	IEnumerable<T> branchValues,
	Func<T, IEnumerable<T>> branchPopulator
)
```

#### Parameters

##### *value*
Type: [T][2]  
 The value.

##### *branchValues*
Type: [System.Collections.Generic.IEnumerable][3]&lt;[T][2]>  
 The branch values.

##### *branchPopulator*
Type: [System.Func][4]&lt;[T][2], [IEnumerable][3]&lt;[T][2]>>  
 The recursive branch populator function.


See Also
--------

#### Reference
[Tree&lt;T> Class][2]  
[EasyMailDiscussion.Common Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: https://docs.microsoft.com/dotnet/api/system.func-2