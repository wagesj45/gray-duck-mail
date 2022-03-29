SqliteDatabase.OnConfiguring Method
===================================
Executing when configuring the model.

  **Namespace:**  [EasyMailDiscussion.Common.Database][1]  
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
Type: [DbContextOptionsBuilder][2]  
 A builder used to create or modify options for this context. Databases (and other extensions) typically define extension methods on this object that allow you to configure the context.


See Also
--------

#### Reference
[SqliteDatabase Class][3]  
[EasyMailDiscussion.Common.Database Namespace][1]  
[DbContext.OnConfiguring(DbContextOptionsBuilder)][4]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder
[3]: README.md
[4]: https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext.onconfiguring#microsoft-entityframeworkcore-dbcontext-onconfiguring(microsoft-entityframeworkcore-dbcontextoptionsbuilder)