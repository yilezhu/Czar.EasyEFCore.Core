/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：PagedList                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/22 20:26:59                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Czar.EasyEFCore.Core
{
    /// <summary>
    /// Provides the implementation of the <see cref="IPagedList{T}"/> and converter.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal class PagedListST<TSource, TResult> : IPagedList<TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListST{TSource, TResult}" /> class.
        /// </summary>
        /// <param name="sources">The source.</param>
        /// <param name="converter">The converter.</param>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        public PagedListST(IEnumerable<TSource> sources, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = sources.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            var items = sources.Skip(PageIndex * PageSize).Take(PageSize).ToArray();

            Items = new List<TResult>(converter(items));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListST{TSource, TResult}" /> class.
        /// </summary>
        /// <param name="sources">The source.</param>
        /// <param name="converter">The converter.</param>
        public PagedListST(IPagedList<TSource> sources, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            PageIndex = sources.PageIndex;
            PageSize = sources.PageSize;
            TotalCount = sources.TotalCount;
            TotalPages = sources.TotalPages;

            Items = new List<TResult>(converter(sources.Items));
        }

        /// <summary>
        /// Gets or sets the index from 0 or 1.
        /// </summary>
        /// <value>The index from.</value>
        public int IndexFrom { get; set; }

        /// <summary>
        /// Gets or sets the page index (current).
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the current page items.
        /// </summary>
        public IList<TResult> Items { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets the has previous page.
        /// </summary>
        /// <value>The has previous page.</value>
        public bool HasPreviousPage => PageIndex > 0;

        /// <summary>
        /// Gets a value indicating whether gets the has next page.
        /// </summary>
        /// <value>The has next page.</value>
        public bool HasNextPage => PageIndex + 1 < TotalPages;
    }
}
