using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IDistrictService:IBaseService<District>
    {
        /// <summary>
        /// Lấy dữ liệu danh sách của district theo provinceId
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns>danh sách district </returns>
        public IEnumerable<District> GetDistrictWithProvince(Guid provinceId);
    }
}
