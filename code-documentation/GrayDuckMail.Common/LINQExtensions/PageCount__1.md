LINQExtensions.PageCount&lt;T> Method (IEnumerable&lt;T>, Int32)
================================================================
The number of pages of *pageSize* size in the given collection.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static int PageCount<T>(
	this IEnumerable<T> source,
	int pageSize
)

```

#### Parameters

##### *source*
Type: [System.Collections.Generic.IEnumerable][2]&lt;**T**>  
 The source to act on.

##### *pageSize*
Type: [System.Int32][3]  
 Size of the page.

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: [Int32][3]  
 An int. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IEnumerable][2]&lt;**T**>. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

Exceptions
----------

| Exception                        | Condition                                |
| -------------------------------- | ---------------------------------------- |
| [ArgumentOutOfRangeException][6] | Thrown when *pageSize* is less than `1`. |


See Also
--------

#### Reference
[LINQExtensions Class][7]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: https://docs.microsoft.com/dotnet/api/system.int32
[4]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[5]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[6]: https://docs.microsoft.com/dotnet/api/system.argumentoutofrangeexception
[7]: README.md