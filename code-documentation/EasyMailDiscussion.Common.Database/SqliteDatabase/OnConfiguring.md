SqliteDatabase.OnConfiguring Method
===================================

Override this method to configure the database (and other options) to be used for this context. This method is called for each instance of the context that is created. The base implementation does nothing.

In situations where an instance of [DbContextOptions][1] may or may not have been passed to the constructor, you can use [IsConfigured()][2] to determine if the options have already been set, and skip some or all of the logic in [OnConfiguring(DbContextOptionsBuilder)][3].


  **Namespace:**  [EasyMailDiscussion.Common.Database][4]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
protected override void OnConfiguring(
	DbContextOptionsBuilder optionsBuilder
)
```

#### Parameters

##### *optionsBuilder*
Type: [DbContextOptionsBuilder][5]  
 A builder used to create or modify options for this context. Databases (and other extensions) typically define extension methods on this object that allow you to configure the context.


See Also
--------

#### Reference
[SqliteDatabase Class][6]  
[EasyMailDiscussion.Common.Database Namespace][4]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontextoptions
[2]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder.isconfigured#microsoft-entityframeworkcore-dbcontextoptionsbuilder-isconfigured
[3]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext.onconfiguring#microsoft-entityframeworkcore-dbcontext-onconfiguring(microsoft-entityframeworkcore-dbcontextoptionsbuilder)
[4]: ../README.md
[5]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder
[6]: README.md