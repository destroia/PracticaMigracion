
namespace Datas
{
    public interface IData
    {
        Task<bool> SqlQuerySpBoolAsync(string storedProcedure, object parameters);
        Task<List<TEntity>> SqlQuerySpListAsync<TEntity>(string storedProcedure, object parameters) where TEntity : class;
        Task<TEntity> SqlQuerySpFirstAsync<TEntity>(string storedProcedure, object parameters) where TEntity : class;
    }
}
