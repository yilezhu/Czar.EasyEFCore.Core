/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：UnitOfWorkServiceCollectionExtensions                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/27 13:28:55                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Czar.EasyEFCore.Core
{
    /// <summary>
    /// Extension methods for setting up unit of work related services in .
    /// </summary>
    public static class UnitOfWorkServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            // Following has a issue: IUnitOfWork cannot support multiple dbcontext/database, 
            // that means cannot call AddUnitOfWork<TContext> multiple times.
            // Solution: check IUnitOfWork whether or null
            _ = services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            _ = services.AddScoped<IUnitOfWorkT<TContext>, UnitOfWork<TContext>>();
            return services;
        }

        /// <summary>
        /// Registers the custom repository as a service in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TRepository">The type of the custom repositry.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>The same service collection so that multiple calls can be chained.</returns>
        public static IServiceCollection AddCustomRepository<TEntity, TRepository>(this IServiceCollection services)
           where TEntity : class
           where TRepository : class, IBaseRepository<TEntity>
        {
            _ = services.AddScoped<IBaseRepository<TEntity>, TRepository>();
            return services;
        }
    }
}
