# ![Gray Duck Logo](/assets/logo-32.png) Gray Duck Mail

Modern group email discussion lists.

---

Gray Duck Mail is an alternative to email discussion group software such as [Mailman](https://docs.mailman3.org/en/latest/) and [Sympa](https://www.sympa.org/) designed to be **easy to set up** and **easy to manage**. Gray Duck Mail monitors a remote mail server for messages and processes them by relaying the message to all list members. Gray Duck Mail also automatically handles user subscriptions, unsubscription requests, and email bounces. Gray Duck Mail works with any external email host that allows for POP3/SMTP connections and message forwarding or aliasing.

Gray Duck Mail is written in C# and is powered by [ASP.NET Core 3.1 MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1).

## Table of Contents

1. [Installation](#installation)
   1. [Ports](#ports)
   2. [Volumes](#volumes)
   3. [Environment Variables](#environment-variables)
      - [`FETCH_TIME`](#fetch_time)
      - [`LOG_LEVEL`](#log_level)
      - [`MIN_SEARCH_SCORE`](#min_search_score)
      - [`WEB_ONLY`](#web_only)
   4. [Security Considerations](#security-considerations)
2. [Web Interface](#web-interface)
   1. [Settings](#settings)
      - [Items Per Page](#items-per-page)
      - [Fuzzy Search](#fuzzy-search)
      - [Theme](#theme)
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

### Ports

The docker image requires an HTTP port exposed and mapped to port **80** on the container.

### Volumes

A single volume mounted to `/database` is required. This volume will store the local [SQLite3](https://sqlite.org/index.html) database file is stored. This volume provides non-volitile storage so that data is not lost between docker image upgrades.

### Environment Variables

The docker image exposes the following environment variables that control the system.

#### `FETCH_TIME`

The time between fetching email from the remote server. The default value is a [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=netcore-3.1) set to `00:05:00`.

#### `LOG_LEVEL`

The verbosity level with which to log application events. The default value is a [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netcore-3.1) set to `info`.

The folowing values are supoorted:

- `trace`, `all`
- `debug`, `verbose`
- `info`, `information`
- `warn`, `warning`
- `err`, `error`
- `fatal`

#### `MIN_SEARCH_SCORE`

The minimum viable search score when performing [fuzzy searches](#Fuzzy-Search). The default value is a [System.Single (float)](https://docs.microsoft.com/en-us/dotnet/api/system.single?view=netcore-3.1) set to `0.2`. When using [fuzzy searches](#Fuzzy-Search) fractional scores between `1` and `0` are generated. Results approach zero as search results stray from an exact match.

#### `WEB_ONLY`

If set, only the web interface will be initialized. [Background worker threads](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1&tabs=visual-studio) will not be initialized. This is useful for running the web administration interface without the risk of background service workers modifying the remote mail server. The default value is a [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=netcore-3.1) set to `0`.

The following values are supported:

- `True`, `1`
- `False`, `0`

### Security Considerations

Gray Duck Mail stores email login credentials in a local database. These credentials **are not** encrypted. Additionally, the web administration interface has no concept of users or content segmentation. This means that anyone with access to the web interface will have access to the login credentials of each email discussion list, as well as the list users' contact information (name and email address) and message archive list (sender and message content).

Gray Duck Mail should ideally be placed behind a firewall with no external HTTP access. If exposed to the public internet, Gray Duck Mail should be served behind a [reverse proxy](https://docs.nginx.com/nginx/admin-guide/web-server/reverse-proxy/) serving [SSL content](https://www.nginx.com/blog/using-free-ssltls-certificates-from-lets-encrypt-with-nginx/) paired with [HTTP basic authentication](https://docs.nginx.com/nginx/admin-guide/security-controls/configuring-http-basic-authentication/).

The database files used by Gray Duck Mail are not encrypted and store all data in plain text. When making backups of the `/database` docker volume or exporting copies of the database, care should be taken to ensure that file access is restricted.

## Web Interface

Gray Duck Mail provides a web administration interface for basic system interaction. The web interface allows an administrator to create and remove distribution lists, create and remove list contacts, browse message archives, and access basic adminstration actions like [importing](#database-import) and [exporting](#database-export) copies of the local database.

### Settings

The web adminstration settings control the presentation of data *in* the web interface, so are stored as cookies in the user's browser. These settings have no influence on the system's discussion list email processing functionality.

#### Items Per Page

This setting controls the number of top level items displayed on a page, such as contacts or archived messages.

#### Fuzzy Search

Searching through contacts and message archives will by default perform exact searches. Results will contain the search term exactly as presented. If enabled, this option will allow the search engine to engage [fuzzy searching](https://en.wikipedia.org/wiki/Fuzzy_logic), using the [Levenshtein distance](https://en.wikipedia.org/wiki/Levenshtein_distance) to find results that closely match a given search term. This can result in better search results, but **is computationally heavy** as all items being searched must be loaded into memory from the database. When searching large message archives or large contact lists, this could result in time-out errors from the web server.

#### Theme

Allows a user to manually select either the `Light` theme for the web interface or the `Dark` theme. [Pico.css](https://picocss.com) will attempt to automatically choose the theme that matches the device theme.

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

## Contributing

Contibutions are welcome. The code is fully documented (via [Sandcastle project](/gray-duck-mail/sandcastle-documentation-project/README.md)) and can be [viewed in browser](/gray-duck-mail/code-documentation/README.md).

## Support

If you find this project useful, please consider [supporting me](https://support.jordanwages.com/). You can also donate using [PayPal](https://paypal.me/wagesj45).