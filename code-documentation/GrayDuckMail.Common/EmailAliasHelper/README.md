EmailAliasHelper Class
======================
A helper class generating alias names based on the [BaseEmailAddress][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GrayDuckMail.Common.EmailAliasHelper**  

  **Namespace:**  [GrayDuckMail.Common][3]  
  **Assembly:** gray-duck-mail-common.dll

Syntax
------

```csharp
public static class EmailAliasHelper
```


Methods
-------

|                                  | Name                                      | Description                                       |
| -------------------------------- | ----------------------------------------- | ------------------------------------------------- |
| ![Public method]![Static member] | [GetBounceAlias(DiscussionList)][4]       | Gets the bounce address alias.                    |
| ![Public method]![Static member] | [GetBounceAlias(String)][5]               | Gets the bounce address alias.                    |
| ![Public method]![Static member] | [GetOwnerAlias(DiscussionList)][6]        | Gets the owner address alias.                     |
| ![Public method]![Static member] | [GetOwnerAlias(String)][7]                | Gets the owner address alias.                     |
| ![Public method]![Static member] | [GetRequestAlias(DiscussionList)][8]      | Gets the request address alias.                   |
| ![Public method]![Static member] | [GetRequestAlias(String)][9]              | Gets the request address alias.                   |
| ![Public method]![Static member] | [GetSubscribeAlias(DiscussionList)][10]   | Gets the subscription confirmation address alias. |
| ![Public method]![Static member] | [GetSubscribeAlias(String)][11]           | Gets the subscription confirmation address alias. |
| ![Public method]![Static member] | [GetUnsubscribeAlias(DiscussionList)][12] | Gets the unsubscribe confirmation address alias.  |
| ![Public method]![Static member] | [GetUnsubscribeAlias(String)][13]         | Gets the unsubscribe confirmation address alias.  |


Remarks
-------
 The aliases described by this class are required for functional emails processed by the system. 

See Also
--------

#### Reference
[GrayDuckMail.Common Namespace][3]  

[1]: ../../GrayDuckMail.Common.Database/DiscussionList/BaseEmailAddress.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../README.md
[4]: GetBounceAlias.md
[5]: GetBounceAlias_1.md
[6]: GetOwnerAlias.md
[7]: GetOwnerAlias_1.md
[8]: GetRequestAlias.md
[9]: GetRequestAlias_1.md
[10]: GetSubscribeAlias.md
[11]: GetSubscribeAlias_1.md
[12]: GetUnsubscribeAlias.md
[13]: GetUnsubscribeAlias_1.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/static.gif "Static member"