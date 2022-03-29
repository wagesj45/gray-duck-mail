IndexedMimeMessage Class
========================
An indexed MimeMessage.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **EasyMailDiscussion.Common.IndexedMimeMessage**  

  **Namespace:**  [EasyMailDiscussion.Common][2]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public class IndexedMimeMessage
```

The **IndexedMimeMessage** type exposes the following members.


Constructors
------------

|                                   | Name                    | Description                                                                    |
| --------------------------------- | ----------------------- | ------------------------------------------------------------------------------ |
| ![Private method]![Static member] | [IndexedMimeMessage][3] |                                                                                |
| ![Private method]                 | [IndexedMimeMessage][4] | Constructor that prevents a default instance of this class from being created. |


Properties
----------

|                    | Name         | Description                                       |
| ------------------ | ------------ | ------------------------------------------------- |
| ![Public property] | [Index][5]   | Gets or sets the zero-based index of this object. |
| ![Public property] | [Message][6] | Gets or sets the message.                         |


Methods
-------

|                                  | Name                   | Description                                                                                  |
| -------------------------------- | ---------------------- | -------------------------------------------------------------------------------------------- |
| ![Public method]                 | [Equals][7]            | Tests if this object is considered equal to another. (Overrides [Object.Equals(Object)][8].) |
| ![Public method]                 | [GetHashCode][9]       | Serves as the default hash function. (Overrides [Object.GetHashCode()][10].)                 |
| ![Public method]![Static member] | [IndexMimeMessage][11] | Indexes a MimeMessage into an **IndexedMimeMessage**.                                        |


Remarks
-------
 The Pop3Client works using message indexes when communicating with the remote server. Messages from GetMessages(Int32, Int32, CancellationToken, ITransferProgress) do not include these indices so we must manually index them using a [Select&lt;TSource, TResult>(IEnumerable&lt;TSource>, Func&lt;TSource, Int32, TResult>)][12]. 

See Also
--------

#### Reference
[EasyMailDiscussion.Common Namespace][2]  
Pop3Client  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: _ctor.md
[5]: Index.md
[6]: Message.md
[7]: Equals.md
[8]: https://docs.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object)
[9]: GetHashCode.md
[10]: https://docs.microsoft.com/dotnet/api/system.object.gethashcode#system-object-gethashcode
[11]: IndexMimeMessage.md
[12]: https://docs.microsoft.com/dotnet/api/system.linq.enumerable.select#system-linq-enumerable-select-2(system-collections-generic-ienumerable((-0))-system-func((-0-system-int32-1)))
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"