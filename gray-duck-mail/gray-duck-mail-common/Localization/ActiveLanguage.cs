namespace GrayDuckMail.Common.Localization
{
    /// <summary> An instanced version of a <see cref="Language"/>. </summary>
    public class ActiveLanguage : Language
    {
        /// <summary> Constructor for an instance of a <see cref="Language"/>. </summary>
        /// <param name="name">        The name of the language. </param>
        /// <param name="displayName"> The display name of the language. </param>
        /// <param name="cultureCode"> The culture code of the language. </param>
        /// <param name="isoValue">    The ISO value of the language. </param>
        public ActiveLanguage(string name, string displayName, int cultureCode, string isoValue)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.CultureCode = cultureCode;
            this.ISOValue = isoValue;
            this.Culture = new System.Globalization.CultureInfo(cultureCode);
        }
    }
}