LanguageHelper.FormatValue Method (ResourceName, Object[])
==========================================================
Gets a text value from the localized resource file in the default language, then formats it with given *parameters*.

  **Namespace:**  [GrayDuckMail.Common.Localization][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static string FormatValue(
	ResourceName name,
	params Object[] parameters
)
```

#### Parameters

##### *name*
Type: [GrayDuckMail.Common.Localization.ResourceName][2]  
 The name of the text resource.

##### *parameters*
Type: [System.Object][3][]  
 An object array that contains `0` or more objects to format.

#### Return Value
Type: [String][4]  
 The formatted text resource. 

See Also
--------

#### Reference
[LanguageHelper Class][5]  
[GrayDuckMail.Common.Localization Namespace][1]  

[1]: ../README.md
[2]: ../ResourceName/README.md
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: https://docs.microsoft.com/dotnet/api/system.string
[5]: README.md