ApplicationSettings Class
=========================
Contains globally accessable application settings ready from appsettings.json.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Web.ApplicationSettings**  

  **Namespace:**  [GrayDuckMail.Web][2]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public static class ApplicationSettings
```

The **ApplicationSettings** type exposes the following members.


Constructors
------------

|                                   | Name                     | Description |
| --------------------------------- | ------------------------ | ----------- |
| ![Private method]![Static member] | [ApplicationSettings][3] |             |


Properties
----------

|                                    | Name                    | Description                                          |
| ---------------------------------- | ----------------------- | ---------------------------------------------------- |
| ![Public property]![Static member] | [ApplicationVersion][4] | Gets the application version as a string.            |
| ![Public property]![Static member] | [DatabaseFilePath][5]   | Gets or sets the full pathname of the database file. |
| ![Public property]![Static member] | [LogFilePath][6]        | Gets or sets the full pathname of the log file.      |


Fields
------

|                                 | Name                  | Description                             |
| ------------------------------- | --------------------- | --------------------------------------- |
| ![Public field]![Static member] | [DATABASE_PATH][7]    | (Immutable) The database path key name. |
| ![Public field]![Static member] | [LOG_PATH][8]         | (Immutable) The log path key name.      |
| ![Public field]![Static member] | [SECTION_DATABASE][9] | (Immutable) The database section name.  |
| ![Public field]![Static member] | [SECTION_LOG][10]     | (Immutable) The log section name.       |


See Also
--------

#### Reference
[GrayDuckMail.Web Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: ApplicationVersion.md
[5]: DatabaseFilePath.md
[6]: LogFilePath.md
[7]: DATABASE_PATH.md
[8]: LOG_PATH.md
[9]: SECTION_DATABASE.md
[10]: SECTION_LOG.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public field]: ../../icons/pubfield.svg "Public field"