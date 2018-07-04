using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kaigang.Models.Services 
{
    /// <summary>
    /// This is the Data Access Layer Service. It is responsible for Database communication
    /// If you need to insert an Entity into the Database, just use your entity type as <T>
    /// when invoking this service
    /// </summary>
    /// <typeparam name="T">An entity T to be inserted on the Database</typeparam>
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

        /// <summary>
        /// Deletes and Entity
        /// </summary>
        /// <param name="entity">Entity to be removed from database</param>
        /// <returns>Operation successfull or not</returns>
        async public static Task<bool> Delete(T entity)
        {
            using (var ctx = new KaigangDbContext())
            {
                ctx.Remove<T>(entity);
                var res = await ctx.SaveChangesAsync();
                return res > 0 ;
            }
        }
        /// <summary>
        /// Get an entity from the database
        /// </summary>
        /// <param name="keyValues">Key-columns from the entity/table</param>
        /// <returns>An entity if founds, otherwise null</returns>
        async public static Task<T> Get(params object[] keyValues)
        {
            using (var ctx = new KaigangDbContext())
            {
                return await ctx.FindAsync<T>(keyValues);
            }
        }

        /// <summary>
        /// Returns a list of entities based on an expresion
        /// </summary>
        /// <param name="ft">The expressiont to query the Database</param>
        /// <returns>A list with the entities found</returns>
        async public static Task<IEnumerable<T>> GetMany(Func<T, bool> ft)
        {
            return await Task.Run(() => {
                using (var ctx = new KaigangDbContext())
                {
                    return ctx.Set<T>().Where(ft).ToList();
                }
            });
            
         }

    }
}
