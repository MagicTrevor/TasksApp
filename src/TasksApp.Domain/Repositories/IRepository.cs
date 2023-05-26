using System.Linq.Expressions;

namespace TasksApp.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Creates a new <see cref="TEntity"/>
    /// </summary>
    Task CreateAsync(TEntity entity);

    /// <summary>
    /// Updates the <see cref="TEntity"/>
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task UpdateAsync(TEntity entity);

    /// <summary>
    /// Gets the requested <see cref="TEntity"/> if the id exists
    /// </summary>
    /// <param name="id"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    Task<TEntity?> GetAsync(Guid id, bool shouldTrackEntity = false, params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Returns all ToDos
    /// </summary>
    /// <param name="includes"></param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetAllAsync(bool shouldTrackEntity = false, params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Commits any changes since the last save to the database
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();
}