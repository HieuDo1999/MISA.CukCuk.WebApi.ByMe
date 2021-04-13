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
    public class BaseEntityController<T> : ControllerBase
    {
        protected string _tableName = string.Empty;


        IBaseService<T> _baseService;
          
        public BaseEntityController(IBaseService<T> baseService)
        {
            _baseService = baseService;
            _tableName = typeof(T).Name;
            
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
        public IActionResult Get(Guid entityId)
        {
            var entity = _baseService.GetById(entityId);
           
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
        public IActionResult Post(T entity)
        {
            var rowAffects=0;
            if (rowAffects == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entity);
            }

        }
        protected virtual void ValidateData(T entity)
        {
        }
    }
}
