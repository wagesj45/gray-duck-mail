LINQExtensions.Page&lt;T> Method (IQueryable&lt;T>, Int32, Int32)
=================================================================
Get a page of items from a collection, skipping *pageNumber* pages of *pageSize* items per page.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static IQueryable<T> Page<T>(
	this IQueryable<T> source,
	int pageNumber,
	int pageSize
)

```

#### Parameters

##### *source*
Type: [System.Linq.IQueryable][2]&lt;**T**>  
 The source to act on.

##### *pageNumber*
Type: [System.Int32][3]  
 The page number to retrieve.

##### *pageSize*
Type: [System.Int32][3]  
 .

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: [IQueryable][2]&lt;**T**>  
 An enumerator that allows foreach to be used to process page in this collection. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IQueryable][2]&lt;**T**>. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

Exceptions
----------

| Exception                        | Condition                                                                    |
| -------------------------------- | ---------------------------------------------------------------------------- |
| [ArgumentOutOfRangeException][6] | Thrown when *pageNumber* is less than `1` or if *pageSize* is less than `1`. |


Remarks
-------
 This method uses natural numbering starting at page 1. 

See Also
--------

#### Reference
[LINQExtensions Class][7]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1
[3]: https://docs.microsoft.com/dotnet/api/system.int32
[4]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[5]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[6]: https://docs.microsoft.com/dotnet/api/system.argumentoutofrangeexception
[7]: README.md