using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
   public  class ProvinceService:BaseService<Province>,IProvinceService
    {
        IUnitOfWork _unitOfWork;
        public ProvinceService(IUnitOfWork unitOfWork, IBaseRepository<Province> baseRepository) : base(unitOfWork, baseRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Province> GetProvinceWithCountry(Guid countryId)
        {
            return _unitOfWork.Province.GetProvinceWithCountry(countryId);
        }
    }
}
