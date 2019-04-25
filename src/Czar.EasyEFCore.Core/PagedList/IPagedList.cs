/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：IPagedList                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/22 20:20:57                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.EasyEFCore.Core
{
    /// <summary>
    /// Provides the interface(s) for paged list of any type.
    /// </summary>
    /// <typeparam name="T">The type for paging.</typeparam>
    public interface IPagedList<T>
    {
        /// <summary>
        /// Gets the page index (current).
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Gets the page size.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets the total count of the list of type <typeparamref name="T"/>.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Gets the total pages.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Gets the current page items.
        /// </summary>
        IList<T> Items { get; }

        /// <summary>
        /// Gets a value indicating whether gets the has previous page.
        /// </summary>
        /// <value>The has previous page.</value>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Gets a value indicating whether gets the has next page.
        /// </summary>
        /// <value>The has next page.</value>
        bool HasNextPage { get; }
    }
}
