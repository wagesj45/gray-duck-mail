LanguageHelper.SupportedLanguages Property
==========================================
Gets an enumeration of the supported languages.

  **Namespace:**  [GrayDuckMail.Common.Localization][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static IEnumerable<Language> SupportedLanguages { get; }
```

#### Property Value
Type: [IEnumerable][2]&lt;[Language][3]>  
 The supported languages. 

Remarks
-------
 This [IEnumerable&lt;T>][2] should be manually updated every time a new [Language][3] is defined. 

See Also
--------

#### Reference
[LanguageHelper Class][4]  
[GrayDuckMail.Common.Localization Namespace][1]  
[GrayDuckMail.Common.Localization.Language][3]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: ../Language/README.md
[4]: README.md