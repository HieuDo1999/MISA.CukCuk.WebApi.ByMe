using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IProvinceService:IBaseService<Province>
    {
        /// <summary>
        /// Lấy dữ liệu danh sách của province theo countryId
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        IEnumerable<Province> GetProvinceWithCountry(Guid countryId);
    }
}
