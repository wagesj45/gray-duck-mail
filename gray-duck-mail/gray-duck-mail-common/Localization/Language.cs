using System.Globalization;
using System.Linq;

namespace GrayDuckMail.Common.Localization
{
    /// <summary> A class that represents a written language. </summary>
    /// <example>
    /// Only the <see cref="ActiveLanguage"/> can act as an instance of a <see cref="Language"/>.
    /// <code>
    /// public static Language EnglishUnitedStates
    /// {
    ///     get
    ///     {
    ///         return new ActiveLanguage("en-US", "English - United States", 0x0409, string.Empty);
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <remarks>
    /// The class is marked as <see langword="abstract"/>
    /// and can only be instanced via <see langword="static"/> <see cref="ActiveLanguage"/>
    /// invocation methods. This means that new languages should be declared within this class.
    /// </remarks>
    public abstract class Language
    {
        #region Properties

        /// <summary> Gets or sets the name of the language. </summary>
        /// <value> The name of the language. </value>
        public string Name { get; internal set; }

        /// <summary> Gets or sets the name of the language as displayed in UI elements. </summary>
        /// <value> The display name of the language. </value>
        public string DisplayName { get; internal set; }

        /// <summary> Gets or sets the culture code of the language. </summary>
        /// <remarks>
        /// A <a href="https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes">culture code reference</a>
        /// is used to programatically the language.
        /// </remarks>
        /// <value> The culture code of the language. </value>
        public int CultureCode { get; internal set; }

        /// <summary> Gets or sets the ISO value of the language. </summary>
        /// <remarks>
        /// An <a href="https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes">ISO value</a> is a
        /// standardized nomenclature describing a <see cref="CultureInfo">language culture</see>.
        /// </remarks>
        /// <value> The ISO value of the language. </value>
        public string ISOValue { get; internal set; }

        /// <summary> Gets or sets the language culture. </summary>
        /// <value> The language culture. </value>
        public CultureInfo Culture { get; internal set; }

        #region Derived

        /// <summary> Gets the broadly applicable language name. </summary>
        /// <remarks>
        /// This is used for parent languages without localization, such as English which can be
        /// localized to the US or UK.
        /// </remarks>
        /// <value> The broadly applicable language. </value>
        public string BroadLanguage
        {
            get
            {
                return this.Name.Split('-').Select(n => n.Trim()).FirstOrDefault();
            }
        }

        /// <summary> Gets the common name of the language. </summary>
        /// <remarks>
        /// This is the name that could be considered common use, such as Enlgish when spoken in the UK,
        /// where the full culture would be English-UK.
        /// </remarks>
        /// <value> The common name of the language. </value>
        public string CommonName
        {
            get
            {
                return this.DisplayName.Split('-').Select(n => n.Trim()).FirstOrDefault();
            }
        }

        #endregion Derived

        #endregion Properties

        #region Values

        /// <summary> English Language - United States Localization. </summary>
        /// <value> The english language. </value>
        public static Language EnglishUnitedStates
        {
            get
            {
                return new ActiveLanguage("en-US", "English - United States", 0x0409, string.Empty);
            }
        }

        /// <summary> Spanish Language - Spain Localization. </summary>
        /// <value> The spanish language. </value>
        public static Language SpanishSpain
        {
            get
            {
                return new ActiveLanguage("es-ES", "Spanish - Spain", 0x0C0A, string.Empty);
            }
        }

        /// <summary> Japenese Language - Japan Localization. </summary>
        /// <value> The japanese language. </value>
        public static Language JapaneseJapan
        {
            get
            {
                return new ActiveLanguage("jp-JP", "Japanese - Japan", 0x0411, "JPN");
            }
        }

        #endregion Values
    }
}