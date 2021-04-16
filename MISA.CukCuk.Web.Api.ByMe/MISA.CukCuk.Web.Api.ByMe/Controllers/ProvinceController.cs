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
    public class ProvinceController : BaseEntityController<Province>
    {
        IUnitOfWork _unitOfWork;
        public ProvinceController(IUnitOfWork unitOfWork, IBaseService<Province> baseService) : base(baseService)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetProvinceWithCountry/{countryId}")]
        public IActionResult GetProvinceWithCountry(Guid countryId)
        {
            var entities = _unitOfWork.Province.GetProvinceWithCountry(countryId);

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
