EmailHelper.DefaultEmailTemplate Property
=========================================
Gets the default HTML email template.

  **Namespace:**  [GrayDuckMail.Common][1]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static string DefaultEmailTemplate { get; }
```

#### Property Value
Type: [String][2]  
 The mail email template. 

Remarks
-------

This email template contains several replaceable notaions: `{header}`, `{subheader}`, `{body}`, and `{footer}`. The `{unsubscribe}` notation should always be a link to the [unsubscribe email alias][3].

This file is read into memory upon its first access.


See Also
--------

#### Reference
[EmailHelper Class][4]  
[GrayDuckMail.Common Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: ../EmailAliasHelper/GetUnsubscribeAlias.md
[4]: README.md