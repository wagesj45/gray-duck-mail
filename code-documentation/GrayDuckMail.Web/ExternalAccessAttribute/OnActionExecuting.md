ExternalAccessAttribute.OnActionExecuting Method
================================================
Called before the action method is invoked.

  **Namespace:**  [GrayDuckMail.Web][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public virtual void OnActionExecuting(
	ActionExecutingContext filterContext
)
```

#### Parameters

##### *filterContext*
Type: [Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext][2]  
 Context for the filter.


Remarks
-------
 Logs executing actions that are decorated with this attribute. 

See Also
--------

#### Reference
[ExternalAccessAttribute Class][3]  
[GrayDuckMail.Web Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.filters.actionexecutingcontext
[3]: README.md