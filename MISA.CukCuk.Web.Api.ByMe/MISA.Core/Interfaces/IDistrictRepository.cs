using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    /// <summary>
    /// 
    /// Interface của district repo kế thừa ibase repo
    /// Thêm phương thức riêng của district 
    /// Created by DTHieu(13/4/2021)
    /// </summary>
    public interface IDistrictRepository:IBaseRepository<District>
    {
        /// <summary>
        /// Lấy dữ liệu danh sách của district theo provinceId
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns>danh sách district </returns>
        public IEnumerable<District> GetDistrictWithProvince(Guid provinceId);
    }
}
