# Gray Duck Mail

Modern group email discussion lists.

---

Gray Duck Mail is an alternative to email discussion group software such as [Mailman](https://docs.mailman3.org/en/latest/) and [Sympa](https://www.sympa.org/). Gray Duck Mail monitors a remote mail server for messages and processes them by relaying the message to all list members. Gray Duck Mail also automatically handles user subscriptions, unsubscription requests, and email bounces. Gray Duck Mail works with any external email host that allows for POP3/SMTP connections and message forwarding or aliasing.

Gray Duck Mail is written in C# and is powered by [ASP.NET Core 3.1 MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1).

## Installation

Gray Duck Mail is provided as a [docker image](https://hub.docker.com/r/wagesj45/gray-duck-mail).

`docker pull wagesj45/gray-duck-mail`

### Ports

The docker image requires an HTTP port exposed and mapped to port **80** on the container.

### Volumes

A single volume mounted to `/databases` is required. This volume will store the local [SQLite3](https://sqlite.org/index.html) database file is stored. This volume provides non-volitile storage so that data is not lost between docker image upgrades.

### Environment Variables

The docker image exposes the following environment variables that control the system.

#### `FETCH_TIME`

The time between fetching email from the remote server. The default value is a [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=netcore-3.1) set to `00:05:00`.

#### `LOG_LEVEL`

The verbosity level with which to log application events. The default value is a [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netcore-3.1) set to `info`.

The folowing values are supoorted:

- `trace` | `all`
- `debug` | `verbose`
- `info` | `information`
- `warn` | `warning`
- `err` | `error`
- `fatal`

#### `MIN_SEARCH_SCORE`

The minimum viable search score when performing [fuzzy searches](#Fuzzy-Search). The default value is a [System.Single (float)](https://docs.microsoft.com/en-us/dotnet/api/system.single?view=netcore-3.1) set to `0.2`. When using [fuzzy searches](#Fuzzy-Search) fractional scores between `1` and `0` are generated. Results approach zero as search results stray from an exact match.

#### `WEB_ONLY`

If set, only the web interface will be initialized. [Background worker threads](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1&tabs=visual-studio) will not be initialized. This is useful for running the web administration interface without the rick of background service workers modifying the remote mail server. The default value is a [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=netcore-3.1) set to `0`.

The following values are supported:

- `True` | `1`
- `False` | `0`

## Security Considerations

Gray Duck Mail stores email login credentials in a local database. These credentials **are not** encrypted. Additionally, the web administration interface has no concept of users or user segmentation. This means that anyone with access to the web interface will have access to the login credentials of each email discussion list, as well as the list users' contact information (name and email address) and message archive list (sender and message contents).

Gray Duck Mail should ideally be placed behind a firewall with no external HTTP access. If exposed to the public internet, Gray Duck Mail should be served behind a [reverse proxy](https://docs.nginx.com/nginx/admin-guide/web-server/reverse-proxy/) serving [SSL content](https://www.nginx.com/blog/using-free-ssltls-certificates-from-lets-encrypt-with-nginx/) paired with [HTTP basic authentication](https://docs.nginx.com/nginx/admin-guide/security-controls/configuring-http-basic-authentication/).

## Web Interface

Gray Duck Mail provides a web administration interface for basic system interaction. The web interface allows an administrator to create and remove distribution lists, create and remove list contacts, browse message archives, and access basic adminstration actions like importing and exporting copies of the local database.

### Settings

The web adminstration settings control the presentation of data *in* the web interface, so are stored as cookies in the user's browser. These settings have no influence on the system's discussion list email processing functionality.

#### Items Per Page

This setting  controls the number of top level items displayed on a page, such as contacts or archived messages.

#### Fuzzy Search

Searching through contacts and message archives will by default perform exact searches. Results will contain the search term exactly as presented. If enabled, this option will allow the search engine to engage [fuzzy searching](https://en.wikipedia.org/wiki/Fuzzy_logic), using the [Levenshtein distance](https://en.wikipedia.org/wiki/Levenshtein_distance) to find results that closely match a given search term. This can result in better search results, but **is computationally heavy** as all items being searched must be loaded into memory from the database. When searching large message archives or large contact lists, this could result in time-out errors from the web server.