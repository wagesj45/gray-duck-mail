EnumerationExtensions.Parse&lt;T> Method (T, String, Boolean)
=============================================================
A T extension method that parses a string into an enumeration.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static T Parse<T>(
	this T enumeration,
	string value,
	bool ignoreCase
)
where T : Enum

```

#### Parameters

##### *enumeration*
Type: **T**  
 The enumeration to act on.

##### *value*
Type: [System.String][2]  
 The string value of the [Enum][3].

##### *ignoreCase*
Type: [System.Boolean][4]  
 True to ignore case.

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: **T**  
 A T. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type . When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

See Also
--------

#### Reference
[EnumerationExtensions Class][7]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: https://learn.microsoft.com/dotnet/api/system.enum
[4]: https://docs.microsoft.com/dotnet/api/system.boolean
[5]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[6]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[7]: README.md