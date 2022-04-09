Startup Class
=============
Manages the start up routine for the application.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GrayDuckMail.Web.Startup**  

  **Namespace:**  [GrayDuckMail.Web][2]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class Startup
```

The **Startup** type exposes the following members.


Constructors
------------

|                                   | Name         | Description  |
| --------------------------------- | ------------ | ------------ |
| ![Private method]![Static member] | [Startup][3] |              |
| ![Public method]                  | [Startup][4] | Constructor. |


Properties
----------

|                    | Name               | Description                       |
| ------------------ | ------------------ | --------------------------------- |
| ![Public property] | [Configuration][5] | Gets the configuration interface. |


Methods
-------

|                                   | Name                   | Description                                                                                     |
| --------------------------------- | ---------------------- | ----------------------------------------------------------------------------------------------- |
| ![Public method]                  | [Configure][6]         | This method gets called by the runtime. Use this method to configure the HTTP request pipeline. |
| ![Private method]![Static member] | [ConfigureDatabase][7] | Replaces the existing database file with an imported database file, if one exists.              |
| ![Private method]![Static member] | [ConfigureNLog][8]     | Configures NLog for this application.                                                           |
| ![Public method]                  | [ConfigureServices][9] | This method gets called by the runtime. Use this method to add services to the container.       |


See Also
--------

#### Reference
[GrayDuckMail.Web Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: _cctor.md
[4]: _ctor.md
[5]: Configuration.md
[6]: Configure.md
[7]: ConfigureDatabase.md
[8]: ConfigureNLog.md
[9]: ConfigureServices.md
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"