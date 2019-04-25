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
using System.Text;

namespace Czar.EasyEFCore.Core
{
    /// <summary>
    /// Represents the default implementation of the <see cref="IPagedList{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the data to page.</typeparam>
    public class PagedListT<T> : IPagedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListT{T}" /> class.
        /// </summary>
        internal PagedListT()
        {
            Items = new T[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListT{T}" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        internal PagedListT(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            Items = source.Skip(PageIndex * PageSize).Take(PageSize).ToList();
        }

        /// <summary>
        /// Gets or sets the page index (current).
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total count of the list of type <typeparamref name="T"/>.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the current page items.
        /// </summary>
        public IList<T> Items { get; set; }

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
