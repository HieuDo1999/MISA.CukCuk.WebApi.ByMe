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
    }
}
