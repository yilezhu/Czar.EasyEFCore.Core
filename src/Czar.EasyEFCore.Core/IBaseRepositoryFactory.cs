/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：IRepositoryFactory                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/23 22:02:56                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.EasyEFCore.Core
{
    /// <summary>
    /// Defines the interfaces for <see cref="IBaseRepository{TEntity}"/> interfaces.
    /// </summary>
    public interface IBaseRepositoryFactory
    {
        int ExecuteSqlCommand(string sql, params object[] parameters);

        /// <summary>
        /// Gets the specified repository for the <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="hasCustomRepository"><c>True</c> if providing custom repository.</param>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>An instance of type inherited from <see cref="IBaseRepository{TEntity}"/> interface.</returns>
        IBaseRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false)
            where TEntity : class;
    }
}
