﻿using System.Linq.Expressions;

namespace NinoBank.Infrastructure.Repositories.Base.Interfaces
{
    public interface IReadRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets all entities in the repository.
        /// </summary>
        /// <returns>An IQueryable representing all entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets entities based on a predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter entities.</param>
        /// <returns>An IQueryable representing entities that satisfy the predicate.</returns>
        Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets a single entity based on a predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter entities.</param>
        /// <returns>The first entity that satisfies the predicate, or null if not found.</returns>
        Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Checks if any entity in the repository satisfies a given predicate.
        /// </summary>
        /// <param name="predicate">The predicate to check against entities.</param>
        /// <returns>True if any entity satisfies the predicate; otherwise, false.</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
