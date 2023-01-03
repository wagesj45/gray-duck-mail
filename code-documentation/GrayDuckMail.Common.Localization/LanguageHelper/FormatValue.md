LanguageHelper.FormatValue Method (Language, ResourceName, Object[])
====================================================================
Gets a text value from the localized resource file in a given *language*, then formats it with given *parameters*.

  **Namespace:**  [GrayDuckMail.Common.Localization][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static string FormatValue(
	Language language,
	ResourceName name,
	params Object[] parameters
)
```

#### Parameters

##### *language*
Type: [GrayDuckMail.Common.Localization.Language][2]  
 The language.

##### *name*
Type: [GrayDuckMail.Common.Localization.ResourceName][3]  
 The name of the text resource.

##### *parameters*
Type: [System.Object][4][]  
 An object array that contains `0` or more objects to format.

#### Return Value
Type: [String][5]  
 The localized, formatted text resource. 

See Also
--------

#### Reference
[LanguageHelper Class][6]  
[GrayDuckMail.Common.Localization Namespace][1]  

[1]: ../README.md
[2]: ../Language/README.md
[3]: ../ResourceName/README.md
[4]: https://docs.microsoft.com/dotnet/api/system.object
[5]: https://docs.microsoft.com/dotnet/api/system.string
[6]: README.md