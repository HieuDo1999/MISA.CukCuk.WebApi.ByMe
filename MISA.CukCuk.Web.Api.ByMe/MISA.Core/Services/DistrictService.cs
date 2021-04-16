using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class DistrictService:BaseService<District>,IDistrictService
    {
        IUnitOfWork _unitOfWork;
        public DistrictService(IUnitOfWork unitOfWork, IBaseRepository<District> baseRepository) : base(unitOfWork, baseRepository)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<District> GetDistrictWithProvince(Guid provinceId)
        {
            return _unitOfWork.District.GetDistrictWithProvince(provinceId);
        }
    }
}
