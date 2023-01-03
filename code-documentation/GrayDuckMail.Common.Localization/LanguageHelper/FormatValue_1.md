LanguageHelper.FormatValue Method (Language, String, Object[])
==============================================================
Gets a value from the resource file in a given *language*, then formats it with given *parameters*.

  **Namespace:**  [GrayDuckMail.Common.Localization][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
private static string FormatValue(
	Language language,
	string name,
	params Object[] parameters
)
```

#### Parameters

##### *language*
Type: [GrayDuckMail.Common.Localization.Language][2]  
 The language.

##### *name*
Type: [System.String][3]  
 The name.

##### *parameters*
Type: [System.Object][4][]  
 Options for controlling the operation.

#### Return Value
Type: [String][3]  
 The formatted value. 

See Also
--------

#### Reference
[LanguageHelper Class][5]  
[GrayDuckMail.Common.Localization Namespace][1]  

[1]: ../README.md
[2]: ../Language/README.md
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: https://docs.microsoft.com/dotnet/api/system.object
[5]: README.md