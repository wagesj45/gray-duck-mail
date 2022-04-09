BaseController.OnActionExecuting Method
=======================================
Called before the action method is invoked.

  **Namespace:**  [GrayDuckMail.Web.Controllers][1]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public virtual void OnActionExecuting(
	ActionExecutingContext context
)
```

#### Parameters

##### *context*
Type: [Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext][2]  
 The action executing context.


Remarks
-------
 This override provides logging on the path being processed by the [HTTP request][3]. 

See Also
--------

#### Reference
[BaseController Class][4]  
[GrayDuckMail.Web.Controllers Namespace][1]  
[Controller.OnActionExecuting(ActionExecutingContext)][5]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.filters.actionexecutingcontext
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httprequest
[4]: README.md
[5]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controller.onactionexecuting#microsoft-aspnetcore-mvc-controller-onactionexecuting(microsoft-aspnetcore-mvc-filters-actionexecutingcontext)