using System.Linq.Expressions;
using TasksApp.Domain.Entities;

namespace TasksApp.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Creates a new <see cref="TEntity"/>
    /// </summary>
    Task<TEntity> CreateAsync(TEntity entity);

    /// <summary>
    /// Updates the <see cref="TEntity"/>
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntity> UpdateAsync(TEntity entity);

    /// <summary>
    /// Gets the requested <see cref="TEntity"/> if the id exists
    /// </summary>
    /// <param name="id"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    Task<TEntity?> GetAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Returns all ToDos
    /// </summary>
    /// <param name="includes"></param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
}