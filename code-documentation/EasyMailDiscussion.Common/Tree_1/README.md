Tree&lt;T> Class
================
A branching tree structure that can recursively populate child nodes.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **EasyMailDiscussion.Common.Tree&lt;T>**  

  **Namespace:**  [EasyMailDiscussion.Common][2]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
public class Tree<T>

```

#### Type Parameters

##### *T*
Generic type parameter.

The **Tree&lt;T>** type exposes the following members.


Constructors
------------

|                                   | Name            | Description  |
| --------------------------------- | --------------- | ------------ |
| ![Private method]![Static member] | [Tree&lt;T>][3] |              |
| ![Public method]                  | [Tree&lt;T>][4] | Constructor. |


Properties
----------

|                    | Name          | Description                                                                            |
| ------------------ | ------------- | -------------------------------------------------------------------------------------- |
| ![Public property] | [Branches][5] | Gets or sets the branch nodes of this branch.                                          |
| ![Public property] | [IsBase][6]   | Gets or sets a value indicating whether this object is the base of the **Tree&lt;T>**. |
| ![Public property] | [Parent][7]   | Gets or sets the parent of this branch.                                                |
| ![Public property] | [Value][8]    | Gets or sets the value for this branch.                                                |


See Also
--------

#### Reference
[EasyMailDiscussion.Common Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: _ctor.md
[5]: Branches.md
[6]: IsBase.md
[7]: Parent.md
[8]: Value.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"