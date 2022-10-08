﻿using GrayDuckMail.Common.Database;
using GrayDuckMail.Web.Models;
using GrayDuckMail.Web.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.IO;
using System.IO.Compression;
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
        /// <returns> A response to return to the caller. </returns>
        [Route("/Unsubscribe/{contactID}/{discussionListID}")]
        [ExternalAccess]
        [ViewLayout("_BlankLayout")]
        public IActionResult Unsubscribe(int contactID, int discussionListID)
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
                logger.Error("Invalid unsubscription request for non-existant discussion list with ID {0}.", discussionListID);
            }

            if (contact == null)
            {
                logger.Error("Invalid unsubscription request for non-existant contact with ID {0}.", contactID);
            }

            if (subscription == null)
            {
                logger.Error("Invalid unsubscription request. No subscription status found.");
            }
            else if (subscription.Status != SubscriptionStatus.Subscribed)
            {
                logger.Error("Invalid unsubscription status for contact with ID {0} and discussion list {1} due to subscription status {2}.", contactID, discussionListID, subscription.Status);
            }

            if (discussionList != null && contact != null && subscription.Status == SubscriptionStatus.Subscribed)
            {
                logger.Info("User {0} unsubscribing from {1}.", subscription.Contact.Name, discussionList.Name);
                subscription.Status = SubscriptionStatus.Unsubscribed;

                this.SqliteDatabase.SaveChanges();

                success = true;
            }

            var model = new UnsubscribeModel()
            {
                DiscussionList = discussionList,
                UserEmail = contact?.Email,
                Successful = success
            };

            return View("Unsubscribe", model);
        }

        #endregion
    }
}
