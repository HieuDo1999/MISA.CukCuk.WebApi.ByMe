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
    public class CountryController:BaseEntityController<Country>
    {
        IUnitOfWork _unitOfWork;

        public CountryController(IUnitOfWork unitOfWork, IBaseService<Country> baseService) : base(baseService)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllCountry")]
        public IActionResult GetAll()
        {
            var entities = _unitOfWork.Country.GetEntities();

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
