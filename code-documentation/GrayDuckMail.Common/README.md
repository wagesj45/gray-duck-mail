GrayDuckMail.Common Namespace
=============================
A collection of shared classes and structures used across the components that make up the Gray Duck Mail system.


Classes
-------

|                 | Class                      | Description                                                                                |
| --------------- | -------------------------- | ------------------------------------------------------------------------------------------ |
| ![Public class] | [EmailAliasHelper][1]      | A helper class generating alias names based on the [BaseEmailAddress][2].                  |
| ![Public class] | [EmailClientWrapper][3]    | A wrapper that allows for configurable use of either a MailKitPop3Client or an ImapClient. |
| ![Public class] | [EmailDefinition][4]       | Defines an email to be sent.                                                               |
| ![Public class] | [EmailHelper][5]           | A helper class that contains data and methods for manipulating and processing email data.  |
| ![Public class] | [EnumerationExtensions][6] | An enumeration extensions.                                                                 |
| ![Public class] | [EnumerationHelper][7]     | A class that contains methods for managing [Enum][8] objects.                              |
| ![Public class] | [HTMLCleaner][9]           | A helper class for cleaning HTML strings.                                                  |
| ![Public class] | [IndexedMimeMessage][10]   | An indexed MimeMessage.                                                                    |
| ![Public class] | [LINQExtensions][11]       | A helper class containing extensions for [LINQ][12] operations.                            |
| ![Public class] | [NLogConfiguration][13]    | A static class that contains the NLog configuration.                                       |
| ![Public class] | [SearchCache&lt;T>][14]    | A cache of search results.                                                                 |
| ![Public class] | [SearchResult&lt;T>][15]   | Encapsulates the result of a search on a given T.                                          |
| ![Public class] | [Tree&lt;T>][16]           | A branching tree structure that can recursively populate child nodes.                      |


Enumerations
------------

|                       | Enumeration               | Description                                                            |
| --------------------- | ------------------------- | ---------------------------------------------------------------------- |
| ![Public enumeration] | [EmailDefinitionType][17] | Values that represent the types of email sent by the system.           |
| ![Public enumeration] | [EmailProtocol][18]       | Values that represent email protocols for the [EmailClientWrapper][3]. |

[1]: EmailAliasHelper/README.md
[2]: ../GrayDuckMail.Common.Database/DiscussionList/BaseEmailAddress.md
[3]: EmailClientWrapper/README.md
[4]: EmailDefinition/README.md
[5]: EmailHelper/README.md
[6]: EnumerationExtensions/README.md
[7]: EnumerationHelper/README.md
[8]: https://learn.microsoft.com/dotnet/api/system.enum
[9]: HTMLCleaner/README.md
[10]: IndexedMimeMessage/README.md
[11]: LINQExtensions/README.md
[12]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[13]: NLogConfiguration/README.md
[14]: SearchCache_1/README.md
[15]: SearchResult_1/README.md
[16]: Tree_1/README.md
[17]: EmailDefinitionType/README.md
[18]: EmailProtocol/README.md
[Public class]: ../icons/pubclass.svg "Public class"
[Public enumeration]: ../icons/pubenumeration.svg "Public enumeration"