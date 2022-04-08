using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyMailDiscussion.Common
{
    /// <summary> A branching tree structure that can recursively populate child nodes. </summary>
    /// <typeparam name="T"> Generic type parameter. </typeparam>
    public class Tree<T>
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        /// <summary> Gets or sets a value indicating whether this object is the base of the <see cref="Tree{T}"/>. </summary>
        /// <value> True if this object is the base, false if not. </value>
        public bool IsBase { get; set; }

        /// <summary> Gets or sets the parent of this branch. </summary>
        /// <value> The parent. </value>
        public Tree<T> Parent { get; set; }

        /// <summary> Gets or sets the value for this branch. </summary>
        /// <value> The value. </value>
        public T Value { get; set; }

        /// <summary> Gets or sets the branch nodes of this branch. </summary>
        /// <value> The branches. </value>
        public IEnumerable<Tree<T>> Branches { get; set; } = Enumerable.Empty<Tree<T>>();

        #endregion

        #region Constructors

        /// <summary> Constructor. </summary>
        /// <param name="value">           The value. </param>
        /// <param name="branchPopulator"> The recursive branch populator function. </param>
        public Tree(T value, Func<T, IEnumerable<T>> branchPopulator)
        {
            this.Value = value;

            var branchValues = branchPopulator(value).Select(branch => new Tree<T>(branch, branchPopulator));

            this.Branches = branchValues;
        }

        #endregion
    }
}
