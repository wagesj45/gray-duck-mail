SqliteDatabase.OnModelCreating Method
=====================================
Executed when creating the model.

  **Namespace:**  [GrayDuckMail.Common.Database][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
protected override void OnModelCreating(
	ModelBuilder modelBuilder
)
```

#### Parameters

##### *modelBuilder*
Type: [ModelBuilder][2]  
 The builder being used to construct the model for this context. Databases (and other extensions) typically define extension methods on this object that allow you to configure aspects of the model that are specific to a given database.


See Also
--------

#### Reference
[SqliteDatabase Class][3]  
[GrayDuckMail.Common.Database Namespace][1]  
[DbContext.OnModelCreating(ModelBuilder)][4]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.modelbuilder
[3]: README.md
[4]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext.onmodelcreating#microsoft-entityframeworkcore-dbcontext-onmodelcreating(microsoft-entityframeworkcore-modelbuilder)