EnumerationExtensions.Parse&lt;T> Method (T, String)
====================================================
A T extension method that parses a string into an enumeration.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static T Parse<T>(
	this T enumeration,
	string value
)
where T : Enum

```

#### Parameters

##### *enumeration*
Type: **T**  
 The enumeration to act on.

##### *value*
Type: [System.String][2]  
 The value.

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: **T**  
 A T. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type . When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][3] or [Extension Methods (C# Programming Guide)][4].

See Also
--------

#### Reference
[EnumerationExtensions Class][5]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[4]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[5]: README.md