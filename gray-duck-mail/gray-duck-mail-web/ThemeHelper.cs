using System.Collections.Generic;

namespace GrayDuckMail.Web
{
    /// <summary> A helper class that contains meta-data and helper methods about <see href="https://picocss.com/docs/themes.html">Pico.css theming</see>. </summary>
    public static class ThemeHelper
    {
        #region Properties

        /// <summary>
        /// Gets the valid themes in <see href="https://picocss.com/docs/themes.html">Pico.css</see>.
        /// </summary>
        /// <value> The valid themes. </value>
        /// <seealso cref="DefaultTheme"/>
        public static IEnumerable<string> Themes
        {
            get
            {
                yield return "Light";
                yield return "Dark";
                yield return DefaultTheme;
            }
        }

        /// <summary> Gets the default theme string value. </summary>
        /// <remarks>
        /// <see cref="string.Empty"/> is interpreted by Pico.css as the automatic or system theme.
        /// </remarks>
        /// <value> The default theme string value. </value>
        public static string DefaultTheme
        {
            get
            {
                return string.Empty;
            }
        }

        #endregion
    }
}
