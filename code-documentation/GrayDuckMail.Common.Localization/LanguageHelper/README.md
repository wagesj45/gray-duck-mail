LanguageHelper Class
====================
A class that contains methods for managing text and localization.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Common.Localization.LanguageHelper**  

  **Namespace:**  [GrayDuckMail.Common.Localization][2]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static class LanguageHelper
```

The **LanguageHelper** type exposes the following members.


Constructors
------------

|                                   | Name                | Description |
| --------------------------------- | ------------------- | ----------- |
| ![Private method]![Static member] | [LanguageHelper][3] |             |


Properties
----------

|                                    | Name                    | Description                                     |
| ---------------------------------- | ----------------------- | ----------------------------------------------- |
| ![Public property]![Static member] | [SupportedLanguages][4] | Gets an enumeration of the supported languages. |


Methods
-------

|                                   | Name                                               | Description                                                                                                             |
| --------------------------------- | -------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member]  | [CamelCaseToHumanReadable][5]                      | Converts camel case text to human readable text.                                                                        |
| ![Public method]![Static member]  | [FormatValue(ResourceName, Object[])][6]           | Gets a text value from the localized resource file in the default language, then formats it with given *parameters*.    |
| ![Private method]![Static member] | [FormatValue(String, Object[])][7]                 | Gets a value from the resource file in the default language, then formats it with given *parameters*.                   |
| ![Public method]![Static member]  | [FormatValue(Language, ResourceName, Object[])][8] | Gets a text value from the localized resource file in a given *language*, then formats it with given *parameters*.      |
| ![Private method]![Static member] | [FormatValue(Language, String, Object[])][9]       | Gets a value from the resource file in a given *language*, then formats it with given *parameters*.                     |
| ![Public method]![Static member]  | [FormatValue(String, ResourceName, Object[])][10]  | Gets a text value from the localized resource file in a given *language*, then formats it with given *parameters*.      |
| ![Private method]![Static member] | [FormatValue(String, String, Object[])][11]        | Gets a value from the resource file in a given *language*, then formats it with given *parameters*.                     |
| ![Public method]![Static member]  | [GetCurrentLanguage][12]                           | Gets current localized language.                                                                                        |
| ![Public method]![Static member]  | [GetDefaultLanguage][13]                           | Gets the default language. Used when no localization is specified.                                                      |
| ![Public method]![Static member]  | [GetLanguage][14]                                  | Gets a language as described by *language* matching the [Name][15], [BroadLanguage][16], or [CommonName][17].           |
| ![Public method]![Static member]  | [GetValue(ResourceName)][18]                       | Gets a text value from the localized resource file in the default language.                                             |
| ![Private method]![Static member] | [GetValue(String)][19]                             | Gets a text value from the localized resource file in the default language.                                             |
| ![Public method]![Static member]  | [GetValue(Language, ResourceName)][20]             | Gets a text value from the localized resource file in a given *language*.                                               |
| ![Private method]![Static member] | [GetValue(Language, String)][21]                   | Gets a text value from the localized resource file in a given *language*.                                               |
| ![Private method]![Static member] | [GetValue(String, ResourceName)][22]               | Gets a text value from the localized resource file in a given *language*.                                               |
| ![Private method]![Static member] | [GetValue(String, String)][23]                     | Gets a text value from the localized resource file in a given *language*.                                               |
| ![Public method]![Static member]  | [IsLanguageSupported][24]                          | Determines if a given *language* has supported localization.                                                            |
| ![Public method]![Static member]  | [SetLanguage][25]                                  | Sets the current language as described by *language* matching the [Name][15], [BroadLanguage][16], or [CommonName][17]. |


See Also
--------

#### Reference
[GrayDuckMail.Common.Localization Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: SupportedLanguages.md
[5]: CamelCaseToHumanReadable.md
[6]: FormatValue_2.md
[7]: FormatValue_4.md
[8]: FormatValue.md
[9]: FormatValue_1.md
[10]: FormatValue_3.md
[11]: FormatValue_5.md
[12]: GetCurrentLanguage.md
[13]: GetDefaultLanguage.md
[14]: GetLanguage.md
[15]: ../Language/Name.md
[16]: ../Language/BroadLanguage.md
[17]: ../Language/CommonName.md
[18]: GetValue_2.md
[19]: GetValue_3.md
[20]: GetValue.md
[21]: GetValue_1.md
[22]: GetValue_4.md
[23]: GetValue_5.md
[24]: IsLanguageSupported.md
[25]: SetLanguage.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"