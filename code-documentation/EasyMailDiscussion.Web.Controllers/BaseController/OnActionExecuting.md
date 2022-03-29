BaseController.OnActionExecuting Method
=======================================
Called before the action method is invoked.

  **Namespace:**  [EasyMailDiscussion.Web.Controllers][1]  
  **Assembly:** easy-mail-discussion-web.exe

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
[EasyMailDiscussion.Web.Controllers Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.filters.actionexecutingcontext
[3]: https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httprequest
[4]: README.md