// file:	Helpers\LanguageHelper.cs
//
// summary:	Implements the language helper class
using GrayDuckMail.Common.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace GrayDuckMail.Common.Localization
{
    /// <summary> A class that contains methods for managing text and localization. </summary>
    public static class LanguageHelper
    {
        #region Members

        ///// <summary>
        ///// The title of the column in <c>Resources.resx</c> that contains the name of a language
        ///// resource value.
        ///// </summary>
        //private const string LOOKUP_RESOURCE_NAME = "Name";

        ///// <summary>
        ///// The title of the column in <c>Resources.resx</c> that contains the text of a language
        ///// resource value.
        ///// </summary>
        //private const string LOOKUP_RESOURCE_DESCRIPTION = "Description";

        #endregion Members

        #region Properties

        /// <summary> Gets an enumeration of the supported languages. </summary>
        /// <remarks>
        /// This <see cref="IEnumerable{T}"/> should be manually updated every time a new
        /// <see cref="Language"/> is defined.
        /// </remarks>
        /// <value> The supported languages. </value> <seealso cref="Language"/>
        public static IEnumerable<Language> SupportedLanguages
        {
            get
            {
                yield return Language.EnglishUnitedStates;
                yield return Language.SpanishSpain;
                yield return Language.JapaneseJapan;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Determines if a given <paramref name="language"/> has supported localization.
        /// </summary>
        /// <param name="language"> The language. </param>
        /// <returns>
        /// <see langword="true"/> if the language is supported, <see langword="false"/> if not.
        /// </returns>
        public static bool IsLanguageSupported(string language)
        {
            return SupportedLanguages.Any(sl => sl.Name.Equals(language, StringComparison.OrdinalIgnoreCase)
                                                  || sl.BroadLanguage.Equals(language, StringComparison.OrdinalIgnoreCase)
                                                  || sl.CommonName.Equals(language, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary> Gets the default language. Used when no localization is specified. </summary>
        /// <returns> The first language yielded by <see cref="SupportedLanguages"/>. </returns>
        public static Language GetDefaultLanguage()
        {
            return SupportedLanguages.FirstOrDefault();
        }

        /// <summary> Gets current localized language. </summary>
        /// <returns> The current localized language. </returns>
        public static Language GetCurrentLanguage()
        {
            var cultureName = Thread.CurrentThread.CurrentCulture.Name;
            var result = SupportedLanguages.Where(sl => sl.Name.Equals(cultureName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if(result == null)
            {
                result = GetDefaultLanguage();
                SetLanguage(result.Name);
            }

            return result;
        }

        /// <summary>
        /// Gets a language as described by <paramref name="language"/> matching the
        /// <see cref="Language.Name"/>, <see cref="Language.BroadLanguage"/>, or
        /// <see cref="Language.CommonName"/>.
        /// </summary>
        /// <param name="language"> The language. </param>
        /// <returns>
        /// The language matching the <see cref="Language.Name"/>, <see cref="Language.BroadLanguage"/>,
        /// or <see cref="Language.CommonName"/>.
        /// </returns>
        public static Language GetLanguage(string language)
        {
            return SupportedLanguages.Where(sl => sl.Name.Equals(language, StringComparison.OrdinalIgnoreCase)
                                               || sl.BroadLanguage.Equals(language, StringComparison.OrdinalIgnoreCase)
                                               || sl.CommonName.Equals(language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        /// <summary>
        /// Sets the current language as described by <paramref name="language"/> matching the
        /// <see cref="Language.Name"/>, <see cref="Language.BroadLanguage"/>, or
        /// <see cref="Language.CommonName"/>.
        /// </summary>
        /// <param name="language"> The language. </param>
        /// <returns>
        /// <see langword="true"/> if the language is found, <see langword="false"/> if not.
        /// </returns>
        public static bool SetLanguage(string language)
        {
            if (IsLanguageSupported(language))
            {
                var lang = GetLanguage(language);
                if (lang != null)
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(lang.CultureCode);
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang.CultureCode);
                    return true;
                }
            }
            return false;
        }

        /// <summary> Gets a text value from the localized resource file in the default language. </summary>
        /// <param name="name"> The name of the text resource. </param>
        /// <returns> The value of the text resource. </returns>
        public static string GetValue(ResourceName name)
        {
            return LanguageHelper.GetValue(name.GetName());
        }

        /// <summary>
        /// Gets a text value from the localized resource file in a given <paramref name="language"/>.
        /// </summary>
        /// <param name="language"> The language. </param>
        /// <param name="name">     The name of the text resource. </param>
        /// <returns> The localized value of the text resource. </returns>
        private static string GetValue(string language, ResourceName name)
        {
            return LanguageHelper.GetValue(language, name.GetName());
        }

        /// <summary>
        /// Gets a text value from the localized resource file in a given <paramref name="language"/>.
        /// </summary>
        /// <param name="language"> The language. </param>
        /// <param name="name">     The name of the text resource. </param>
        /// <returns> The localized value of the text resource. </returns>
        public static string GetValue(Language language, ResourceName name)
        {
            return LanguageHelper.GetValue(language, name.GetName());
        }

        /// <summary>
        /// Gets a text value from the localized resource file in the default language, then formats it
        /// with given <paramref name="parameters"/>.
        /// </summary>
        /// <param name="name">       The name of the text resource. </param>
        /// <param name="parameters"> An object array that contains <c>0</c> or more objects to format. </param>
        /// <returns> The formatted text resource. </returns>
        public static string FormatValue(ResourceName name, params object[] parameters)
        {
            return LanguageHelper.FormatValue(LanguageHelper.GetCurrentLanguage(), name, parameters);
        }

        /// <summary>
        /// Gets a text value from the localized resource file in a given <paramref name="language"/>,
        /// then formats it with given <paramref name="parameters"/>.
        /// </summary>
        /// <param name="language">   The language. </param>
        /// <param name="name">       The name of the text resource. </param>
        /// <param name="parameters"> An object array that contains <c>0</c> or more objects to format. </param>
        /// <returns> The localized, formatted text resource. </returns>
        public static string FormatValue(string language, ResourceName name, params object[] parameters)
        {
            return FormatValue(LanguageHelper.GetLanguage(language), name, parameters);
        }

        /// <summary>
        /// Gets a text value from the localized resource file in a given <paramref name="language"/>,
        /// then formats it with given <paramref name="parameters"/>.
        /// </summary>
        /// <param name="language">   The language. </param>
        /// <param name="name">       The name of the text resource. </param>
        /// <param name="parameters"> An object array that contains <c>0</c> or more objects to format. </param>
        /// <returns> The localized, formatted text resource. </returns>
        public static string FormatValue(Language language, ResourceName name, params object[] parameters)
        {
            return string.Format(GetValue(language, name), parameters);
        }

        /// <summary> Gets a text value from the localized resource file in the default language. </summary>
        /// <param name="name"> The name of the text resource. </param>
        /// <returns> The value of the text resource. </returns>
        private static string GetValue(string name)
        {
            return GetValue(LanguageHelper.GetCurrentLanguage(), name);
        }

        /// <summary>
        /// Gets a text value from the localized resource file in a given <paramref name="language"/>.
        /// </summary>
        /// <param name="language"> The language. </param>
        /// <param name="name">     The name of the text resource. </param>
        /// <returns> The localized value of the text resource. </returns>
        private static string GetValue(string language, string name)
        {
            return GetValue(LanguageHelper.GetLanguage(language), name);
        }

        /// <summary> Gets a text value from the localized resource file in a given <paramref name="language"/>. </summary>
        /// <param name="language"> The language. </param>
        /// <param name="name">     The name of the text resource. </param>
        /// <returns> The value of the text resource. </returns>
        private static string GetValue(Language language, string name)
        {
            return Resources.ResourceManager.GetString(name, language.Culture);
        }

        /// <summary>
        /// Gets a value from the resource file in the default language, then formats it with given
        /// <paramref name="parameters"/>.
        /// </summary>
        /// <param name="name">       The name of the text resource. </param>
        /// <param name="parameters"> Options for controlling the operation. </param>
        /// <returns> The formatted value. </returns>
        private static string FormatValue(string name, params object[] parameters)
        {
            return FormatValue(LanguageHelper.GetCurrentLanguage(), name, parameters);
        }

        /// <summary>
        /// Gets a value from the resource file in a given <paramref name="language"/>, then formats it
        /// with given <paramref name="parameters"/>.
        /// </summary>
        /// <param name="language">   The language. </param>
        /// <param name="name">       The name of the text resource. </param>
        /// <param name="parameters"> Options for controlling the operation. </param>
        /// <returns> The formatted value. </returns>
        private static string FormatValue(string language, string name, params object[] parameters)
        {
            return FormatValue(LanguageHelper.GetLanguage(language), name, parameters);
        }

        /// <summary>
        /// Gets a value from the resource file in a given <paramref name="language"/>, then formats it
        /// with given <paramref name="parameters"/>.
        /// </summary>
        /// <param name="language">   The language. </param>
        /// <param name="name">       The name. </param>
        /// <param name="parameters"> Options for controlling the operation. </param>
        /// <returns> The formatted value. </returns>
        private static string FormatValue(Language language, string name, params object[] parameters)
        {
            return string.Format(GetValue(language, name), parameters);
        }

        /// <summary> Converts camel case text to human readable text. </summary>
        /// <param name="value"> The value. </param>
        /// <returns> A string in human readable format. </returns>
        public static string CamelCaseToHumanReadable(string value)
        {
            var regex = new Regex(@"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            return regex.Replace(value, " ");
        }

        #endregion Methods
    }
}