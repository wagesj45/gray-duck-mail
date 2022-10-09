GrayDuckMail.Common Namespace
=============================
A collection of shared classes and structures used across the components that make up the Gray Duck Mail system.


Classes
-------

|                 | Class                    | Description                                                                               |
| --------------- | ------------------------ | ----------------------------------------------------------------------------------------- |
| ![Public class] | [EmailAliasHelper][1]    | A helper class generating alias names based on the [BaseEmailAddress][2].                 |
| ![Public class] | [EmailDefinition][3]     | Defines an email to be sent.                                                              |
| ![Public class] | [EmailHelper][4]         | A helper class that contains data and methods for manipulating and processing email data. |
| ![Public class] | [HTMLCleaner][5]         | A helper class for cleaning HTML strings.                                                 |
| ![Public class] | [IndexedMimeMessage][6]  | An indexed MimeMessage.                                                                   |
| ![Public class] | [LINQExtensions][7]      | A helper class containing extensions for [LINQ][8] operations.                            |
| ![Public class] | [NLogConfiguration][9]   | A static class that contains the NLog configuration.                                      |
| ![Public class] | [SearchCache&lt;T>][10]  | A cache of search results.                                                                |
| ![Public class] | [SearchResult&lt;T>][11] | Encapsulates the result of a search on a given T.                                         |
| ![Public class] | [Tree&lt;T>][12]         | A branching tree structure that can recursively populate child nodes.                     |


Enumerations
------------

|                       | Enumeration               | Description                                                  |
| --------------------- | ------------------------- | ------------------------------------------------------------ |
| ![Public enumeration] | [EmailDefinitionType][13] | Values that represent the types of email sent by the system. |

[1]: EmailAliasHelper/README.md
[2]: ../GrayDuckMail.Common.Database/DiscussionList/BaseEmailAddress.md
[3]: EmailDefinition/README.md
[4]: EmailHelper/README.md
[5]: HTMLCleaner/README.md
[6]: IndexedMimeMessage/README.md
[7]: LINQExtensions/README.md
[8]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[9]: NLogConfiguration/README.md
[10]: SearchCache_1/README.md
[11]: SearchResult_1/README.md
[12]: Tree_1/README.md
[13]: EmailDefinitionType/README.md
[Public class]: ../icons/pubclass.svg "Public class"
[Public enumeration]: ../icons/pubenumeration.svg "Public enumeration"