SqliteDatabase.EnsureDatabaseFile Method
========================================
Ensures that the database file exists and is initialized.

  **Namespace:**  [GrayDuckMail.Common.Database][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
private void EnsureDatabaseFile(
	Uri databaseFilePath
)
```

#### Parameters

##### *databaseFilePath*
Type: [System.Uri][2]  
 Full pathname of the database file.


Exceptions
----------

| Exception                  | Condition                                      |
| -------------------------- | ---------------------------------------------- |
| [FileNotFoundException][3] | Thrown when the requested file is not present. |


See Also
--------

#### Reference
[SqliteDatabase Class][4]  
[GrayDuckMail.Common.Database Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.uri
[3]: https://docs.microsoft.com/dotnet/api/system.io.filenotfoundexception
[4]: README.md