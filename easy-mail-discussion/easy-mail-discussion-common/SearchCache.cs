using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyMailDiscussion.Common
{
    /// <summary> A cache of search results. </summary>
    /// <typeparam name="T"> Generic type parameter. </typeparam>
    public class SearchCache<T>
    {
        #region Properties

        /// <summary> Gets or sets the search term used when generating the cache. </summary>
        /// <value> The search term. </value>
        public string SearchTerm { get; private set; }

        /// <summary> Gets or sets the cache of search results. </summary>
        /// <value> The cache. </value>
        public SearchResult<T>[] Cache { get; private set; }

        #endregion

        #region Constructors

        /// <summary> Default constructor. </summary>
        public SearchCache()
        {
            this.SearchTerm = string.Empty;
            this.Cache = Enumerable.Empty<SearchResult<T>>().ToArray();
        }

        /// <summary> Constructor. </summary>
        /// <param name="searchTerm">    The search term. </param>
        /// <param name="searchResults"> The search results. </param>
        public SearchCache(string searchTerm, IEnumerable<SearchResult<T>> searchResults)
        {
            this.SearchTerm = searchTerm;
            this.Cache = searchResults.ToArray();
        }

        #endregion
    }
}
