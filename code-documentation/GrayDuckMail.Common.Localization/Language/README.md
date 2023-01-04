Language Class
==============
A class that represents a written language.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Common.Localization.Language**  
    [GrayDuckMail.Common.Localization.ActiveLanguage][2]  

  **Namespace:**  [GrayDuckMail.Common.Localization][3]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public abstract class Language
```

The **Language** type exposes the following members.


Constructors
------------

|                     | Name          | Description                                          |
| ------------------- | ------------- | ---------------------------------------------------- |
| ![Protected method] | [Language][4] | Initializes a new instance of the **Language** class |


Properties
----------

|                                    | Name                      | Description                                                        |
| ---------------------------------- | ------------------------- | ------------------------------------------------------------------ |
| ![Public property]                 | [BroadLanguage][5]        | Gets the broadly applicable language name.                         |
| ![Public property]                 | [CommonName][6]           | Gets the common name of the language.                              |
| ![Public property]                 | [Culture][7]              | Gets or sets the language culture.                                 |
| ![Public property]                 | [CultureCode][8]          | Gets or sets the culture code of the language.                     |
| ![Public property]                 | [DisplayName][9]          | Gets or sets the name of the language as displayed in UI elements. |
| ![Public property]![Static member] | [EnglishUnitedStates][10] | English Language - United States Localization.                     |
| ![Public property]![Static member] | [GermanGermany][11]       |                                                                    |
| ![Public property]                 | [ISOValue][12]            | Gets or sets the ISO value of the language.                        |
| ![Public property]![Static member] | [JapaneseJapan][13]       | Japenese Language - Japan Localization.                            |
| ![Public property]                 | [Name][14]                | Gets or sets the name of the language.                             |
| ![Public property]![Static member] | [SpanishSpain][15]        | Spanish Language - Spain Localization.                             |


Remarks
-------
 The class is marked as abstract and can only be instanced via static[ActiveLanguage][2] invocation methods. This means that new languages should be declared within this class. 

Examples
--------
 Only the [ActiveLanguage][2] can act as an instance of a **Language**. 
```csharp
public static Language EnglishUnitedStates
{
    get
    {
        return new ActiveLanguage("en-US", "English - United States", 0x0409, string.Empty);
    }
}
```


See Also
--------

#### Reference
[GrayDuckMail.Common.Localization Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../ActiveLanguage/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: BroadLanguage.md
[6]: CommonName.md
[7]: Culture.md
[8]: CultureCode.md
[9]: DisplayName.md
[10]: EnglishUnitedStates.md
[11]: GermanGermany.md
[12]: ISOValue.md
[13]: JapaneseJapan.md
[14]: Name.md
[15]: SpanishSpain.md
[Protected method]: ../../icons/protmethod.svg "Protected method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Static member]: ../../icons/static.gif "Static member"