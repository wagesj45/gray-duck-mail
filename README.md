# ![Gray Duck Logo](/assets/logo-32.png) Gray Duck Mail

Modern group email discussion lists.

---

Gray Duck Mail is an alternative to email discussion group software such as [Mailman](https://docs.mailman3.org/en/latest/) and [Sympa](https://www.sympa.org/) designed to be **easy to set up** and **easy to manage**. Gray Duck Mail monitors a remote mail server for messages and processes them by relaying the message to all list members. Gray Duck Mail also automatically handles user subscriptions, unsubscription requests, and email bounces. Gray Duck Mail works with any external email host that allows for POP3/SMTP connections and message forwarding or aliasing. Gray Duck Mail relies totally on an external mail provider, allowing you to use an existing web host or email account.

Gray Duck Mail is written in C# and is powered by [ASP.NET Core 3.1 MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1).

## Table of Contents

1. [Installation](#installation)
   1. [Tags](#tags)
   2. [Ports](#ports)
   3. [Volumes](#volumes)
   4. [Environment Variables](#environment-variables)
      - [`RATE_LIMIT_PER_ROUND_COUNT`](#rate_limit_per_round_count)
      - [`RATE_LIMIT_ROUND_WAIT_TIME`](#rate_limit_round_wait_time)
      - [`FETCH_TIME`](#fetch_time)
      - [`LOG_LEVEL`](#log_level)
      - [`LANGUAGE`](#language)
      - [`MIN_SEARCH_SCORE`](#min_search_score)
      - [`WEB_ONLY`](#web_only)
      - [`WEB_UNSUBSCRIBE`](#web_unsubscribe)
      - [`WEB_USE_HTTPS`](#web_use_https)
      - [`WEB_EXTERNAL_URL`](#web_external_url)
      - [`WEB_SECRET`](#web_secret)
      - [`ASPNETCORE_URLS`](#aspnetcore_urls)
   5. [Security Considerations](#security-considerations)
2. [Web Interface](#web-interface)
   1. [Settings](#settings)
      1. [Items Per Page](#items-per-page)
      2. [Fuzzy Search](#fuzzy-search)
   2. [Database Import](#database-import)
   3. [Datbase Export](#datbase-export)
3. [Contacts](#contacts)
4. [Discussion Lists](#discussion-lists)
   1. [Configuration](#configuration)
      1. [Base Email Account](#base-email-account)
      2. [Aliases](#aliases)
         - [`request`](#request)
         - [`subscribe`](#subscribe)
         - [`unsubscribe`](#unsubscribe)
         - [`bounce`](#bounce)
         - [`owner`](#owner)

## Installation

Gray Duck Mail is provided as a [docker image](https://hub.docker.com/r/wagesj45/gray-duck-mail).

`docker pull wagesj45/gray-duck-mail`

### Tags

You will find two tags utilized at [Docker Hub](https://hub.docker.com/r/wagesj45/gray-duck-mail): `testing` and `latest`. The `testing` tag is just that; an unstable image used for testing and debugging purposes. Unless you're actively working on development of Gray Duck Mail, only use the `latest` tag when pulling images and creating containers.

### Ports

The docker image requires an HTTP port exposed and mapped to port **80** on the container. An optional port can be exposed and mapped to port **5000** that will accept external unsubscribe requests.

### Volumes

A single volume mounted to `/database` is required. This volume will store the local [SQLite3](https://sqlite.org/index.html) database file is stored. This volume provides non-volitile storage so that data is not lost between docker image upgrades.

### Environment Variables

The docker image exposes the following environment variables that control the system.

#### `RATE_LIMIT_PER_ROUND_COUNT`

The number of emails that can be sent before a defined time-out period. This is useful for email providers that place restrictions on the number of emails that can be sent. The default value is a [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32?view=netcore-3.1) set to `00:05:00`.

#### `RATE_LIMIT_ROUND_WAIT_TIME`

The time between sending groups of emails from the queue. After a given round of emails sent, the system will wait this amount of time before continuing from the email the queue. The default value is a [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=netcore-3.1) set to `00:05:00`.

#### `FETCH_TIME`

The time between fetching email from the remote server. The default value is a [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=netcore-3.1) set to `00:05:00`.

#### `LANGUAGE`

System localization is supported. Language files are stored as `*.resx` files. Although the initial translations were automated, pull requests are accepted for human translations.

The following values are supported:

- `en-US` - English
- `ja-JP` - Japanese
- `es-ES` - Spanish
- `de-DE` - German

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

#### `WEB_UNSUBSCRIBE`

If set, an unsubscribe link will be generated and used in system and relayed messages. If unset, a link to the unsubscribe alias will be generated. The default value is a [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=netcore-3.1) set to `1`.

The following values are supported:

- `True` | `1`
- `False` | `0`

#### `WEB_USE_HTTPS`

If set, the URL generated for a externally accessible unsubscribe link will be generated using `HTTPS`. Otherwise, it will generated using `HTTP`. The default value is a [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=netcore-3.1) set to `1`.

The following values are supported:

- `True` | `1`
- `False` | `0`

#### `WEB_EXTERNAL_URL`

The host name used when generating an externally accessible unsubscribe link. The default value is a [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netcore-3.1) set to `example.com`.

#### `WEB_SECRET`

A unique string used when creating hash codes for the unsubscribe link appended to email messages. This string can be anything you choose. The hash is created by performing a SHA256 hash on the `ContactID`, `DiscussionListID`, and `WEB_SECRET`. This prevents outside actors from brute forcing the unsubscribe link maliciously. There is no default value for the [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netcore-3.1), however if it is not set, the system will set it to the string representation of a random [GUID](https://learn.microsoft.com/en-us/dotnet/api/system.guid?view=netcore-3.1).

#### `ASPNETCORE_URLS`

The URLs monitored by the ASP.Net server runtime. The default value is a [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netcore-3.1) set to `http://+:5000;http://+:80`. You can learn more [here](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/web-host?view=aspnetcore-6.0), but unless you're an advanced user modifying the Gray Duck Mail Docker image, you should leave this value at its default and ensure poth ports **80** and **5000** are configured. When configuring your Docker container, only port **80** is required for normal functioning.

### Security Considerations

Gray Duck Mail segments its web interface between two ports, one internal and one external. The Docker image utilizes port **80** as its designated *internal* point of ingress, and port **5000** as its designated *external* point of ingress. This means that care should be taken to expose only port **5000** of the docker container to the public internet.

Utilizing the external port allows utilization of a "one click" unsubscribe link. The unsubscribe link takes the form of `http[s]://hostname/Unsubscribe/{contactID}/{discussionListID}`. This might look like `https://example.com/Unsubscribe/529/187`, assuming a user with the internal identifier `529` is unsubscribing from discussion list with internal identifier `187`, utilizing `HTTPS` through the hostname `example.com`.

The unsubscribe link is the only externally accessible route in Gray Duck Mail. Attempting to load any other route from port **5000** will result in a [`403 Forbidden`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/403) access error.

Gray Duck Mail should ideally be placed behind a reverse proxy forwarding web traffic **only** to port **5000** (or the port being forwarded to the external ingress port in the Docker container). It is highly recommended to utilize a [reverse proxy such as nginx](https://docs.nginx.com/nginx/admin-guide/web-server/reverse-proxy/) serving [SSL content](https://www.nginx.com/blog/using-free-ssltls-certificates-from-lets-encrypt-with-nginx/). While not recommended, it might be possible to pair the secure ingress port with [HTTP basic authentication](https://docs.nginx.com/nginx/admin-guide/security-controls/configuring-http-basic-authentication/).

Gray Duck Mail stores email login credentials in a local database. These credentials **are not** encrypted. Additionally, the web administration interface has no concept of users or content segmentation beyond its *internal* and *external* designations. This means that anyone with access to the **internal** web interface through port **80** will have access to the login credentials of each email discussion list, as well as the list users' contact information (name and email address) and message archive list (sender and message contents).

The database files used by Gray Duck Mail are not encrypted and store all data in plain text. When making backups of the `/database` docker volume or exporting copies of the database, care should be taken to ensure that file access is restricted.

## Web Interface

Gray Duck Mail provides a web administration interface for basic system interaction. The web interface allows an administrator to create and remove distribution lists, create and remove list contacts, browse message archives, and access basic adminstration actions like [importing](#database-import) and [exporting copies of the local database](#database-export), care should be taken to make sure those files are not accessable to the public.

### Settings

The web adminstration settings control the presentation of data *in* the web interface, so are stored as cookies in the user's browser. These settings have no influence on the system's discussion list email processing functionality.

#### Items Per Page

This setting  controls the number of top level items displayed on a page, such as contacts or archived messages.

#### Fuzzy Search

Searching through contacts and message archives will by default perform exact searches. Results will contain the search term exactly as presented. If enabled, this option will allow the search engine to engage [fuzzy searching](https://en.wikipedia.org/wiki/Fuzzy_logic), using the [Levenshtein distance](https://en.wikipedia.org/wiki/Levenshtein_distance) to find results that closely match a given search term. This can result in better search results, but **is computationally heavy** as all items being searched must be loaded into memory from the database. When searching large message archives or large contact lists, this could result in time-out errors from the web server.

### Database Import

This action allows you to import an existing SQLite3 database file. When importing a database, the web server must restart. You can simply reload the web interface to see the new changes.

### Database Export

This action allows you to export a copy of the SQLite3 database file. This file can be imported into another instance of Gray Duck Mail or viewed in an external application such as [DB Browser for SQLite](https://sqlitebrowser.org/)

## Contacts

Contacts represent individual users that can send and recieve messages to a discussion list. New contacts can be added through the [web interface](#web-interface) or are added automatically when a previously unknown email address sends a message to `request` email alias for a discussion list.

## Discussion Lists

Discussion lists represent a group of contacts that can relay messages to other users via a single designated email address. Limited automated moderation can be performed by sending messages to specific [email aliases](#aliases).

### Configuration

Gray Duck Mail requires an external email account and a few [defined aliases](#aliases) in order to function. A discussion list functions by monitoring a given POP3 email account and processing each email by either relaying it to the discussion list members, or by analyzing a message's MIME headers and performing a moderation task.

#### Base Email Account

The base email account is the actual email account provided to you by an external email provider, such as your [web host](https://www.inmotionhosting.com/).

#### Aliases

In order to process operational emails, Gray Duck Mail expects certain email aliases to be configured. This configuration may be refered to by your email provider as "forwards". These aliases should be structured so that the command name precedes the base email address with a hyphen separating them.

For example: `subscribe-base.email.address@example.com`.

The following email aliases are expected to exist for automatic moderation:

- `request-base.email.address@example.com`
- `subscribe-base.email.address@example.com`
- `unsubscribe-base.email.address@example.com`
- `bounce-base.email.address@example.com`
- `owner-base.email.address@example.com`

##### `request`

The request alias is used to process requests to join a discussion list by new users.

##### `subscribe`

The subscription alias is used by known users who have been invited to participate in a discussion list to confirm their willingness to participate.

##### `unsubscribe`

The unsubscription alias is used by known users who have been invited to participate in a discussion list to revoke their consent to recieve emails associated with a given discussion list.

##### `bounce`

The bounce alias is inserted into the [`return-path`](https://en.wikipedia.org/wiki/Variable_envelope_return_path) MIME header for all system delievered messages. Some email servers rely on this `return-path` value to notify senders of non-deliverable messages or invalid mail boxes.


##### `owner`

The owner alias should forward to a non-discussion-list address, such as the administrators personal email account. The system sends alert messages to this address when external moderation is necessary, such as when a previously unknown user requests access to a discussion list.
