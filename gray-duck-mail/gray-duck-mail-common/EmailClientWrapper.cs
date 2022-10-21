using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MimeKit;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GrayDuckMail.Common
{
    /// <summary>
    /// A wrapper that allows for configurable use of either a <see cref="MailKit"/> <see cref="Pop3Client"/> or an <see cref="ImapClient"/>.
    /// </summary>
    /// <seealso cref="Pop3Client"/>
    /// <seealso cref="ImapClient"/>
    public class EmailClientWrapper : IDisposable
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary> Type of the email client the wrapper represents. </summary>
        private EmailProtocol emailClientType;

        /// <summary> The POP3 client. </summary>
        private Pop3Client pop3Client;

        /// <summary> The IMAP client. </summary>
        private ImapClient imapClient;

        /// <summary> Pathname of the IMAP folder. </summary>
        private string imapFolderName;

        #endregion

        #region Constructor

        /// <summary> Constructor. </summary>
        /// <param name="emailClientType"> Type of the email client the wrapper represents. </param>
        /// <param name="imapFolderName">
        ///     (Optional) Pathname of the IMAP folder if the <paramref name="emailClientType"/> is set
        ///     to <see cref="EmailProtocol.IMAP"/>.
        /// </param>
        public EmailClientWrapper(EmailProtocol emailClientType, string imapFolderName = default)
        {
            logger.Debug("Creating email wrapper object.");

            this.emailClientType = emailClientType;
            this.imapFolderName = imapFolderName;
        }

        #endregion

        #region Properties

        /// <summary> Gets the type of the email client the wrapper represents. </summary>
        /// <value> The type of the email client. </value>
        public EmailProtocol EmailClientType
        {
            get
            {
                return emailClientType;
            }
        }

        /// <summary> Gets the POP3 client. </summary>
        /// <value> The pop 3 client. </value>
        /// <remarks> If the client is not yet initialized, it will be. </remarks>
        private Pop3Client POP3Client
        {
            get
            {
                if (this.pop3Client == null)
                {
                    this.pop3Client = new Pop3Client();
                }

                return this.pop3Client;
            }
        }

        /// <summary> Gets the IMAP client. </summary>
        /// <value> The IMAP client. </value>
        /// <remarks> If the client is not yet initialized, it will be. </remarks>
        private ImapClient IMAPClient
        {
            get
            {
                if (this.imapClient == null)
                {
                    this.imapClient = new ImapClient();
                }

                return this.imapClient;
            }
        }

        #endregion

        #region Methods

        /// <summary> Performs the client method <see cref="Action"/>. </summary>
        /// <param name="pop3Method"> The pop 3 method. </param>
        /// <param name="imapMethod"> The IMAP method. </param>
        /// <seealso cref="Action"/>
        private void PerformClientMethod(Action<Pop3Client> pop3Method, Action<ImapClient, IMailFolder> imapMethod)
        {
            switch (this.emailClientType)
            {
                case EmailProtocol.POP3:
                    logger.Debug("Using POP3 client.");
                    pop3Method(this.POP3Client);
                    break;
                case EmailProtocol.IMAP:
                    logger.Debug("Using IMAP client.");
                    var folder = default(IMailFolder);
                    if(this.IMAPClient.IsConnected && this.IMAPClient.IsAuthenticated)
                    {
                        folder = this.IMAPClient.GetFolder(this.imapFolderName);
                        folder.Open(FolderAccess.ReadWrite);
                    }
                    imapMethod(this.IMAPClient, folder);
                    if (folder != default(IMailFolder) && folder.IsOpen)
                    {
                        // We check in case the client disconnects.
                        folder.Close(true);
                    }
                    break;
                case EmailProtocol.Unknown:
                default:
                    logger.Error("An unknown client type was requested.");
                    break;
            }
        }

        /// <summary> Performs the client method <see cref="Func{T, TResult}"/>. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="pop3Method"> The pop 3 method. </param>
        /// <param name="imapMethod"> The IMAP method. </param>
        /// <returns> A <typeparamref name="T"/> object. </returns>
        private T PerformClientMethod<T>(Func<Pop3Client, T> pop3Method, Func<ImapClient, IMailFolder, T> imapMethod)
        {
            switch (this.emailClientType)
            {
                case EmailProtocol.POP3:
                    logger.Debug("Using POP3 client.");
                    return pop3Method(this.POP3Client);
                case EmailProtocol.IMAP:
                    logger.Debug("Using IMAP client.");
                    var folder = default(IMailFolder);
                    if (this.IMAPClient.IsConnected && this.IMAPClient.IsAuthenticated)
                    {
                        folder = this.IMAPClient.GetFolder(this.imapFolderName);
                        folder.Open(FolderAccess.ReadWrite);
                    }
                    var result = imapMethod(this.IMAPClient, folder);
                    if (folder != default(IMailFolder) && folder.IsOpen)
                    {
                        // We check in case the client disconnects.
                        folder.Close(true);
                    }
                    return result;
                case EmailProtocol.Unknown:
                default:
                    logger.Error("An unknown client type was requested.");
                    break;
            }

            return default(T);
        }

        /// <summary> Establish a connection to the specified mail server. </summary>
        /// <param name="host">              The host. </param>
        /// <param name="port">              The port. </param>
        /// <param name="useSSL">            True to use ssl. </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        public void Connect(string host, int port, bool useSSL, CancellationToken cancellationToken = default)
        {
            logger.Debug("Connecting to {0}:{1}.", host, port);

            PerformClientMethod(
                pop3Client => pop3Client.Connect(host, port, useSSL, cancellationToken: cancellationToken),
                (imapClient, imapFolder) => imapClient.Connect(host, port, useSSL, cancellationToken: cancellationToken)
                );
        }

        /// <summary> Authenticate using the specified SASL method. </summary>
        /// <param name="userName">          Name of the user. </param>
        /// <param name="password">          The password. </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        public void Authenticate(string userName, string password, CancellationToken cancellationToken = default)
        {
            logger.Debug("Authenticating with {0}:{1}.", userName, password);

            PerformClientMethod(
                pop3Client => pop3Client.Authenticate(userName, password, cancellationToken: cancellationToken),
                (imapClient, imapFolder) => imapClient.Authenticate(userName, password, cancellationToken: cancellationToken)
                );
        }

        /// <summary> Gets all messages. </summary>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        /// <returns> The messages. </returns>
        public IList<MimeMessage> GetMessages(CancellationToken cancellationToken = default)
        {
            logger.Debug("Getting messages.");

            return PerformClientMethod(
            pop3Client =>
            {
                if(pop3Client.Count > 0)
                {
                    var messages = pop3Client.GetMessages(0, pop3Client.Count, cancellationToken: cancellationToken);
                    return messages;
                }

                return Enumerable.Empty<MimeMessage>().ToList();
            },
            (imapClient, imapFolder) =>
            {
                if(imapFolder.Count > 0)
                {
                    var messages = Enumerable.Range(0, imapFolder.Count).Select(i => imapFolder.GetMessage(i)).ToList();
                    return messages;
                }

                return Enumerable.Empty<MimeMessage>().ToList();
            }
            );
        }

        /// <summary> Marks the specified message for deletion. </summary>
        /// <param name="index">             Zero-based index of the message. </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        public void DeleteMessage(int index, CancellationToken cancellationToken = default)
        {
            logger.Debug("Deleting message {0}.", index);

            PerformClientMethod(
            pop3Client => pop3Client.DeleteMessage(index),
            (imapClient, imapFolder) =>
            {
                imapFolder.SetFlags(index, MessageFlags.Deleted, false, cancellationToken: cancellationToken);
            }
            );
        }

        /// <summary> Disconnects the service. </summary>
        /// <param name="quit">
        ///     If <see langword="true"/>, then a <c>QUIT</c> command will be issued in order to
        ///     disconnect cleanly.
        /// </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        public void Disconnect(bool quit, CancellationToken cancellationToken = default)
        {
            logger.Debug("Disconnecting.");

            PerformClientMethod(
                pop3Client => pop3Client.Disconnect(quit, cancellationToken),
                (imapClient, imapFolder) =>
                {
                    imapClient.Disconnect(quit, cancellationToken);
                }
                );
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        /// resources.
        /// </summary>
        /// <seealso cref="IDisposable"/>
        public void Dispose()
        {
            // Don't use the properties here, because they'll instantiate the clients if
            // they don't exist. Since we're already disposing of the wrapper, that's wasted
            // effort.

            logger.Debug("Disposing of the client wrapper object.");

            if (this.pop3Client != null)
            {
                logger.Info("POP3 Client disposing.");
                this.pop3Client.Dispose();
            }

            if (this.imapClient != null)
            {
                logger.Info("IMAP client disposing.");
                this.imapClient.Dispose();
            }
        }

        #endregion
    }
}
