LINQExtensions Class
====================
A helper class containing extensions for [LINQ][1] operations.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **EasyMailDiscussion.Common.LINQExtensions**  

  **Namespace:**  [EasyMailDiscussion.Common][3]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public static class LINQExtensions
```


Methods
-------

|                                  | Name                                             | Description                                                                                      |
| -------------------------------- | ------------------------------------------------ | ------------------------------------------------------------------------------------------------ |
| ![Public method]![Static member] | [Page&lt;T>(IEnumerable&lt;T>, Int32, Int32)][4] | Get a page of items from a collection, skipping *pageNumber* pages of *pageSize* items per page. |
| ![Public method]![Static member] | [Page&lt;T>(IQueryable&lt;T>, Int32, Int32)][5]  | Get a page of items from a collection, skipping *pageNumber* pages of *pageSize* items per page. |
| ![Public method]![Static member] | [PageCount&lt;T>(IEnumerable&lt;T>, Int32)][6]   | The number of pages of *pageSize* size in the given collection.                                  |
| ![Public method]![Static member] | [PageCount&lt;T>(IQueryable&lt;T>, Int32)][7]    | The number of pages of *pageSize* size in the given collection.                                  |


See Also
--------

#### Reference
[EasyMailDiscussion.Common Namespace][3]  
[System.Linq][8]  

[1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../README.md
[4]: Page__1.md
[5]: Page__1_1.md
[6]: PageCount__1.md
[7]: PageCount__1_1.md
[8]: https://docs.microsoft.com/dotnet/api/system.linq
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/static.gif "Static member"