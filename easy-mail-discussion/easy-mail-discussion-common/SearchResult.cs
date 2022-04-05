using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common
{
    /// <summary> Encapsulates the result of a search on a given <typeparamref name="T"/>. </summary>
    /// <typeparam name="T"> Generic type parameter. </typeparam>
    public class SearchResult<T>
    {
        #region Properties

        /// <summary> Gets or sets the <typeparamref name="T"/> item. </summary>
        /// <value> The <typeparamref name="T"/> item. </value>
        public T Item { get; private set; }

        /// <summary> Gets or sets the relative search score. </summary>
        /// <value> The search score. </value>
        public float Score { get; private set; }

        #endregion

        #region Constructors

        /// <summary> Constructor. </summary>
        /// <param name="item">  The <typeparamref name="T"/> item. </param>
        /// <param name="score"> The relative search score. </param>
        public SearchResult(T item, float score)
        {
            this.Item = item;
            this.Score = score;
        }

        #endregion
    }
}
