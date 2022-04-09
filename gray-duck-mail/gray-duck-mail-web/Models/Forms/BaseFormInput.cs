using System;

namespace GrayDuckMail.Web.Models.Forms
{
    /// <summary> A base class for shared utilities common to all form input. </summary>
    public class BaseFormInput 
    {
        //
    }

    /// <summary>
    /// A typed base class for shared utilities that provide syntactic sugar when accessing methods
    /// in derived classes.
    /// </summary>
    /// <remarks>
    /// <typeparamref name="T"/> must conform to <see cref="BaseFormInput"/>. Because a class
    /// deriving from <see cref="BaseFormInput{T}"/>, and <see cref="BaseFormInput{T}"/> itself
    /// adheres to this convention, casting is available from the <see cref="BaseFormInput"/> object
    /// to <typeparamref name="T"/> objects. This makes syntactic sugar possible when creating <see cref="Func{T, TResult}"/>
    /// parameters accessing the derived type's properties by allowing a cast of <c>this</c> to <see cref="BaseFormInput"/>
    /// to <typeparamref name="T"/>.
    /// </remarks>
    /// <typeparam name="T"> Generic type parameter. </typeparam>
    public class BaseFormInput<T> : BaseFormInput where T : BaseFormInput
    {
        #region Methods

        /// <summary> Determine if a property of a derived class represents an HTML form value coresponding to a marked checkbox. </summary>
        /// <param name="propertyAccessor"> The property accessor. </param>
        /// <returns> True if checked, false if not. </returns>
        public bool IsChecked(Func<T, string> propertyAccessor)
        {
            T t = (T)(BaseFormInput)this;
            return (!string.IsNullOrWhiteSpace(propertyAccessor(t)));
        }

        #endregion
    }
}
