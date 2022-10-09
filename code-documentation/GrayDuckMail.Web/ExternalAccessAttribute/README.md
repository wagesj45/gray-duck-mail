ExternalAccessAttribute Class
=============================
Attribute for declaring a controller route method as accessable externally.


Inheritance Hierarchy
---------------------
[Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute][1]  
  **GrayDuckMail.Web.ExternalAccessAttribute**  

  **Namespace:**  [GrayDuckMail.Web][2]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public class ExternalAccessAttribute : ActionFilterAttribute
```

The **ExternalAccessAttribute** type exposes the following members.


Constructors
------------

|                                   | Name                         | Description                                                         |
| --------------------------------- | ---------------------------- | ------------------------------------------------------------------- |
| ![Private method]![Static member] | [ExternalAccessAttribute][3] |                                                                     |
| ![Public method]                  | [ExternalAccessAttribute][4] | Initializes a new instance of the **ExternalAccessAttribute** class |


Methods
-------

|                  | Name                   | Description                                 |
| ---------------- | ---------------------- | ------------------------------------------- |
| ![Public method] | [OnActionExecuting][5] | Called before the action method is invoked. |


See Also
--------

#### Reference
[GrayDuckMail.Web Namespace][2]  
BaseController.INTERNAL_PORT  
BaseController.EXTERNAL_PORT  

#### Other Resources
[http://grayduckmail.com/security.html][6]  

[1]: https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.filters.actionfilterattribute
[2]: ../README.md
[3]: _cctor.md
[4]: _ctor.md
[5]: OnActionExecuting.md
[6]: http://grayduckmail.com/security.html
[Private method]: ../../icons/privmethod.gif "Private method"
[Static member]: ../../icons/static.gif "Static member"
[Public method]: ../../icons/pubmethod.svg "Public method"