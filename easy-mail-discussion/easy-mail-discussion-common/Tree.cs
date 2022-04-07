using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyMailDiscussion.Common
{
    public class Tree<T>
    {
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

        public Tree(T value, IEnumerable<T> branchValues, Func<T, IEnumerable<T>> branchPopulator)
        {
            this.Value = value;

            if(branchValues.Any())
            {
                var branches = branchValues.Select(branch => new Tree<T>(branch, branchPopulator(branch), branchPopulator));
                this.Branches = branches;
            }
        }

        #endregion
    }
}
