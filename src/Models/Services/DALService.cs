using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kaigang.Models.Services 
{
    /// <summary>
    /// This is the Data Access Layer Service. It is responsible for Database communication
    /// If you need to insert an Entity into the Database, just use you entity type as T
    /// when invoking this service
    /// </summary>
    /// <typeparam name="T">An enttity T to be inserted on the Database</typeparam>
    public static class DALService<T> where T : class
    {
        /// <summary>
        /// Inserts an entity into the Database
        /// </summary>
        /// <param name="entity">Entity to be inserted</param>
        /// <returns>The saved entity</returns>
        async public static Task<T> Add(T entity)
        {
            using (var ctx = new KaigangDbContext())
            {
                await ctx.AddAsync<T>(entity);
                await ctx.SaveChangesAsync();
                return entity;
            }
        }
        /// <summary>
        /// Updates an entity into the Database
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        /// <returns>Number of affected rows</returns>
        async public static Task<bool> Update(T entity)
        {
            using (var ctx = new KaigangDbContext())
            {
                ctx.Update<T>(entity);
                var res = await ctx.SaveChangesAsync();
                return res == 1;
            }
        }
        async public static Task<bool> Delete(T entity)
        {
            using (var ctx = new KaigangDbContext())
            {
                ctx.Remove<T>(entity);
                var res = await ctx.SaveChangesAsync();
                return res > 0 ;
            }
        }
        async public static Task<T> Get(params object[] keyValues)
        {
            using (var ctx = new KaigangDbContext())
            {
                return await ctx.FindAsync<T>(keyValues);
            }
        }

        async public static Task<IEnumerable<T>> GetMany(Func<T, bool> ft)
        {
            using (var ctx = new KaigangDbContext())
            {
                return await ctx.Set<T>().Where(ft).AsQueryable().ToListAsync();
            }
        }

    }
}