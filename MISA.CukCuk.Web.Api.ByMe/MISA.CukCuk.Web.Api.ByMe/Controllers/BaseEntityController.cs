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
            var rowAffects = _baseService.Insert(entity);
            if (rowAffects == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entity);
            }
        }

          [HttpPut("{entityId}")]
            public IActionResult Put(T entity,Guid entityId)
            {
                var rowAffects = _baseService.Update(entity, entityId);
                if (rowAffects == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(entity);
                }

            }


            [HttpDelete("{entityId}")]
        public int Delete(Guid entityId)
        {
            var rowAffects = _baseService.Delete(entityId);
            if (rowAffects == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
        protected virtual void ValidateData(T entity)
        {
        }
    }
}
