using GrayDuckMail.Common;
using GrayDuckMail.Common.Database;
using GrayDuckMail.Common.Localization;
using GrayDuckMail.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NLog;
using System.Linq;

namespace GrayDuckMail.Web.Controllers
{
    /// <summary> Handles web requests from external sources. </summary>
    public class ExternalController : BaseController
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary> Constructor. </summary>
        /// <param name="lifetime"> The lifetime. </param>
        public ExternalController(IHostApplicationLifetime lifetime)
            : base(lifetime)
        {
            //
        }

        #endregion

        #region Methods

        /// <summary> Gets the index or default request. </summary>
        /// <remarks>
        /// Fulfills the <c>/Unsubscribe</c> request.
        ///
        /// Because this method may be accessed externally, all input must be validated and checked.
        /// </remarks>
        /// <param name="contactID">        Identifier for the contact. </param>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <param name="hash">             The hash of the web server secret token, the contact ID, and the discussion list ID. </param>
        /// <returns> A response to return to the caller. </returns>
        /// <seealso cref="DockerEnvironmentVariables.WebSecret"/>
        [HttpGet]
        [Route("/Unsubscribe/{contactID}/{discussionListID}/{hash}")]
        [ExternalAccess]
        [ViewLayout("_BlankLayout")]
        public IActionResult Unsubscribe(int contactID, int discussionListID, string hash)
        {
            var (discussionList, contact, success) = TryUnsubscribe(contactID, discussionListID, hash);

            var model = new UnsubscribeModel()
            {
                DiscussionList = discussionList,
                UserEmail = contact?.Email,
                Successful = success
            };

            return View("Unsubscribe", model);
        }

        /// <summary>
        /// RFC 8058 one-click unsubscribe. Mail clients POST <c>List-Unsubscribe=One-Click</c> to the
        /// <c>List-Unsubscribe</c> HTTPS URL without user interaction.
        /// </summary>
        /// <param name="contactID">        Identifier for the contact. </param>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <param name="hash">             The hash of the web server secret token, the contact ID, and the discussion list ID. </param>
        /// <returns> A response to return to the caller. </returns>
        /// <seealso href="https://www.rfc-editor.org/info/rfc8058"/>
        [HttpPost]
        [Route("/Unsubscribe/{contactID}/{discussionListID}/{hash}")]
        [ExternalAccess]
        public IActionResult UnsubscribePost(int contactID, int discussionListID, string hash)
        {
            if (!IsOneClickUnsubscribeRequest())
            {
                return BadRequest();
            }

            var (_, _, success) = TryUnsubscribe(contactID, discussionListID, hash);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary> Query if the current request is an RFC 8058 one-click unsubscribe POST. </summary>
        /// <returns> True if the POST body signals one-click unsubscribe. </returns>
        private bool IsOneClickUnsubscribeRequest()
        {
            if (Request.HasFormContentType)
            {
                return Request.Form["List-Unsubscribe"].FirstOrDefault() == "One-Click";
            }

            return false;
        }

        /// <summary> Unsubscribes a contact from a discussion list when validation succeeds. </summary>
        /// <param name="contactID">        Identifier for the contact. </param>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <param name="hash">             The unsubscribe link hash. </param>
        /// <returns> The discussion list, contact, and whether unsubscription succeeded. </returns>
        private (DiscussionList discussionList, Contact contact, bool success) TryUnsubscribe(int contactID, int discussionListID, string hash)
        {
            var success = false;
            var discussionList = this.SqliteDatabase.DiscussionLists.Where(_discussionList => _discussionList.ID == discussionListID).SingleOrDefault();
            var contact = this.SqliteDatabase.Contacts.Where(_contact => _contact.ID == contactID).SingleOrDefault();
            var subscription = this.SqliteDatabase.DiscussionLists.Where(_discussionList => _discussionList.ID == discussionListID)
            .SelectMany(_discussionList => _discussionList.Subscriptions)
            .Where(subscription => subscription.Contact.ID == contactID)
            .SingleOrDefault();

            if (discussionList == null)
            {
                logger.Error(LanguageHelper.FormatValue(ResourceName.Logger_Format_InvalidUnsubscriptionDiscussionList, discussionListID));
            }

            if (contact == null)
            {
                logger.Error(LanguageHelper.FormatValue(ResourceName.Logger_Format_InvalidUnsubscriptionContact, contactID));
            }

            var hashMatch = HashHelper.CheckHash(contactID, discussionListID, DockerEnvironmentVariables.WebSecret, hash);
            if (!hashMatch)
            {
                logger.Error(LanguageHelper.GetValue(ResourceName.Logger_FailedHashMatch));
            }

            if (subscription == null)
            {
                logger.Error(LanguageHelper.GetValue(ResourceName.Logger_InvalidUnsubscriptionSubscription));
            }
            else if (subscription.Status != SubscriptionStatus.Subscribed)
            {
                logger.Error(LanguageHelper.FormatValue(ResourceName.Logger_Format_InvalidUnsubscriptionSubscriptionStatus, contactID, discussionListID, subscription.Status));
            }

            if (discussionList != null
                && contact != null
                && subscription != null
                && subscription.Status == SubscriptionStatus.Subscribed
                && hashMatch)
            {
                logger.Info(LanguageHelper.FormatValue(ResourceName.Logger_Format_UserUnsubscribing, subscription.Contact.Name, discussionList.Name));
                subscription.Status = SubscriptionStatus.Unsubscribed;

                this.SqliteDatabase.SaveChanges();

                success = true;
            }

            return (discussionList, contact, success);
        }

        #endregion
    }
}
