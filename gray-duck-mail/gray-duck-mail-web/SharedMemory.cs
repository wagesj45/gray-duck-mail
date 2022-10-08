using GrayDuckMail.Common;
using NLog;
using System.Collections.Concurrent;

namespace GrayDuckMail.Web
{
    /// <summary>
    /// An object containing shared memory objects. These collections are meant to be shared between
    /// threads.
    /// </summary>
    /// <remarks>
    /// Because cross thread access is expected, care must be taken to make sure all methods are
    /// thread safe.
    /// </remarks>
    public static class SharedMemory
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary> A concurrent, thread-safe email message quque.. </summary>
        private static ConcurrentQueue<EmailDefinition> emailQueue = new ConcurrentQueue<EmailDefinition>();

        #endregion

        #region Constructor

        /// <summary> Static constructor. </summary>
        static SharedMemory()
        {
            logger.Debug("Initializing shared memory object via static constructor.");
        }

        #endregion

        #region Methods

        /// <summary> Adds an email definition to the <see cref="emailQueue"/>. </summary>
        /// <param name="emailDefinition"> The email definition. </param>
        public static void AddEmail(EmailDefinition emailDefinition)
        {
            logger.Debug("Adding email definition to queue.");
            emailQueue.Enqueue(emailDefinition);
        }

        /// <summary> Pops the <see cref="EmailDefinition"/> from the queue if one is available. </summary>
        /// <returns> An EmailDefinition if one is available, otherwise null. </returns>
        public static EmailDefinition PopEmail()
        {
            if (emailQueue.TryDequeue(out EmailDefinition emailDefinition))
            {
                logger.Debug("Fetching email defintion from queue.");
                return emailDefinition; ;
            }

            logger.Debug("Unable to fetch email definition from queue.");
            return default(EmailDefinition);
        }

        #endregion
    }
}
