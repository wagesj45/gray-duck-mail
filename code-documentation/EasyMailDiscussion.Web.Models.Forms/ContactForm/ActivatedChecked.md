ContactForm.ActivatedChecked Property
=====================================
Gets a value indicating if the contact's email address has been confirmed.

  **Namespace:**  [EasyMailDiscussion.Web.Models.Forms][1]  
  **Assembly:** easy-mail-discussion-web.exe

Syntax
------

```csharp
public bool ActivatedChecked { get; }
```

#### Property Value
Type: [Boolean][2]  
 True if [Activated][3] is checked, false if not. 

Remarks
-------
 This is a helper property that processes the string value sent from the HTTP form for [Activated][3]. 

See Also
--------

#### Reference
[ContactForm Class][4]  
[EasyMailDiscussion.Web.Models.Forms Namespace][1]  
[Contact.Activated][5]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.boolean
[3]: Activated.md
[4]: README.md
[5]: ../../EasyMailDiscussion.Common.Database/Contact/Activated.md