using NLog;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GrayDuckMail.Common
{
    public static class HashHelper
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        /// <summary> Hashes a given contact ID, discussion list ID, and a secret token. </summary>
        /// <param name="contactID">        Identifier for the contact. </param>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <param name="secret">           The secret token. </param>
        /// <returns> A string that represents a SHA256 hash. </returns>
        public static string Hash(int contactID, int discussionListID, string secret)
        {
            var input = new StringBuilder();
            
            input.Append(contactID.ToString());
            input.Append(discussionListID.ToString());
            input.Append(secret);

            var provider = SHA256.Create();
            var combined = Encoding.ASCII.GetBytes(input.ToString());
            var hash = provider.ComputeHash(combined);
            var result = BitConverter.ToString(hash).Replace("-","");

            return result;
        }

        /// <summary>
        /// Check a given hash to confirm that it matches the <see cref="Hash(int, int, string)"/> of the
        /// given contact ID, discussion list ID, and secret token.
        /// </summary>
        /// <param name="contactID">        Identifier for the contact. </param>
        /// <param name="discussionListID"> Identifier for the discussion list. </param>
        /// <param name="secret">           The secret token. </param>
        /// <param name="hash">             The provided hash. </param>
        /// <returns> True if the hashes match, false if they do not match. </returns>
        public static bool CheckHash(int contactID, int discussionListID, string secret, string hash)
        {
            var computedHash = Hash(contactID, discussionListID, secret);
            var result = computedHash.Equals(hash);

            return result;
        }

        #endregion
    }
}
