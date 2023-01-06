HashHelper Class
================

[Missing &lt;summary> documentation for "T:GrayDuckMail.Common.HashHelper"]



Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Common.HashHelper**  

  **Namespace:**  [GrayDuckMail.Common][2]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static class HashHelper
```

The **HashHelper** type exposes the following members.


Constructors
------------

|                                   | Name            | Description |
| --------------------------------- | --------------- | ----------- |
| ![Private method]![Static member] | [HashHelper][3] |             |


Methods
-------

|                                  | Name           | Description                                                                                                                                      |
| -------------------------------- | -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method]![Static member] | [CheckHash][4] | Check a given hash to confirm that it matches the [Hash(Int32, Int32, String)][5] of the given contact ID, discussion list ID, and secret token. |
| ![Public method]![Static member] | [Hash][5]      | Hashes a given contact ID, discussion list ID, and a secret token.                                                                               |


See Also
--------

#### Reference
[GrayDuckMail.Common Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: CheckHash.md
[5]: Hash.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"