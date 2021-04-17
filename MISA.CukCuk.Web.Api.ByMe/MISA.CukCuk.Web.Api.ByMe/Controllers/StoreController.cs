using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MISA_Cukcuk_WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Api.ByMe.Controllers
{
    public class StoreController:BaseEntityController<Store>
    {
        IUnitOfWork _unitOfWork;
        public StoreController(IUnitOfWork unitOfWork, IBaseService<Store> baseService) : base(baseService)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetStoreFilter")]
        public IActionResult GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status)
        {
            var entities = _unitOfWork.Store.GetStoreFilter(storeCode, storeName, address, phoneNumber, status);

            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }
        [HttpGet("GetStoreByStoreCode")]
        public IActionResult GetStoreByStoreCode(string storeCode)
        {
            var entities = _unitOfWork.Store.GetStoreByStoreCode(storeCode);

            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

        [HttpGet("GetStoreByIndexOffset")]
        public IActionResult GetStoreByIndexOffset(int positionStart, int offSet)
        {
            var entities = _unitOfWork.Store.GetStoreByIndexOffset(positionStart,offSet);
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

        [HttpGet("GetCountStores")]
        public IActionResult GetCountStores()
        {
            var entities = _unitOfWork.Store.GetCountStores();
            return Ok(entities);
        }
    }
   
}

