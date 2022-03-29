SqliteDatabase Class
====================
The SQLite database is defined and managed by this class. This uses Entity Framework Code First method for defining a database and uses SQLite to store data in a local database file, without the need for any external database system.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [DbContext][2]  
    **EasyMailDiscussion.Common.Database.SqliteDatabase**  

  **Namespace:**  [EasyMailDiscussion.Common.Database][3]  
  **Assembly:** easy-mail-discussion-common.dll

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
| ![Private method]![Static member] | [SqliteDatabase()][4]       |                                                                                |
| ![Private method]                 | [SqliteDatabase()][5]       | Constructor that prevents a default instance of this class from being created. |
| ![Public method]                  | [SqliteDatabase(String)][6] | Constructor.                                                                   |


Properties
----------

|                    | Name                      | Description                                       |
| ------------------ | ------------------------- | ------------------------------------------------- |
| ![Public property] | [Contacts][7]             | Gets or sets the [Contact][8] table.              |
| ![Public property] | [ContactSubscriptions][9] | Gets or sets the [ContactSubscription][10] table. |
| ![Public property] | [DiscussionLists][11]     | Gets or sets the [DiscussionList][12] table.      |
| ![Public property] | [Messages][13]            | Gets or sets the [Message][14] table.             |
| ![Public property] | [RelayIdentifiers][15]    | Gets or sets the [RelayIdentifier][16] table.     |


Methods
-------

|                     | Name                     | Description                                                                                               |
| ------------------- | ------------------------ | --------------------------------------------------------------------------------------------------------- |
| ![Private method]   | [EnsureDatabaseFile][17] | Ensures that the database file exists and is initialized.                                                 |
| ![Protected method] | [OnConfiguring][18]      | Executing when configuring the model. (Overrides [DbContext.OnConfiguring(DbContextOptionsBuilder)][19].) |
| ![Protected method] | [OnModelCreating][20]    | Executed when creating the model. (Overrides [DbContext.OnModelCreating(ModelBuilder)][21].)              |


See Also
--------

#### Reference
[EasyMailDiscussion.Common.Database Namespace][3]  
[DbContext][2]  
[DbSet][22]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext
[3]: ../README.md
[4]: _cctor.md
[5]: _ctor.md
[6]: _ctor_1.md
[7]: Contacts.md
[8]: ../Contact/README.md
[9]: ContactSubscriptions.md
[10]: ../ContactSubscription/README.md
[11]: DiscussionLists.md
[12]: ../DiscussionList/README.md
[13]: Messages.md
[14]: ../Message/README.md
[15]: RelayIdentifiers.md
[16]: ../RelayIdentifier/README.md
[17]: EnsureDatabaseFile.md
[18]: OnConfiguring.md
[19]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext.onconfiguring#microsoft-entityframeworkcore-dbcontext-onconfiguring(microsoft-entityframeworkcore-dbcontextoptionsbuilder)
[20]: OnModelCreating.md
[21]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext.onmodelcreating#microsoft-entityframeworkcore-dbcontext-onmodelcreating(microsoft-entityframeworkcore-modelbuilder)
[22]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbset-1
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Protected method]: ../../icons/protmethod.svg "Protected method"