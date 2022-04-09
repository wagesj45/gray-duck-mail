BaseFormInput&lt;T>.IsChecked Method
====================================
Determine if a property of a derived class represents an HTML form value coresponding to a marked checkbox.

  **Namespace:**  [GrayDuckMail.Web.Models.Forms][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public bool IsChecked(
	Func<T, string> propertyAccessor
)
```

#### Parameters

##### *propertyAccessor*
Type: [System.Func][2]&lt;[T][3], [String][4]>  
 The property accessor.

#### Return Value
Type: [Boolean][5]  
 True if checked, false if not. 

See Also
--------

#### Reference
[BaseFormInput&lt;T> Class][3]  
[GrayDuckMail.Web.Models.Forms Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.func-2
[3]: README.md
[4]: https://docs.microsoft.com/dotnet/api/system.string
[5]: https://docs.microsoft.com/dotnet/api/system.boolean