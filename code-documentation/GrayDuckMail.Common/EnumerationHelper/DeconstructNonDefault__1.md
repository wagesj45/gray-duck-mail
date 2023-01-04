EnumerationHelper.DeconstructNonDefault&lt;T> Method
====================================================
An Enum extension method that deconstruct non default.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static IEnumerable<T> DeconstructNonDefault<T>()
where T : struct, new()

```

#### Type Parameters

##### *T*
Generic type parameter.

#### Return Value
Type: [IEnumerable][2]&lt;**T**>  
 An enumerator that allows foreach to be used to process deconstruct non default in this collection. 

See Also
--------

#### Reference
[EnumerationHelper Class][3]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: README.md