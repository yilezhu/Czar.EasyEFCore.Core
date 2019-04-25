/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：IQueryablePageListExtensions                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/22 21:39:23                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Czar.EasyEFCore.Core
{
    public static class IQueryablePageListExtensions
    {
        /// <summary>
        /// Converts the specified source to <see cref="IPagedList{T}"/> by the specified <paramref name="pageIndex"/> and <paramref name="pageSize"/>.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="sources">The source to paging.</param>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="cancellationToken"> to observe while waiting for the task to complete.</param>
        /// <returns>An instance of the inherited from <see cref="IPagedList{T}"/> interface.</returns>
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> sources, int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            var count = await sources.CountAsync(cancellationToken).ConfigureAwait(false);
            var items = await sources.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync(cancellationToken).ConfigureAwait(false);
            return new PagedListT<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = count,
                Items = items,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
            };
        }
    }
}
