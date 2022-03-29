using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyMailDiscussion.Common
{
    /// <summary>
    /// A helper class containing extensions for
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/">LINQ</see>
    /// operations.
    /// </summary>
    /// <seealso cref="System.Linq"/>
    public static class LINQExtensions
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        /// <summary>
        /// Get a page of items from a collection, skipping <paramref name="pageNumber"/> pages of
        /// <paramref name="pageSize"/> items per page.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when <paramref name="pageNumber"/> is
        ///                                                less than <c>1</c> or if
        ///                                                <paramref name="pageSize"/> is less than
        ///                                                <c>1</c>. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="source">     The source to act on. </param>
        /// <param name="pageNumber"> The page number to retrieve. </param>
        /// <param name="pageSize">   Number of items per page. </param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process page in this collection.
        /// </returns>
        /// <remarks> This method uses natural numbering starting at page 1. </remarks>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                var argumentOutOfRangeException = new ArgumentOutOfRangeException(nameof(pageNumber));
                logger.Error(argumentOutOfRangeException);

                throw argumentOutOfRangeException;
            }

            if (pageSize < 1)
            {
                var argumentOutOfRangeException = new ArgumentOutOfRangeException(nameof(pageSize));
                logger.Error(argumentOutOfRangeException);

                throw argumentOutOfRangeException;
            }

            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Get a page of items from a collection, skipping <paramref name="pageNumber"/> pages of
        /// <paramref name="pageSize"/> items per page.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when <paramref name="pageNumber"/> is
        ///                                                less than <c>1</c> or if
        ///                                                <paramref name="pageSize"/> is less than
        ///                                                <c>1</c>. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="source">     The source to act on. </param>
        /// <param name="pageNumber"> The page number to retrieve. </param>
        /// <param name="pageSize">   . </param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process page in this collection.
        /// </returns>
        /// <remarks> This method uses natural numbering starting at page 1. </remarks>
        public static IQueryable<T> Page<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                var argumentOutOfRangeException = new ArgumentOutOfRangeException(nameof(pageNumber));
                logger.Error(argumentOutOfRangeException);

                throw argumentOutOfRangeException;
            }

            if (pageSize < 1)
            {
                var argumentOutOfRangeException = new ArgumentOutOfRangeException(nameof(pageSize));
                logger.Error(argumentOutOfRangeException);

                throw argumentOutOfRangeException;
            }

            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// The number of pages of <paramref name="pageSize"/> size in the given collection.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when <paramref name="pageSize"/> is
        ///                                                less than <c>1</c>. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="source">   The source to act on. </param>
        /// <param name="pageSize"> Size of the page. </param>
        /// <returns> An int. </returns>
        public static int PageCount<T>(this IEnumerable<T> source, int pageSize)
        {
            if (pageSize < 1)
            {
                var argumentOutOfRangeException = new ArgumentOutOfRangeException(nameof(pageSize));
                logger.Error(argumentOutOfRangeException);

                throw argumentOutOfRangeException;
            }

            var ceiling = Math.Ceiling(Convert.ToDouble(source.Count()) / pageSize);
            return Convert.ToInt32(ceiling);
        }

        /// <summary>
        /// The number of pages of <paramref name="pageSize"/> size in the given collection.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when <paramref name="pageSize"/> is
        ///                                                less than <c>1</c>. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="source">   The source to act on. </param>
        /// <param name="pageSize"> Size of the page. </param>
        /// <returns> An int. </returns>
        public static int PageCount<T>(this IQueryable<T> source, int pageSize)
        {
            if (pageSize < 1)
            {
                var argumentOutOfRangeException = new ArgumentOutOfRangeException(nameof(pageSize));
                logger.Error(argumentOutOfRangeException);

                throw argumentOutOfRangeException;
            }

            var ceiling = Math.Ceiling(Convert.ToDouble(source.Count()) / pageSize);
            return Convert.ToInt32(ceiling);
        } 

        #endregion
    }
}
