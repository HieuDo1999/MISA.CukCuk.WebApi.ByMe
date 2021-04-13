using Dapper;
using MISA.Core.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
   public  class BaseRepository<T> : IBaseRepository<T>
    {
        protected string _tableName = string.Empty;

        protected string _connectionString = "" +
             "Host=47.241.69.179; " +
             "Port=3306;" +
             "User Id= dev; " +
             "Password=12345678;" +
             "Database= TEST.MISA.eShop";
        protected IDbConnection _dbConnection;

        public BaseRepository()
        {

            _tableName = typeof(T).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }
        public T Get(string entityId)
        {
            var storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{_tableName}Id", entityId);


            var entity = _dbConnection.Query<T>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        public T GetById(Guid entityId)
        {
            var storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{_tableName}Id", entityId);

            var entity = _dbConnection.Query<T>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        public IEnumerable<T> GetEntities()
        {
            var entities = _dbConnection.Query<T>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            return entities;
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public int Post(T entity)
        {
            //validate
            ValidateData(entity);
            var storeName = $"Proc_Insert{_tableName}";
            var storeParam = entity;
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return rowAffects;

        }

        public int Update(T entity, Guid entityId)
        {
            throw new NotImplementedException();
        }
        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        protected virtual void ValidateData(T entity)
        {
        }
    }
}
