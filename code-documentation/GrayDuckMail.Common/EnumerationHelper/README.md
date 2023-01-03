EnumerationHelper Class
=======================
A class that contains methods for managing [Enum][1] objects.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GrayDuckMail.Common.EnumerationHelper**  

  **Namespace:**  [GrayDuckMail.Common][3]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static class EnumerationHelper
```


Methods
-------

|                                  | Name                                   | Description                                                                                                           |
| -------------------------------- | -------------------------------------- | --------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | [Deconstruct&lt;T>()][4]               | An Enum extension method that deconstructs the given enumeration into a dictionary of its integer value and its name. |
| ![Public method]![Static member] | [Deconstruct&lt;T>(T)][5]              | An Enum extension method that deconstructs the given enumeration into a dictionary of its integer value and its name. |
| ![Public method]![Static member] | [DeconstructNonDefault&lt;T>()][6]     | An Enum extension method that deconstruct non default.                                                                |
| ![Public method]![Static member] | [DeconstructNonDefault&lt;T>(T)][7]    | An Enum extension method that deconstruct non default.                                                                |
| ![Public method]![Static member] | [GetEnumerationValue&lt;T>(Int32)][8]  | Gets enumeration value from its integer value.                                                                        |
| ![Public method]![Static member] | [GetEnumerationValue&lt;T>(String)][9] | Gets enumeration value from a string value.                                                                           |


See Also
--------

#### Reference
[GrayDuckMail.Common Namespace][3]  

[1]: https://learn.microsoft.com/dotnet/api/system.enum
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../README.md
[4]: Deconstruct__1.md
[5]: Deconstruct__1_1.md
[6]: DeconstructNonDefault__1.md
[7]: DeconstructNonDefault__1_1.md
[8]: GetEnumerationValue__1.md
[9]: GetEnumerationValue__1_1.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/static.gif "Static member"