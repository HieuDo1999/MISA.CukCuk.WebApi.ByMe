using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MISA_Cukcuk_WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Api.ByMe.Controllers
{
    public class ProvinceController:BaseEntityController<Province>

    {
        IUnitOfWork _unitOfWork;
        public ProvinceController(IUnitOfWork unitOfWork, IBaseService<Province> baseService) : base(baseService)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
