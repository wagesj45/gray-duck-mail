GrayDuckMail.Common Namespace
=============================
A collection of shared classes and structures used across the components that make up the Gray Duck Mail system.


Classes
-------

|                 | Class                    | Description                                                                                |
| --------------- | ------------------------ | ------------------------------------------------------------------------------------------ |
| ![Public class] | [EmailAliasHelper][1]    | A helper class generating alias names based on the [BaseEmailAddress][2].                  |
| ![Public class] | [EmailClientWrapper][3]  | A wrapper that allows for configurable use of either a MailKitPop3Client or an ImapClient. |
| ![Public class] | [EmailDefinition][4]     | Defines an email to be sent.                                                               |
| ![Public class] | [EmailHelper][5]         | A helper class that contains data and methods for manipulating and processing email data.  |
| ![Public class] | [HTMLCleaner][6]         | A helper class for cleaning HTML strings.                                                  |
| ![Public class] | [IndexedMimeMessage][7]  | An indexed MimeMessage.                                                                    |
| ![Public class] | [LINQExtensions][8]      | A helper class containing extensions for [LINQ][9] operations.                             |
| ![Public class] | [NLogConfiguration][10]  | A static class that contains the NLog configuration.                                       |
| ![Public class] | [SearchCache&lt;T>][11]  | A cache of search results.                                                                 |
| ![Public class] | [SearchResult&lt;T>][12] | Encapsulates the result of a search on a given T.                                          |
| ![Public class] | [Tree&lt;T>][13]         | A branching tree structure that can recursively populate child nodes.                      |


Enumerations
------------

|                       | Enumeration               | Description                                                            |
| --------------------- | ------------------------- | ---------------------------------------------------------------------- |
| ![Public enumeration] | [EmailDefinitionType][14] | Values that represent the types of email sent by the system.           |
| ![Public enumeration] | [EmailProtocol][15]       | Values that represent email protocols for the [EmailClientWrapper][3]. |

[1]: EmailAliasHelper/README.md
[2]: ../GrayDuckMail.Common.Database/DiscussionList/BaseEmailAddress.md
[3]: EmailClientWrapper/README.md
[4]: EmailDefinition/README.md
[5]: EmailHelper/README.md
[6]: HTMLCleaner/README.md
[7]: IndexedMimeMessage/README.md
[8]: LINQExtensions/README.md
[9]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[10]: NLogConfiguration/README.md
[11]: SearchCache_1/README.md
[12]: SearchResult_1/README.md
[13]: Tree_1/README.md
[14]: EmailDefinitionType/README.md
[15]: EmailProtocol/README.md
[Public class]: ../icons/pubclass.svg "Public class"
[Public enumeration]: ../icons/pubenumeration.svg "Public enumeration"