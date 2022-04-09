LINQExtensions Class
====================
A helper class containing extensions for [LINQ][1] operations.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GrayDuckMail.Common.LINQExtensions**  

  **Namespace:**  [GrayDuckMail.Common][3]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static class LINQExtensions
```

The **LINQExtensions** type exposes the following members.


Constructors
------------

|                                   | Name                | Description |
| --------------------------------- | ------------------- | ----------- |
| ![Private method]![Static member] | [LINQExtensions][4] |             |


Methods
-------

|                                  | Name                                                                            | Description                                                                                      |
| -------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------ |
| ![Public method]![Static member] | [FuzzySearch&lt;T>][5]                                                          | Enumerates the items in this collection that contain a given *searchTerm* or a similar string.   |
| ![Public method]![Static member] | [Page&lt;T>(IEnumerable&lt;T>, Int32, Int32)][6]                                | Get a page of items from a collection, skipping *pageNumber* pages of *pageSize* items per page. |
| ![Public method]![Static member] | [Page&lt;T>(IQueryable&lt;T>, Int32, Int32)][7]                                 | Get a page of items from a collection, skipping *pageNumber* pages of *pageSize* items per page. |
| ![Public method]![Static member] | [PageCount&lt;T>(IEnumerable&lt;T>, Int32)][8]                                  | The number of pages of *pageSize* size in the given collection.                                  |
| ![Public method]![Static member] | [PageCount&lt;T>(IQueryable&lt;T>, Int32)][9]                                   | The number of pages of *pageSize* size in the given collection.                                  |
| ![Public method]![Static member] | [Search&lt;T>(IEnumerable&lt;T>, Func&lt;T, String>, String)][10]               | Enumerates the items in this collection that contain a given *searchTerm*.                       |
| ![Public method]![Static member] | [Search&lt;T>(IQueryable&lt;T>, Expression&lt;Func&lt;T, String>>, String)][11] | Enumerates the items in this collection that contain a given *searchTerm*.                       |


See Also
--------

#### Reference
[GrayDuckMail.Common Namespace][3]  
[System.Linq][12]  

[1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../README.md
[4]: _cctor.md
[5]: FuzzySearch__1.md
[6]: Page__1.md
[7]: Page__1_1.md
[8]: PageCount__1.md
[9]: PageCount__1_1.md
[10]: Search__1.md
[11]: Search__1_1.md
[12]: https://docs.microsoft.com/dotnet/api/system.linq
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"