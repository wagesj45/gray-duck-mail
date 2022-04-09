using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrayDuckMail.Common
{
    /// <summary> A helper class for cleaning HTML strings. </summary>
    public static class HTMLCleaner
    {
        #region Methods

        /// <summary> Removes the inline CSS described in an HTML string. </summary>
        /// <param name="html"> The HTML string. </param>
        /// <returns> A string of HTML with no inline script or styles. </returns>
        public static string RemoveInlineCSS(string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            htmlDocument.DocumentNode.Descendants()
                .Where(node => node.Name.Equals("script", StringComparison.OrdinalIgnoreCase) || node.Name.Equals("style", StringComparison.OrdinalIgnoreCase))
                .ToList()
                .ForEach(node => node.Remove());

            return htmlDocument.DocumentNode.InnerHtml;
        }

        #endregion
    }
}
