GrayDuckMail.Common.Database Namespace
======================================

[Missing &lt;summary> documentation for "N:GrayDuckMail.Common.Database"]



Classes
-------

|                 | Class                    | Description                                                                                                                                                                                                                                           |
| --------------- | ------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public class] | [Contact][1]             | A database table that stores information on individual people that can be assigned to a [DiscussionList][2].                                                                                                                                          |
| ![Public class] | [ContactSubscription][3] | A database table that stores subscription information linking a [Contact][4] to a [DiscussionList][5].                                                                                                                                                |
| ![Public class] | [DiscussionList][2]      | A database table that stores information describing an email discussion and distribution list.                                                                                                                                                        |
| ![Public class] | [Message][6]             | A database table that .                                                                                                                                                                                                                               |
| ![Public class] | [RelayIdentifier][7]     | A database storing information on the [EmailID][8] of messages that were relayed to members of a [DiscussionList][2].                                                                                                                                 |
| ![Public class] | [SqliteDatabase][9]      | The SQLite database is defined and managed by this class. This uses [Entity Framework Code First][10] method for defining a database and uses [SQLite][11] to store data in a local database file, without the need for any external database system. |


Enumerations
------------

|                       | Enumeration              | Description                                                                  |
| --------------------- | ------------------------ | ---------------------------------------------------------------------------- |
| ![Public enumeration] | [SubscriptionStatus][12] | Values that represent subscription status of a contact in a discussion list. |

[1]: Contact/README.md
[2]: DiscussionList/README.md
[3]: ContactSubscription/README.md
[4]: ContactSubscription/Contact.md
[5]: ContactSubscription/DiscussionList.md
[6]: Message/README.md
[7]: RelayIdentifier/README.md
[8]: Message/EmailID.md
[9]: SqliteDatabase/README.md
[10]: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
[11]: https://sqlite.org/index.html
[12]: SubscriptionStatus/README.md
[Public class]: ../icons/pubclass.svg "Public class"
[Public enumeration]: ../icons/pubenumeration.svg "Public enumeration"