LINQExtensions.FuzzySearch&lt;T> Method
=======================================
Enumerates the items in this collection that contain a given *searchTerm* or a similar string.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static IEnumerable<SearchResult<T>> FuzzySearch<T>(
	this IEnumerable<T> source,
	string searchTerm,
	params Func<T, string>[] accessors
)

```

#### Parameters

##### *source*
Type: [System.Collections.Generic.IEnumerable][2]&lt;**T**>  
 The source to act on.

##### *searchTerm*
Type: [System.String][3]  
 The search term.

##### *accessors*
Type: [System.Func][4]&lt;**T**, [String][3]>[]  
 The accessors that returns a string to search.

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: [IEnumerable][2]&lt;[SearchResult][5]&lt;**T**>>  
 An enumerator that allows foreach to be used to process the fuzzies in this collection. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IEnumerable][2]&lt;**T**>. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

Remarks
-------
 This method is extremely resource intensive. 

See Also
--------

#### Reference
[LINQExtensions Class][8]  
[GrayDuckMail.Common Namespace][1]  
Levenshtein  
Levenshtein.Distance(String, String)  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: https://docs.microsoft.com/dotnet/api/system.func-2
[5]: ../SearchResult_1/README.md
[6]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[7]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[8]: README.md