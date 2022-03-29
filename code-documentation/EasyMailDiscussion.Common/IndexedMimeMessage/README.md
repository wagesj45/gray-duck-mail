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


Properties
----------

|                    | Name         | Description                                       |
| ------------------ | ------------ | ------------------------------------------------- |
| ![Public property] | [Index][3]   | Gets or sets the zero-based index of this object. |
| ![Public property] | [Message][4] | Gets or sets the message.                         |


Methods
-------

|                                  | Name                   | Description                                                                                                                                                |
| -------------------------------- | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]                 | [Equals][5]            | Determines whether the specified object is equal to the current object. (Overrides [Object.Equals(Object)][6].)                                            |
| ![Protected method]              | [Finalize][7]          | Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection. (Inherited from [Object][1].) |
| ![Public method]                 | [GetHashCode][8]       | Serves as the default hash function. (Overrides [Object.GetHashCode()][9].)                                                                                |
| ![Public method]                 | [GetType][10]          | Gets the [Type][11] of the current instance. (Inherited from [Object][1].)                                                                                 |
| ![Public method]![Static member] | [IndexMimeMessage][12] | Indexes a MimeMessage into an **IndexedMimeMessage**.                                                                                                      |
| ![Protected method]              | [MemberwiseClone][13]  | Creates a shallow copy of the current [Object][1]. (Inherited from [Object][1].)                                                                           |
| ![Public method]                 | [ToString][14]         | Returns a string that represents the current object. (Inherited from [Object][1].)                                                                         |


Remarks
-------
 The Pop3Client works using message indexes when communicating with the remote server. Messages from GetMessages(Int32, Int32, CancellationToken, ITransferProgress) do not include these indices so we must manually index them using a [Select&lt;TSource, TResult>(IEnumerable&lt;TSource>, Func&lt;TSource, Int32, TResult>)][15]. 

See Also
--------

#### Reference
[EasyMailDiscussion.Common Namespace][2]  
Pop3Client  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: Index.md
[4]: Message.md
[5]: Equals.md
[6]: https://docs.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object)
[7]: https://docs.microsoft.com/dotnet/api/system.object.finalize#system-object-finalize
[8]: GetHashCode.md
[9]: https://docs.microsoft.com/dotnet/api/system.object.gethashcode#system-object-gethashcode
[10]: https://docs.microsoft.com/dotnet/api/system.object.gettype#system-object-gettype
[11]: https://docs.microsoft.com/dotnet/api/system.type
[12]: IndexMimeMessage.md
[13]: https://docs.microsoft.com/dotnet/api/system.object.memberwiseclone#system-object-memberwiseclone
[14]: https://docs.microsoft.com/dotnet/api/system.object.tostring#System_Object_ToString
[15]: https://docs.microsoft.com/dotnet/api/system.linq.enumerable.select#system-linq-enumerable-select-2(system-collections-generic-ienumerable((-0))-system-func((-0-system-int32-1)))
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Protected method]: ../../icons/protmethod.svg "Protected method"
[Static member]: ../../icons/static.gif "Static member"