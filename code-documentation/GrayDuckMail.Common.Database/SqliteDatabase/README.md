SqliteDatabase Class
====================
The SQLite database is defined and managed by this class. This uses [Entity Framework Code First][1] method for defining a database and uses [SQLite][2] to store data in a local database file, without the need for any external database system.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbContext][4]  
    **GrayDuckMail.Common.Database.SqliteDatabase**  

  **Namespace:**  [GrayDuckMail.Common.Database][5]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public class SqliteDatabase : DbContext
```

The **SqliteDatabase** type exposes the following members.


Constructors
------------

|                                   | Name                        | Description                                                                    |
| --------------------------------- | --------------------------- | ------------------------------------------------------------------------------ |
| ![Private method]![Static member] | [SqliteDatabase()][6]       |                                                                                |
| ![Private method]                 | [SqliteDatabase()][7]       | Constructor that prevents a default instance of this class from being created. |
| ![Public method]                  | [SqliteDatabase(String)][8] | Constructor.                                                                   |


Properties
----------

|                                    | Name                           | Description                                                                                                        |
| ---------------------------------- | ------------------------------ | ------------------------------------------------------------------------------------------------------------------ |
| ![Public property]                 | [Contacts][9]                  | Gets or sets the [Contact][10] table.                                                                              |
| ![Public property]                 | [ContactSubscriptions][11]     | Gets or sets the [ContactSubscription][12] table.                                                                  |
| ![Public property]                 | [DatabaseFilePath][13]         | Gets or sets the full pathname of the database file.                                                               |
| ![Public property]                 | [DiscussionLists][14]          | Gets or sets the [DiscussionList][15] table.                                                                       |
| ![Public property]                 | [ImportedDatabaseFilePath][16] | Gets the full pathname of an imported database file.                                                               |
| ![Public property]                 | [Messages][17]                 | Gets or sets the [Message][18] table.                                                                              |
| ![Public property]                 | [RelayIdentifiers][19]         | Gets or sets the [RelayIdentifier][20] table.                                                                      |
| ![Public property]![Static member] | [ValidFileContentTypes][21]    | Gets a collection of types of that are recognized as valid file content-types representing a SQLite database file. |


Methods
-------

|                     | Name                     | Description                                                                                               |
| ------------------- | ------------------------ | --------------------------------------------------------------------------------------------------------- |
| ![Private method]   | [EnsureDatabaseFile][22] | Ensures that the database file exists and is initialized.                                                 |
| ![Public method]    | [IsValidContentType][23] | Query if a givent file content-type value is a valid content-type for a SQLite datbase file.              |
| ![Protected method] | [OnConfiguring][24]      | Executing when configuring the model. (Overrides [DbContext.OnConfiguring(DbContextOptionsBuilder)][25].) |
| ![Protected method] | [OnModelCreating][26]    | Executed when creating the model. (Overrides [DbContext.OnModelCreating(ModelBuilder)][27].)              |


Fields
------

|                                 | Name                                   | Description                                                                 |
| ------------------------------- | -------------------------------------- | --------------------------------------------------------------------------- |
| ![Public field]![Static member] | [GENERIC_BINARY_FILE_CONTENT_TYPE][28] | (Immutable) The generic binary file content-type provided by most browsers. |
| ![Public field]![Static member] | [SQLITE_FILE_CONTENT_TYPE][29]         | (Immutable) The defined content-type value of theSQLite3 file format.       |
| ![Public field]![Static member] | [TEMP_DATABASE_FILE_EXTENSION][30]     | (Immutable) The temporary database file extension.                          |


See Also
--------

#### Reference
[GrayDuckMail.Common.Database Namespace][5]  
[DbContext][4]  
[DbSet][31]  

[1]: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
[2]: https://sqlite.org/index.html
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext
[5]: ../README.md
[6]: _cctor.md
[7]: _ctor.md
[8]: _ctor_1.md
[9]: Contacts.md
[10]: ../Contact/README.md
[11]: ContactSubscriptions.md
[12]: ../ContactSubscription/README.md
[13]: DatabaseFilePath.md
[14]: DiscussionLists.md
[15]: ../DiscussionList/README.md
[16]: ImportedDatabaseFilePath.md
[17]: Messages.md
[18]: ../Message/README.md
[19]: RelayIdentifiers.md
[20]: ../RelayIdentifier/README.md
[21]: ValidFileContentTypes.md
[22]: EnsureDatabaseFile.md
[23]: IsValidContentType.md
[24]: OnConfiguring.md
[25]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext.onconfiguring#microsoft-entityframeworkcore-dbcontext-onconfiguring(microsoft-entityframeworkcore-dbcontextoptionsbuilder)
[26]: OnModelCreating.md
[27]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext.onmodelcreating#microsoft-entityframeworkcore-dbcontext-onmodelcreating(microsoft-entityframeworkcore-modelbuilder)
[28]: GENERIC_BINARY_FILE_CONTENT_TYPE.md
[29]: SQLITE_FILE_CONTENT_TYPE.md
[30]: TEMP_DATABASE_FILE_EXTENSION.md
[31]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbset-1
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Protected method]: ../../icons/protmethod.svg "Protected method"
[Public field]: ../../icons/pubfield.svg "Public field"