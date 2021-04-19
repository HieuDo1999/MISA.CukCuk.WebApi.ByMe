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
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="baseService"></param>
        /// created by DTHieu(13/04/2021)
        public BaseEntityController(IBaseService<T> baseService)
        {
            _baseService = baseService;
            _tableName = typeof(T).Name;
            
        }
        /// <summary>
        /// Lấy dữ iệu danh sách entities
        /// </summary>
        /// <returns>Entities</returns>
        /// created by DTHieu(13/04/2021)
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
        /// <summary>
        /// Lấy chi tiết enitty theo entityId
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>1 entity</returns>
        /// created by DTHieu(13/04/2021)
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
        /// <summary>
        /// Create 1 entity mới
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Enitty</returns>
        ///Created by DTHieu(13/04/2021)
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
        /// <summary>
        /// Sửa 1 entitty
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns>Entity</returns>
        /// Created by DTHieu(13/04/2021)
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

        /// <summary>
        /// Xóa 1 entity
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>1 nếu xóa thành công, 0 nếu thất bại</returns>
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
