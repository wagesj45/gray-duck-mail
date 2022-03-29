ApplicationSettings Class
=========================
Contains globally accessable application settings ready from appsettings.json.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **EasyMailDiscussion.Web.ApplicationSettings**  

  **Namespace:**  [EasyMailDiscussion.Web][2]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public static class ApplicationSettings
```

The **ApplicationSettings** type exposes the following members.


Properties
----------

|                                    | Name                  | Description                                          |
| ---------------------------------- | --------------------- | ---------------------------------------------------- |
| ![Public property]![Static member] | [DatabaseFilePath][3] | Gets or sets the full pathname of the database file. |
| ![Public property]![Static member] | [LogFilePath][4]      | Gets or sets the full pathname of the log file.      |


Fields
------

|                                 | Name                  | Description                             |
| ------------------------------- | --------------------- | --------------------------------------- |
| ![Public field]![Static member] | [DATABASE_PATH][5]    | (Immutable) The database path key name. |
| ![Public field]![Static member] | [LOG_PATH][6]         | (Immutable) The log path key name.      |
| ![Public field]![Static member] | [SECTION_DATABASE][7] | (Immutable) The database section name.  |
| ![Public field]![Static member] | [SECTION_LOG][8]      | (Immutable) The log section name.       |


See Also
--------

#### Reference
[EasyMailDiscussion.Web Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: DatabaseFilePath.md
[4]: LogFilePath.md
[5]: DATABASE_PATH.md
[6]: LOG_PATH.md
[7]: SECTION_DATABASE.md
[8]: SECTION_LOG.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Static member]: ../../icons/static.gif "Static member"
[Public field]: ../../icons/pubfield.svg "Public field"