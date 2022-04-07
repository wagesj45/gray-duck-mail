Tree&lt;T> Constructor
======================
Initializes a new instance of the [Tree&lt;T>][1] class

  **Namespace:**  [EasyMailDiscussion.Common][2]  
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
Type: [T][1]  

[Missing &lt;param name="value"/> documentation for "M:EasyMailDiscussion.Common.Tree`1.#ctor(`0,System.Collections.Generic.IEnumerable{`0},System.Func{`0,System.Collections.Generic.IEnumerable{`0}})"]


##### *branchValues*
Type: [System.Collections.Generic.IEnumerable][3]&lt;[T][1]>  

[Missing &lt;param name="branchValues"/> documentation for "M:EasyMailDiscussion.Common.Tree`1.#ctor(`0,System.Collections.Generic.IEnumerable{`0},System.Func{`0,System.Collections.Generic.IEnumerable{`0}})"]


##### *branchPopulator*
Type: [System.Func][4]&lt;[T][1], [IEnumerable][3]&lt;[T][1]>>  

[Missing &lt;param name="branchPopulator"/> documentation for "M:EasyMailDiscussion.Common.Tree`1.#ctor(`0,System.Collections.Generic.IEnumerable{`0},System.Func{`0,System.Collections.Generic.IEnumerable{`0}})"]



See Also
--------

#### Reference
[Tree&lt;T> Class][1]  
[EasyMailDiscussion.Common Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: https://docs.microsoft.com/dotnet/api/system.func-2