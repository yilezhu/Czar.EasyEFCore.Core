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
    /// Provides some help methods for <see cref="IPagedList{T}"/> interface.
    /// </summary>
    public static class PagedList
    {
        /// <summary>
        /// Creates an empty of <see cref="IPagedList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type for paging. </typeparam>
        /// <returns>An empty instance of <see cref="IPagedList{T}"/>.</returns>
        public static IPagedList<T> Empty<T>() => new PagedListT<T>();

        /// <summary>
        ///  Creates a new instance of <see cref="IPagedList{TResult}"/> from source of <see cref="IPagedList{TSource}"/> instance.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="sources">The source.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>An instance of <see cref="IPagedList{TResult}"/>.</returns>
        public static IPagedList<TResult> From<TResult, TSource>(IPagedList<TSource> sources, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter) => new PagedListST<TSource, TResult>(sources, converter);
    }
}
