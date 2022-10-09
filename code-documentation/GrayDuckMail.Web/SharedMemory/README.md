SharedMemory Class
==================
An object containing shared memory objects. These collections are meant to be shared between threads.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Web.SharedMemory**  

  **Namespace:**  [GrayDuckMail.Web][2]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public static class SharedMemory
```

The **SharedMemory** type exposes the following members.


Constructors
------------

|                                   | Name              | Description         |
| --------------------------------- | ----------------- | ------------------- |
| ![Private method]![Static member] | [SharedMemory][3] | Static constructor. |


Methods
-------

|                                  | Name          | Description                                                       |
| -------------------------------- | ------------- | ----------------------------------------------------------------- |
| ![Public method]![Static member] | [AddEmail][4] | Adds an email definition to the emailQueue.                       |
| ![Public method]![Static member] | [PopEmail][5] | Pops the [EmailDefinition][6] from the queue if one is available. |


Remarks
-------
 Because cross thread access is expected, care must be taken to make sure all methods are thread safe. 

See Also
--------

#### Reference
[GrayDuckMail.Web Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: AddEmail.md
[5]: PopEmail.md
[6]: ../../GrayDuckMail.Common/EmailDefinition/README.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"