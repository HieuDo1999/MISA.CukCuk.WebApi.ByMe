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
   public  class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        protected string _tableName = string.Empty;

        protected string _connectionString = "" +
             "Host=47.241.69.179; " +
             "Port=3306;" +
             "User Id= dev; " +
             "Password=12345678;" +
             "Database= MF0_NVManh_CukCuk02";
        protected IDbConnection _dbConnection;

        public BaseRepository()
        {

            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }

        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

     

        public MISAEntity Get(string entityId)
        {
            var storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{_tableName}Id", entityId);


            var entity = _dbConnection.Query<MISAEntity>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        public MISAEntity GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MISAEntity> GetEntities()
        {
            var entities = _dbConnection.Query<MISAEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            return entities;
        }

        public int Insert(MISAEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Post(MISAEntity entity)
        {
            //validate
            ValidateData(entity);
            var storeName = $"Proc_Insert{_tableName}";
            var storeParam = entity;
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return rowAffects;

        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            throw new NotImplementedException();
        }

        protected virtual void ValidateData(MISAEntity entity)
        {
        }
    }
}
