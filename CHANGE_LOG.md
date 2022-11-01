#Change Log

This file lists major changes between releases in [Gray Duck Mail](https://grayduckmail.com).

## Version 0.9.9

* IMAP Support (#3)
* Added `EMAIL_PROTOCOL` and `IMAP_FOLDER` Docker Environment Variables
* Fixed a bug in the auto-generated footer
* Fixed a bug in the startup sequence

## Version 0.9.8

* Public Unsubscription Links
* Rate Limiting Outgoing Mail
* Administration Page Enhancements
* Added `RATE_LIMIT_PER_ROUND_COUNT`, `RATE_LIMIT_ROUND_WAIT_TIME`, `WEB_UNSUBSCRIBE`, `WEB_USE_HTTPS`, and `WEB_EXTERNAL_URL` Docker Environment Variables
* Changed `ASPNETCORE_URLS` Docker Environment Variable
* Bug Fixes

### Breaking Changes

There is a **breaking change** in this release. This version introduces "one click" unsubscribe links. This feature requires an externally facing port to be served. For security, a designated port is monitored for these unsubscribe "one click" links. This new port requires a change to the `ASPNETCORE_URLS` Docker environment variable. For more information, see the [installation guide](https://grayduckmail.com/installation.html) and [security considerations](https://grayduckmail.com/security.html).