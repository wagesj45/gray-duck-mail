DiscussionListAssignForm.Assignments Property
=============================================
Gets the assignments connecting [contacts][1] to the [discussion list][2].

  **Namespace:**  [GrayDuckMail.Web.Models.Forms][3]  
  **Assembly:** gray-duck-mail-web.exe

Syntax
------

```csharp
public IEnumerable<(int ContactID, bool IsAssigned)> Assignments { get; }
```

#### Property Value
Type: [IEnumerable][4]&lt;[ValueTuple][5]&lt;[Int32][6], [Boolean][7]>>  
 The assignments. 

Remarks
-------
 This is a helper property that processes the string value sent from the HTTP form for [ContactID][1] and [Assigned][8]. This method assumes that the form data is properly formed and the arrays are synced. 

See Also
--------

#### Reference
[DiscussionListAssignForm Class][9]  
[GrayDuckMail.Web.Models.Forms Namespace][3]  
[DiscussionListAssignForm.ContactID][1]  
[DiscussionListAssignForm.Assigned][8]  

[1]: ContactID.md
[2]: DiscussionListID.md
[3]: ../README.md
[4]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[5]: https://docs.microsoft.com/dotnet/api/system.valuetuple-2
[6]: https://docs.microsoft.com/dotnet/api/system.int32
[7]: https://docs.microsoft.com/dotnet/api/system.boolean
[8]: Assigned.md
[9]: README.md