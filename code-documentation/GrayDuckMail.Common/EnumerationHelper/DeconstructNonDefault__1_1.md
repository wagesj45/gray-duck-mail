EnumerationHelper.DeconstructNonDefault&lt;T> Method (T)
========================================================
An Enum extension method that deconstruct non default.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static IEnumerable<T> DeconstructNonDefault<T>(
	this T enumeration
)
where T : struct, new()

```

#### Parameters

##### *enumeration*
Type: **T**  
 The enumeration to act on.

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: [IEnumerable][2]&lt;**T**>  
 An enumerator that allows foreach to be used to process deconstruct non default in this collection. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type . When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][3] or [Extension Methods (C# Programming Guide)][4].

See Also
--------

#### Reference
[EnumerationHelper Class][5]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[4]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[5]: README.md