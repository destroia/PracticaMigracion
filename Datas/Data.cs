using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Datas
{
    public class Data : IData
    {
        readonly PMContext DB;
        public Data(PMContext db)
        {
            DB = db;
        }
        public async Task<bool> SqlQuerySpBoolAsync(string storedProcedure, object parameters)
        {
            if (string.IsNullOrEmpty(storedProcedure))
                throw new ArgumentException("storedProcedure");

            var arguments = PrepareArguments(storedProcedure, parameters);
            await DB.Database.ExecuteSqlRawAsync(arguments.Item1, arguments.Item2);
            return true;
        }
        public async Task<List<TEntity>> SqlQuerySpListAsync<TEntity>(string storedProcedure, object parameters) where TEntity : class
        {
            if (string.IsNullOrEmpty(storedProcedure))
                throw new ArgumentException("storedProcedure");

            var arguments = PrepareArguments(storedProcedure, parameters);
            var result = await DB.Set<TEntity>().FromSqlRaw(arguments.Item1, arguments.Item2).ToListAsync();
            return result;
        }
        public async Task<TEntity> SqlQuerySpFirstAsync<TEntity>(string storedProcedure, object parameters) where TEntity : class
        {
            if (string.IsNullOrEmpty(storedProcedure))
                throw new ArgumentException("storedProcedure");

            var arguments = PrepareArguments(storedProcedure, parameters);
            var result = await DB.Set<TEntity>().FromSqlRaw(arguments.Item1, arguments.Item2).ToListAsync();
            if (result.Count() > 0)
                return result[0];
            else
                return null;
        }
        private Tuple<string, SqlParameter[]> PrepareArguments(string storedProcedure, object parameters)
        {
            var parameterNames = new List<string>();
            var parameterParameters = new List<SqlParameter>();

            if (parameters != null)
            {
                foreach (var propertyInfo in parameters.GetType().GetProperties())
                {
                    var name = "@" + propertyInfo.Name;
                    var value = propertyInfo.GetValue(parameters, null);

                    parameterNames.Add(name);
                    parameterParameters.Add(new SqlParameter(name, value ?? DBNull.Value));
                }
            }

            if (parameterNames.Count > 0)
                storedProcedure += " " + string.Join(", ", parameterNames);

            return new Tuple<string, SqlParameter[]>(storedProcedure, parameterParameters.ToArray());
        }
    }
}
