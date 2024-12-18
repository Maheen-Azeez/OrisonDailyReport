using Dapper;
using System.Data.Common;
using System.Data;

namespace OrisonDailyReport.Server.Logics.Contract.General
{
    public interface IDapperManager
    {
        DbConnection GetConnection(string key);
        T Get<T>(string sp, string key, DynamicParameters parms, CommandType commandType);
        List<T> GetAll<T>(string sp, string key, DynamicParameters parms, CommandType commandType);
        int Execute(string sp, string key, DynamicParameters parms, CommandType commandType);
        long Insert(string sp, DynamicParameters parms, IDbConnection db, IDbTransaction tran, CommandType commandType = CommandType.StoredProcedure);
        int Insert1(string sp, DynamicParameters parms, IDbConnection db, IDbTransaction tran, CommandType commandType = CommandType.StoredProcedure);
        long InsertTable(string sp, string key, DynamicParameters parms, CommandType commandType);
        void Insertvoid(string sp, string key, DynamicParameters parms, CommandType commandType);
        T Insert<T>(string sp, string key, DynamicParameters parms, CommandType commandType);
        T Update<T>(string sp, string key, DynamicParameters parms, CommandType commandType);
        long Update(string sp, string key, DynamicParameters parms, CommandType commandType);
        long UpdateQuery(string sp, string key, DynamicParameters parms, CommandType commandType);
        long UpdateTable(string sp, DynamicParameters parms, IDbConnection db, IDbTransaction tran, CommandType commandType);
        long UpdateTables1(string sp, DynamicParameters parms, IDbConnection db, IDbTransaction tran, CommandType commandType = CommandType.StoredProcedure);
        void UpdateTablev(string sp, DynamicParameters parms, IDbConnection db, IDbTransaction tran, CommandType commandType);
        void Execute(string queryString, string key);
    }
}
