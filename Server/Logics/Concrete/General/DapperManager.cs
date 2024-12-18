using Dapper;
using Microsoft.Data.SqlClient;
using OrisonDailyReport.Server.Logics.Contract.General;
using SecurityService;
using System.Data.Common;
using System.Data;

namespace OrisonDailyReport.Server.Logics.Concrete.General
{
    public class DapperManager : IDapperManager
    {
        private readonly IConfiguration _config;
        private bool disposedValue;
        public DapperManager(IConfiguration config)
        {
            _config = config;
        }
        public DbConnection GetConnection(string key)
        {
            Security security = new Security();
            return new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString(security.Decrypt(key)), "", true));
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
        public T Get<T>(string sp, string key, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetConnection(key);
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault()!;
        }
        public List<T> GetAll<T>(string sp, string key, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                using IDbConnection db = GetConnection(key);
                return db.Query<T>(sp, parms, commandType: commandType).ToList();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                throw;
            }
        }
        public void Execute(string query, string key)
        {
            using IDbConnection db = GetConnection(key);
            db.Execute(query);
        }
        public int Execute(string sp, string key, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetConnection(key);
            return db.Execute(sp, parms, commandType: commandType);
        }
        public long Insert(string sp, DynamicParameters parms, IDbConnection db, IDbTransaction tran, CommandType commandType = CommandType.StoredProcedure)
        {
            long newID;
            parms.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
            var result = db.Execute(sp, parms, transaction: tran, null, CommandType.StoredProcedure);
            newID = parms.Get<long>("@NewID");
            return newID;
        }
        public long InsertTable(string sp, string key, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            long newID;
            using IDbConnection db = GetConnection(key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using var tran = db.BeginTransaction();
                try
                {
                    parms.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                    var result = db.Execute(sp, parms, transaction: tran, null, CommandType.StoredProcedure);
                    newID = parms.Get<long>("@NewID");
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }
        public int Insert1(string sp, DynamicParameters parms, IDbConnection db, IDbTransaction tran, CommandType commandType = CommandType.StoredProcedure)
        {
            int newID;
            parms.Add("NewID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var result = db.Execute(sp, parms, transaction: tran, null, CommandType.StoredProcedure);
            newID = parms.Get<int>("@NewID");
            return newID;
        }
        public void Insertvoid(string sp, string key, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetConnection(key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using var tran = db.BeginTransaction();
                try
                {
                    db.Execute(sp, parms, transaction: tran, null, CommandType.StoredProcedure);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }
        public T Insert<T>(string sp, string key, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = GetConnection(key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault()!;
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return result;
        }

        public T Update<T>(string sp, string key, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = GetConnection(key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault()!;
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return result;
        }
        public long Update(string sp, string key, DynamicParameters parms, CommandType commandType)
        {
            long newID;
            using IDbConnection db = GetConnection(key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using var tran = db.BeginTransaction();
                try
                {
                    parms.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                    var result = db.Execute(sp, parms, transaction: tran, null, CommandType.StoredProcedure);
                    newID = parms.Get<long>("@NewID");
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }
        public long UpdateQuery(string sp, string key, DynamicParameters parms, CommandType commandType)
        {
            long newID;
            using IDbConnection db = GetConnection(key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using var tran = db.BeginTransaction();
                try
                {
                    parms.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                    var result = db.Execute(sp, parms, transaction: tran, null, CommandType.Text);
                    newID = parms.Get<long>("@NewID");
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }
        public long UpdateTable(string sp, DynamicParameters parms, IDbConnection db, IDbTransaction tran, CommandType commandType = CommandType.StoredProcedure)
        {
            long newID;
            try
            {
                parms.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                var result = db.Execute(sp, parms, commandType: commandType, transaction: tran);
                newID = parms.Get<long>("@NewID");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return newID;
        }
        public long UpdateTables1(string sp, DynamicParameters parms, IDbConnection db, IDbTransaction tran, CommandType commandType = CommandType.StoredProcedure)
        {
            long newID;
            try
            {
                parms.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                var result = db.Execute(sp, parms, commandType: commandType, transaction: tran);
                newID = parms.Get<long>("@NewID");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return newID;
        }
        public void UpdateTablev(string sp, DynamicParameters parms, IDbConnection db, IDbTransaction tran, CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                db.Execute(sp, parms, commandType: commandType, transaction: tran);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
