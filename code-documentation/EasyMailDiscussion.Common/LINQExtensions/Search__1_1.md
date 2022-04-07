LINQExtensions.Search&lt;T> Method (IQueryable&lt;T>, Expression&lt;Func&lt;T, String>>, String)
================================================================================================
Enumerates the items in this collection that contain a given *searchTerm*.

  **Namespace:**  [EasyMailDiscussion.Common][1]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static IQueryable<T> Search<T>(
	this IQueryable<T> source,
	Expression<Func<T, string>> propertySelector,
	string searchTerm
)

```

#### Parameters

##### *source*
Type: [System.Linq.IQueryable][2]&lt;**T**>  
 The source to act on.

##### *propertySelector*
Type: [System.Linq.Expressions.Expression][3]&lt;[Func][4]&lt;**T**, [String][5]>>  
 The property selector.

##### *searchTerm*
Type: [System.String][5]  
 The search term.

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: [IQueryable][2]&lt;**T**>  
 An enumerator that allows foreach to be used to process the matched items. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IQueryable][2]&lt;**T**>. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

Exceptions
----------

| Exception              | Condition                                                             |
| ---------------------- | --------------------------------------------------------------------- |
| [ArgumentException][8] | Thrown when one or more arguments have unsupported or illegal values. |


Remarks
-------
 This method relies heavily on [this article][9] and its code samples. 

See Also
--------

#### Reference
[LINQExtensions Class][10]  
[EasyMailDiscussion.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1
[3]: https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1
[4]: https://docs.microsoft.com/dotnet/api/system.func-2
[5]: https://docs.microsoft.com/dotnet/api/system.string
[6]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[7]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[8]: https://docs.microsoft.com/dotnet/api/system.argumentexception
[9]: https://www.codeproject.com/Articles/30588/ASP-NET-MVC-Flexigrid-sample
[10]: README.md