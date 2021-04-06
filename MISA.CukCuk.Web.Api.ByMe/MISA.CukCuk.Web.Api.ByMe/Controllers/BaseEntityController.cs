using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA_Cukcuk_WebAPI.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        protected string _tableName = string.Empty;

        protected string _connectionString = "" +
             "Host=47.241.69.179; " +
             "Port=3306;" +
             "User Id= dev; " +
             "Password=12345678;" +
             "Database= MF0_NVManh_CukCuk02";
        protected IDbConnection _dbConnection;
        IBaseService<MISAEntity> _baseService;
        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }
        [HttpGet]
        public IActionResult Get()
        {

            var entities = _baseService.GetEntities();
          
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }
        [HttpGet("{entityId}")]
        public IActionResult Get(string entityId)
        {
            var storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{_tableName}Id", entityId);


            var entity = _dbConnection.Query<MISAEntity>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            if (entity == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(entity);
            }
        }
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            //validate
            ValidateData(entity);
            var storeName = $"Proc_Insert{_tableName}";
            var storeParam = entity;
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            if (rowAffects == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entity);
            }

        }
        protected virtual void ValidateData(MISAEntity entity)
        {
        }
    }
}
