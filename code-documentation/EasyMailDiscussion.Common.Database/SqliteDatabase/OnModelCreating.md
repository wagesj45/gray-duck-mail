SqliteDatabase.OnModelCreating Method
=====================================
Override this method to further configure the model that was discovered by convention from the entity types exposed in [DbSet][1] properties on your derived context. The resulting model may be cached and re-used for subsequent instances of your derived context.

  **Namespace:**  [EasyMailDiscussion.Common.Database][2]  
  **Assembly:** easy-mail-discussion-common.dll

Syntax
------

```csharp
protected override void OnModelCreating(
	ModelBuilder modelBuilder
)
```

#### Parameters

##### *modelBuilder*
Type: [ModelBuilder][3]  
 The builder being used to construct the model for this context. Databases (and other extensions) typically define extension methods on this object that allow you to configure aspects of the model that are specific to a given database.


Remarks
-------
 If a model is explicitly set on the options for this context (via [M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)][4]) then this method will not be run. 

See Also
--------

#### Reference
[SqliteDatabase Class][5]  
[EasyMailDiscussion.Common.Database Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbset-1
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.modelbuilder
[4]: M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)
[5]: README.md