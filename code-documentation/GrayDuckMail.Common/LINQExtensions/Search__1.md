LINQExtensions.Search&lt;T> Method (IEnumerable&lt;T>, Func&lt;T, String>, String)
==================================================================================
Enumerates the items in this collection that contain a given *searchTerm*.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static IEnumerable<T> Search<T>(
	this IEnumerable<T> source,
	Func<T, string> propertySelector,
	string searchTerm
)

```

#### Parameters

##### *source*
Type: [System.Collections.Generic.IEnumerable][2]&lt;**T**>  
 The source to act on.

##### *propertySelector*
Type: [System.Func][3]&lt;**T**, [String][4]>  
 The property selector.

##### *searchTerm*
Type: [System.String][4]  
 The search term.

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: [IEnumerable][2]&lt;**T**>  
 An enumerator that allows foreach to be used to process the matched items. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IEnumerable][2]&lt;**T**>. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

See Also
--------

#### Reference
[LINQExtensions Class][7]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: https://docs.microsoft.com/dotnet/api/system.func-2
[4]: https://docs.microsoft.com/dotnet/api/system.string
[5]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[6]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[7]: README.md