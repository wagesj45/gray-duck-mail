using Fastenshtein;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        /// <summary>
        /// Enumerates the items in this collection that contain a given
        /// <paramref name="searchTerm">search term</paramref>.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="source">           The source to act on. </param>
        /// <param name="propertySelector"> The property selector. </param>
        /// <param name="searchTerm">       The search term. </param>
        /// <returns> An enumerator that allows foreach to be used to process the matched items. </returns>
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, Func<T, string> propertySelector, string searchTerm)
        {
            return source.Where(item => propertySelector(item).Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Enumerates the items in this collection that contain a given
        /// <paramref name="searchTerm">search term</paramref>.
        /// </summary>
        /// <remarks>
        /// This method relies heavily on
        /// <see href="https://www.codeproject.com/Articles/30588/ASP-NET-MVC-Flexigrid-sample">this
        /// article</see> and its code samples.
        /// </remarks>
        /// <exception cref="ArgumentException"> Thrown when one or more arguments have unsupported or
        /// illegal values. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="source">           The source to act on. </param>
        /// <param name="propertySelector"> The property selector. </param>
        /// <param name="searchTerm">       The search term. </param>
        /// <returns> An enumerator that allows foreach to be used to process the matched items. </returns>
        public static IQueryable<T> Search<T>(this IQueryable<T> source, Expression<Func<T, string>> propertySelector, string searchTerm)
        {
            var functionType = typeof(DbFunctionsExtensions);
            var thing = propertySelector.Body as MemberExpression;
            var name = thing?.Member?.Name;

            if (string.IsNullOrWhiteSpace(name))
            {
                var argumentException = new ArgumentException("The property selector was unable to resolve to a property name.", nameof(propertySelector));
                logger.Error(argumentException);

                throw argumentException;
            }

            if(string.IsNullOrWhiteSpace(searchTerm))
            {
                var argumentException = new ArgumentException("No search term was provided.", nameof(searchTerm));
                logger.Error(argumentException);

                throw argumentException;
            }

            var type = typeof(T);
            var property = type.GetProperty(name);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var constant = Expression.Constant("%" + searchTerm + "%");
            var like = functionType.GetMethod("Like", new Type[] { typeof(DbFunctions), typeof(string), typeof(string) });
            var dbFunctionsAccess = Expression.MakeMemberAccess(null, typeof(EF).GetProperty("Functions"));
            MethodCallExpression methodExp = Expression.Call(null, like, dbFunctionsAccess, propertyAccess, constant);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);

            return source.Where(lambda);
        }

        /// <summary>
        /// Enumerates the items in this collection that contain a given
        /// <paramref name="searchTerm">search time</paramref> or a similar string.
        /// </summary>
        /// <remarks> This method is extremely resource intensive. </remarks>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="source">     The source to act on. </param>
        /// <param name="accessors">   The accessors that returns a string to search. </param>
        /// <param name="searchTerm"> The search term. </param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process the fuzzies in this collection.
        /// </returns>
        /// <seealso cref="Levenshtein"/>
        /// <seealso cref="Levenshtein.Distance(string, string)"/>
        public static IEnumerable<SearchResult<T>> FuzzySearch<T>(this IEnumerable<T> source, string searchTerm, params Func<T, string>[] accessors)
        {
            var levenshteinProcessor = new Levenshtein(searchTerm);

            return source.Select(item => new { Item = item, Words = string.Concat(accessors.Select(accessor => accessor(item) + " ")).Split(' ', StringSplitOptions.RemoveEmptyEntries) })
                .Select(anon => new
                {
                    Item = anon.Item,
                    Words = anon.Words,
                    ExactMatch = anon.Words.Count(word => word.Equals(searchTerm)),
                    IgnoreCaseMatch = anon.Words.Count(word => word.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)),
                    SubstringMatch = anon.Words.Count(word => word.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)),
                    LevenshteinScore = anon.Words.Min(word => levenshteinProcessor.DistanceFrom(word))
                })
                .Select(anon => new SearchResult<T>(anon.Item, (anon.ExactMatch * 1.1f) + (anon.IgnoreCaseMatch * 1.0f) + (anon.SubstringMatch * 0.9f) + (1.0f / (anon.LevenshteinScore + 1.0f))));

        }

        #endregion
    }
}
