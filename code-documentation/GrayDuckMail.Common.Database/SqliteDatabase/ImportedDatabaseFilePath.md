SqliteDatabase.ImportedDatabaseFilePath Property
================================================
Gets the full pathname of an imported database file.

  **Namespace:**  [GrayDuckMail.Common.Database][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public Uri ImportedDatabaseFilePath { get; }
```

#### Property Value
Type: [Uri][2]  
 The full pathname of an imported database file. 

Remarks
-------
 This property relies on [DatabaseFilePath][3] and will mirror it with a minor alteration to the file name. 

See Also
--------

#### Reference
[SqliteDatabase Class][4]  
[GrayDuckMail.Common.Database Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.uri
[3]: DatabaseFilePath.md
[4]: README.md