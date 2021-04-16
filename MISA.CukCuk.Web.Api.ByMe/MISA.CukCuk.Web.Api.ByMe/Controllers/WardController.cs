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
    public class WardController:BaseEntityController<Ward>
    {
        IUnitOfWork _unitOfWork;
        public WardController(IUnitOfWork unitOfWork, IBaseService<Ward> baseService) : base(baseService)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetWardWithDistrict/{districtId}")]
        public IActionResult GetDistrictWithProvince(Guid districtId)
        {
            var entities = _unitOfWork.Ward.GetWardWithDistrict(districtId);

            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }
    }
}
