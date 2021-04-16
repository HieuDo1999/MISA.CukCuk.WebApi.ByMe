using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
   public  class WardService:BaseService<Ward>,IWardService
    {
        IUnitOfWork _unitOfWork;
        public WardService(IUnitOfWork unitOfWork, IBaseRepository<Ward> baseRepository) : base(unitOfWork, baseRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Ward> GetWardWithDistrict(Guid wardId)
        {
          return  _unitOfWork.Ward.GetWardWithDistrict(wardId);
        }
    }
}
