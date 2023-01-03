EnumerationHelper.Deconstruct&lt;T> Method
==========================================
An Enum extension method that deconstructs the given enumeration into a dictionary of its integer value and its name.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static IEnumerable<T> Deconstruct<T>()
where T : struct, new()

```

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: [IEnumerable][2]&lt;**T**>  
 An enumerator that allows foreach to be used to process deconstruct in this collection. 

See Also
--------

#### Reference
[EnumerationHelper Class][3]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: README.md