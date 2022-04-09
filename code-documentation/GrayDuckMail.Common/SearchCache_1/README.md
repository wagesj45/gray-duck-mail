SearchCache&lt;T> Class
=======================
A cache of search results.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Common.SearchCache&lt;T>**  

  **Namespace:**  [GrayDuckMail.Common][2]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public class SearchCache<T>

```

#### Type Parameters

##### *T*
Generic type parameter.

The **SearchCache&lt;T>** type exposes the following members.


Constructors
------------

|                  | Name                                                               | Description          |
| ---------------- | ------------------------------------------------------------------ | -------------------- |
| ![Public method] | [SearchCache&lt;T>()][3]                                           | Default constructor. |
| ![Public method] | [SearchCache&lt;T>(String, IEnumerable&lt;SearchResult&lt;T>>)][4] | Constructor.         |


Properties
----------

|                    | Name            | Description                                                  |
| ------------------ | --------------- | ------------------------------------------------------------ |
| ![Public property] | [Cache][5]      | Gets or sets the cache of search results.                    |
| ![Public property] | [SearchTerm][6] | Gets or sets the search term used when generating the cache. |


See Also
--------

#### Reference
[GrayDuckMail.Common Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _ctor.md
[4]: _ctor_1.md
[5]: Cache.md
[6]: SearchTerm.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"